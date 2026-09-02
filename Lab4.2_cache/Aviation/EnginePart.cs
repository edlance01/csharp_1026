namespace NTier.Aviation
{
    public class EnginePart : AirplanePart, ISelfTest
    {
        public string? EngineType { get; set; }

        public int SelfTest()
        {
            Console.WriteLine("Performing self-test on Engine Part...");
            return 1;
        }
    }
}