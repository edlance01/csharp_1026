using NTier.Aviation;

namespace NTier.Aviation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Main remains clean and only handles the high-level flow and fatal errors
            try
            {
                var app = new EngineConsoleApp(@"C:\Users\heidi\source\repos\Lab5.3\Aviation\parts.csv");
                //start the async load and await it

                /* DEMONSTRATE MAIN REMAINING RESPONSIVE DURING LOADING 
                Console.WriteLine("Requesting data load...");
                Task loadingTask =  app.InitializeDataAsync();
                //adding some work here just to show Main can continue working
                while (!loadingTask.IsCompleted)
                {
                    Console.WriteLine("* Main is still responsive while loading data... *");
                    await Task.Delay(200);
                }

                await loadingTask;
                Console.WriteLine("Data load complete!");
                */

                //per lab instructions (not demo code above)
                app.LoadEngineParts(); //ignore this for now
                Console.WriteLine("Application starting... Data is loading in the background.");
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