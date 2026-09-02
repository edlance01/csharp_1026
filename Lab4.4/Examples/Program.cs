

using Examples;

new CallbackDelegateExample().StartDownload(percent =>
{
    Console.WriteLine("Callback received");
    if (percent == 100)
    {
        Console.WriteLine("Download complete!");
    }
});

new FileLogger().Log("This is a log message", msg => $"Formatted log: {msg}");

new ConsoleLogger().Log("This is a console log message", msg => $"Formatted console log: {msg}");



MathProcessor processor = new();
Console.WriteLine("\nTesting Func (Addition):");
processor.ProcessNumbers(5, 3, (a, b) => a + b);

Console.WriteLine("Testing Func (Multiplication):");
processor.ProcessNumbers(5, 3, (a, b) => a * b);

Console.WriteLine("\nTesting Action:");
processor.PrintMessage("Hello, Action!", msg => Console.WriteLine(msg));

processor.PrintMessage("Warning!", msg =>
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"[ALERT]: {msg}");
    Console.ResetColor();
});