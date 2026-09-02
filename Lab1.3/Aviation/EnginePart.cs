using System;
using System.Collections.Generic;
using System.Text;

namespace NTier.Aviation
{
    internal class EnginePart : AirplanePart, ISelfTest
    {
        public string? EngineType { get; set; }

        public override string GetPartInfo()
        {
            return base.GetPartInfo() + $"\nEngine Type: {EngineType}";
        }

        public int SelfTest()
        {
            // Simulate a self-test for the engine part
            Console.WriteLine("Performing self-test on Engine Part...");
            // For demonstration, we'll just return 1 to indicate success
            return 1;
        }
    }
}
