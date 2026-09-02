using NTier.Aviation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace NTier.Aviation
{
    internal class EngineFactory
    {
        private List<EnginePart>? _engines;
        private Dictionary<string, EnginePart>? _engineDictionary;
        private DateTime? _lastRead;
        private string _filePath;
        public Dictionary<string, EnginePart>? EngineDictionary { get { return _engineDictionary; } }
        public EngineInventoryManager EngineInventoryManager { get; private set; }

        public EngineFactory(string filePath) 
        {
            _filePath = filePath;
            EngineInventoryManager = new EngineInventoryManager(this);
        }
        public async Task<List<EnginePart>?> LoadEnginePartsAsync()
        {
            // Lab requirement: 15-second delay to simulate slow loading
            await Task.Delay(15000);

            FileInfo fileInfo = new FileInfo(_filePath);

            if (_lastRead == null || fileInfo.LastWriteTime > _lastRead)
            {
                // Await the new async reader method
                var (parts, dict) = await ReadEnginePartsFromFileAsync(_filePath);

                _engines = parts;
                _engineDictionary = dict;
                _lastRead = fileInfo.LastWriteTime;
            }

            _engines?.Sort();
            return _engines;
        }
        private async Task<(List<EnginePart>, Dictionary<string, EnginePart>)> ReadEnginePartsFromFileAsync(string filePath)
        {
            var tempLines = new List<EnginePart>();
            var tempDict = new Dictionary<string, EnginePart>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                // Use await for the header read
                string? headers = await reader.ReadLineAsync();

                if (headers != "PartNumber,Description,Price,EngineType,Count,Threshold")
                    throw new FormatException($"The file headers do not match: {headers}");

                string? line;
                // Await every line read from the file
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    string[] fields = line.Split(',');
                    if (fields.Length != 6)
                    {
                        throw new FileFormatException($"Invalid line format: {line}");
                    }

                    var enginePart = new EnginePart
                    {
                        PartNumber = fields[0],
                        Description = fields[1],
                        Price = double.Parse(fields[2]),
                        EngineType = fields[3],
                        Count = int.Parse(fields[4]),
                        Threshold = int.Parse(fields[5])
                    };
                    tempLines.Add(enginePart);
                    tempDict[enginePart.PartNumber] = enginePart;
                }
            }
            return (tempLines, tempDict);
        }
    }
 }
    

