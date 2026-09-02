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
        private DateTime? _lastRead;

        public List<EnginePart>? LoadEngineParts(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            // Check if we need to refresh the cache
            if (_lastRead == null || fileInfo.LastWriteTime > _lastRead)
            {
                // Capture the result of the private method into the member variable
                _engines = ReadEnginePartsFromFile(filePath);
                _lastRead = DateTime.Now;
            }

            if (_engines != null)
            {
                _engines.Sort();
            }

            return _engines;
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
    

