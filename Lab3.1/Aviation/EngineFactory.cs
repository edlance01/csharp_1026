using System;
using System.Collections.Generic;
using System.Text;

namespace NTier.Aviation
{
    internal class EngineFactory
    {
        public void LoadEngineParts(string filePath)
        {
            EnginePartFormatter enginePartFormatter = new EnginePartFormatter(); //for pure DI, add interface and do constructor injection

            using (StreamReader reader = new StreamReader(filePath))
            {
                string? headers = reader.ReadLine(); // Read the header line

                if (headers != "PartNumber,Description,Price,EngineType") {
                    throw new FileFormatException("The file headers do not match");
                }
                string? line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');
                    if(fields.Length != 4) {
                        throw new FileFormatException("Each line must have exactly 4 fields");
                    }

                    EnginePart enginePart = new EnginePart
                    {
                        PartNumber = fields[0],
                        Description = fields[1],
                        Price = double.Parse(fields[2]),
                        EngineType = fields[3]
                    };

                    Console.WriteLine(enginePartFormatter.GetPartInfo(enginePart));
                }
            }
        }
    }
}
