namespace NTier.Aviation
{
    //NOTE for an even better way explore Generics
    internal class EnginePartFormatter : AirplanePartFormatter
    {
        // We use 'override' because the signature matches exactly
        public override string GetPartInfo(AirplanePart part)
        {
            // 1. Check if the object passed in is actually an EnginePart
            if (part is EnginePart engine)
            {
                // 2. Call the base formatter for the common fields
                string baseInfo = base.GetPartInfo(engine);

                // 3. Append the engine-specific data
                return baseInfo + $"\nEngine Type: {engine.EngineType}";
            }

            // Fallback: If it's just a regular part, use the base logic
            return base.GetPartInfo(part);
        }
    }
}