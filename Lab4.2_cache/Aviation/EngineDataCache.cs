using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NTier.Aviation
{
    public class EngineDataCache
    {
        public DateTime? LastRead { get; set; }
        // Using a generic List tells the Serializer EXACTLY what to build
        public List<EnginePart>? Engines { get; set; } = new List<EnginePart>();
    }
}
