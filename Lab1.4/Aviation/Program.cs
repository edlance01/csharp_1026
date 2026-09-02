using NTier.Aviation;

namespace com.ntier.Avaiation
{
    class Program
    {
        static void Main(string[] args)
        {
            AirplanePart enginePart = new EnginePart
            {
                PartNumber = "EP-100",
                Description = "Turbofan Engine",
                Price = 15_000.00,
                EngineType = "GE-90"
            };

           
            EnginePartFormatter enginePartFormatter = new EnginePartFormatter();
            Console.WriteLine(enginePartFormatter.GetPartInfo(enginePart));
            // ((EnginePart)enginePart).SelfTest();  // Is there another way to do this without casting to a concrete type? 
          
            Console.WriteLine($"Self Test: {((ISelfTest)enginePart).SelfTest()}\n");

            // careful, enginePart usually should have an EnginePartFormatter
            // unless you truly want to treat it like a generic AirplanePart, then you can use the AirplanePartFormatter
            AirplanePart airplanePart = enginePart;
            AirplanePartFormatter airplanePartFormatter = new AirplanePartFormatter();
            Console.WriteLine(airplanePartFormatter.GetPartInfo(airplanePart));

        }
    }
}