using System;
using System.Collections.Generic;
using System.Text;

namespace NTier.Aviation
{
    internal class EnginePart : AirplanePart
    {
        public string? EngineType { get; set; }

        public override string GetPartInfo()
        {
            return base.GetPartInfo() + $"\nEngine Type: {EngineType}";
        }
    }
}
