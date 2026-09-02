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

        public Dictionary<string, EnginePart>? EngineDictionary { get { return _engineDictionary; } }

        public List<EnginePart>? LoadEngineParts(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            if (_lastRead == null || fileInfo.LastWriteTime > _lastRead)
            {
                // Reset both to ensure the cache is fresh
                var (parts, dict) = ReadEnginePartsFromFile(filePath);
                _engines = parts;
                _engineDictionary = dict;
                _lastRead = DateTime.Now;
            }

            _engines?.Sort();
            return _engines;
        }

        private (List<EnginePart>, Dictionary<string, EnginePart>) ReadEnginePartsFromFile(string filePath)
        {
            var tempLines = new List<EnginePart>();
            var tempDict = new Dictionary<string, EnginePart>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string? headers = reader.ReadLine();
                if (headers != "PartNumber,Description,Price,EngineType")
                    throw new FormatException("The file headers do not match");

                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');
                    if (fields.Length == 4)
                    {
                        var enginePart = new EnginePart
                        {
                            PartNumber = fields[0],
                            Description = fields[1],
                            Price = double.Parse(fields[2]),
                            EngineType = fields[3]
                        };
                        tempLines.Add(enginePart);
                        // Use indexer to avoid exceptions on duplicate keys
                        tempDict[enginePart.PartNumber] = enginePart;
                    }
                }
            }
            return (tempLines, tempDict);
        }
    }
 }
    

