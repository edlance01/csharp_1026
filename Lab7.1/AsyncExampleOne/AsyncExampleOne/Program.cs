using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    // A reusable HttpClient instance (best practice in .NET)
    private static readonly HttpClient httpClient = new HttpClient();

    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting page load...");

        // Await the async method so it completes before Program ends
        string html = await LoadPageDataAsync();

        Console.WriteLine("\nFirst 100 characters of response:");
        Console.WriteLine(html.Substring(0, Math.Min(100, html.Length)));
    }

    public static async Task<string> LoadPageDataAsync()
    {
        // Calling GetStringAsync will yield control back to the caller 
        // without blocking the main execution thread while waiting for network I/O
        // without blocking the main execution thread while waiting for network I/O
       // string response = await httpClient.GetStringAsync("https://zooatlanta.org");
        string response = await httpClient.GetStringAsync("https://ntiertraining.com");
        return response;
    }
}