using NTier.Aviation;

namespace com.ntier.Avaiation
{
    class Programlis
    {
        static void Main(string[] args)
        {
            // Main remains clean and only handles the high-level flow and fatal errors
            try
            {
                var app = new EngineConsoleApp(@"C:\Users\heidi\source\repos\Lab5.3\Aviation\parts.csv");
                app.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fatal Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Program Completed.");
            }
        }
    }
}