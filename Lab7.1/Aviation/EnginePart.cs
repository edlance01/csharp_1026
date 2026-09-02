namespace NTier.Aviation
{
    internal class EnginePart : AirplanePart, ISelfTest, IComparable<EnginePart>
    {
        public string? EngineType { get; set; }

        public int CompareTo(EnginePart? otherPart)
        {
            if (otherPart == null)
            {
                return 1;
            }
            return string.Compare(this.PartNumber, otherPart.PartNumber, StringComparison.Ordinal);

        }

        public int SelfTest()
        {
            Console.WriteLine("Performing self-test on Engine Part...");
            return 1;
        }
    }
}