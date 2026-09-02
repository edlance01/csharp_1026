using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

class Program 
{
    private static readonly HttpClient httpClient = new HttpClient();

    // The requirement is to see the numbers print out in step order,
    // but the network request should be done in the background while
    // the main thread is free to do other work.
    static async Task Main(string[] args)
    {
        Console.WriteLine("1. Main thread starts execution.");

        // Start the async operation, but DO NOT await it immediately
        Task<string> downloadTask = LoadPageDataAsync();

        // -----------------------------------------------------------------
        // This code executes WHILE LoadPageDataAsync is waiting for network I/O
        // -----------------------------------------------------------------
        Console.WriteLine("3. Main thread is free! Doing other work while waiting for the network...");

        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"   Main thread working... step {i}");
            await Task.Delay(200); // Simulates UI work or processing
        }

        Console.WriteLine("4. Main thread is done with local work. Now waiting for the download task...");

        // Now we wait for the download task to finish and retrieve the result
        string result = await downloadTask;

        Console.WriteLine($"5. Received network response ({result.Length} characters). Program complete.");
    }

    public static async Task<string> LoadPageDataAsync()
    {
        Console.WriteLine("2. Inside LoadPageDataAsync: About to call GetStringAsync...");

        // Execution yields back to Main() RIGHT HERE on this line 
        // while the OS handles the network request in the background.
        string response = await httpClient.GetStringAsync("https://zooatlanta.org");

        Console.WriteLine("   -> Inside LoadPageDataAsync: Network request finished!");
        return response;
    }
}