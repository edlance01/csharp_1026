using NTier.Aviation;
using System.Collections;

namespace com.ntier.Avaiation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                EnginePartFormatter partFormatter = new EnginePartFormatter();
                EngineFactory engineFactory = new EngineFactory();
                List<EnginePart>? engineParts = engineFactory
                    .LoadEngineParts(@"C:\Users\heidi\source\repos\Lab4.2\Aviation\parts.csv");

                if (engineParts != null)
                {
                    List<string>? keys = engineFactory.EngineDictionary?.Keys.ToList();
                    if (keys != null && engineFactory.EngineDictionary != null)
                    {
                        keys.Sort();
                        keys.Reverse();
                        Console.WriteLine("Engine Parts from Dictionary in Reverse Order:");
                        foreach (string key in keys)
                        {
                            Console.WriteLine(partFormatter.GetPartInfo(engineFactory.EngineDictionary[key]));
                        }

                       
                    }
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine($"File not found: {fnfe.Message}");
            }
            catch (IOException ioe)
            {
                Console.WriteLine($"File error: {ioe.Message}");
            }
            catch (FormatException fe)
            {
                Console.WriteLine($"Format error: {fe.Message}");
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
            finally
            {
                //Not required in this example, but good practice to include for cleanup if needed
                Console.WriteLine("Program Completed.");
            }
        }
    }
}