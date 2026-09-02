using NTier.Aviation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json;

namespace NTier.Aviation
{
    internal class EngineFactory
    {
        private EngineDataCache _cache = new EngineDataCache();
        private const string CacheFile = "engine_cache.json";

        public List<EnginePart>? LoadEngineParts(string csvFilePath)
        {
            FileInfo fileInfo = new FileInfo(csvFilePath);
            fileInfo.Refresh(); // Ensure we have the latest file info

            // 1. ALWAYS try to load from disk first if the in-memory cache is fresh/empty
            // We check if LastRead is null to see if this instance has loaded anything yet
            if (_cache.LastRead == null && File.Exists(CacheFile))
            {
                try
                {
                    string json = File.ReadAllText(CacheFile);
                    var loadedCache = JsonSerializer.Deserialize<EngineDataCache>(json);
                    if (loadedCache != null)
                    {
                        _cache = loadedCache;
                        Console.WriteLine($"Loaded existing cache. Previous Read: {_cache.LastRead}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Cache file corrupted: {ex.Message}");
                }
            }

            // 2. NOW check if we need to refresh based on the CSV's timestamp
            // If the CSV has been modified since our last recorded read, reload it.
            if (_cache.LastRead == null || fileInfo.LastWriteTime > _cache.LastRead)
            {
                Console.WriteLine($"\n*** CHANGE DETECTED ***");
                Console.WriteLine($"File Last Write: {fileInfo.LastWriteTime}");
                Console.WriteLine($"Cache Last Read: {(_cache.LastRead?.ToString() ?? "Never")}");

                _cache.Engines = ReadEnginePartsFromFile(csvFilePath);

                // Update the timestamp to the FILE'S write time (or Now)
                _cache.LastRead = DateTime.Now;

                // 3. Save the updated state
                string serializedData = JsonSerializer.Serialize(_cache, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(CacheFile, serializedData);
                Console.WriteLine("Cache updated and saved to disk.\n");
            }
            else
            {
                Console.WriteLine("Cache is up to date. Returning memory-resident list.");
            }

            return _cache.Engines;
        }

        private List<EnginePart> ReadEnginePartsFromFile(string filePath)
            {
                // Create a LOCAL list first
                List<EnginePart> tempLines = new List<EnginePart>();

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string? headers = reader.ReadLine();
                    if (headers != "PartNumber,Description,Price,EngineType")
                    {
                        throw new FormatException("The file headers do not match");
                    }

                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');
                        if (fields.Length == 4)
                        {
                            EnginePart enginePart = new EnginePart
                            {
                                PartNumber = fields[0],
                                Description = fields[1],
                                Price = double.Parse(fields[2]),
                                EngineType = fields[3]
                            };
                            // ADD the part to the local list
                            tempLines.Add(enginePart);
                        }
                    }
                }
                // Return the local list to the caller
                return tempLines;
            }
    }
 }
    

