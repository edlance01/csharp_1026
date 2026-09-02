using NTier.Aviation;

namespace com.ntier.Avaiation
{
    class Program
    {
        static void Main(string[] args)
        {
            //sort demo
            //Sort.StartSort();
            // Main remains clean and only handles the high-level flow and fatal errors
            try
            {
                var app = new EngineConsoleApp();
                app.Initialize(@"C:\Users\heidi\source\repos\Lab4.2\Aviation\parts.csv");
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