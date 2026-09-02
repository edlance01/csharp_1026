using NTier.Aviation;

namespace com.ntier.Avaiation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
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
                ((EnginePart)enginePart).SelfTest();

                Console.WriteLine();

                // careful, enginePart usually should have an EnginePartFormatter
                // unless you truly want to treat it like a generic AirplanePart, then you can use the AirplanePartFormatter
                AirplanePart airplanePart = enginePart;
                AirplanePartFormatter airplanePartFormatter = new AirplanePartFormatter();
                Console.WriteLine(airplanePartFormatter.GetPartInfo(airplanePart));

                Console.WriteLine("\nStarting Negative Price check ...");
                AirplanePart negativePricePart = new EnginePart
                {
                    PartNumber = "EP-200",
                    Description = "Faulty Engine",
                    Price = 5000.00,  //change this to negative for Lab 2.1
                    EngineType = "Unknown"
                };

                //Will this code run when price is negative?
                Console.WriteLine(airplanePartFormatter.GetPartInfo(negativePricePart));

                AirplanePart badPartNumber = new EnginePart
                {
                    PartNumber = "EP-400",  //change this to an invalid format for Lab 2.2
                    Description = "Faulty Part Number",
                    Price = 1000.00,
                    EngineType = "Unknown"
                };
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine($"Error: {ae.Message}");
            }
            catch (PartNumberInvalidFormatException pnife)
            {
                Console.WriteLine($"Error: {pnife.Message}");
                Console.WriteLine($"The value '{pnife.InvalidPartNumber}' is not allowed");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}