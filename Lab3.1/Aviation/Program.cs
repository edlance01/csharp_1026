using NTier.Aviation;

namespace com.ntier.Avaiation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                EngineFactory engineFactory = new EngineFactory();
                engineFactory.LoadEngineParts(@"C:\Users\heidi\source\repos\Lab3.1\Aviation\parts.csv");

            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine($"File not found: {fnfe.Message}");
            }
            catch (IOException ioe)
            {
                Console.WriteLine($"File error: {ioe.Message}");
            }
            catch (FileFormatException fe)
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
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            //}
            finally
            {
                //Not required in this example, but good practice to include for cleanup if needed
                Console.WriteLine("Program Completed.");
            }
        }
    }
}