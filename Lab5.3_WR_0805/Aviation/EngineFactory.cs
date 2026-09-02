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

        public EngineInventoryManager inventoryManager { get; private set; }

        public Dictionary<string, EnginePart>? EngineDictionary { get { return _engineDictionary; } }

        public EngineFactory(string filePath)
        {
            _filePath = filePath;
            inventoryManager = new EngineInventoryManager(this);
        }
        public List<EnginePart>? LoadEngineParts()
        {
            FileInfo fileInfo = new FileInfo(_filePath);

            if (_lastRead == null || fileInfo.LastWriteTime > _lastRead)
            {
                // Reset both to ensure the cache is fresh
                var (parts, dict) = ReadEnginePartsFromFile(_filePath);
                _engines = parts;
                _engineDictionary = dict;
                _lastRead = DateTime.Now;
            }

            _engines?.Sort();
            return _engines;
        }

        private (List<EnginePart>, Dictionary<string, EnginePart>) ReadEnginePartsFromFile(string filePath)
        {
            var tempList = new List<EnginePart>();
            var tempDict = new Dictionary<string, EnginePart>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string? headers = reader.ReadLine();
                if (headers != "PartNumber,Description,Price,EngineType,Count,Threshold")
                    throw new FormatException("The file headers do not match");

                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');
                    if (fields.Length == 6)
                    {
                        var enginePart = new EnginePart
                        {
                            PartNumber = fields[0],
                            Description = fields[1],
                            Price = double.Parse(fields[2]),
                            EngineType = fields[3],
                            Count = int.Parse(fields[4]),
                            Threshold = int.Parse(fields[5])

                        };
                        tempList.Add(enginePart);
                        // Use indexer to avoid exceptions on duplicate keys
                        tempDict[enginePart.PartNumber] = enginePart;
                    }
                }
            }
            return (tempList, tempDict);
        }
    }
 }
    

