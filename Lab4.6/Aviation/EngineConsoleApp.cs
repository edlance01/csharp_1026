using NTier.Aviation;

public class EngineConsoleApp
{
    private readonly EnginePartFormatter _formatter = new();
    private readonly EngineFactory _factory = new();
    private bool _isRunning = true;

    public void Initialize(string filePath)
    {
        // Load data - separate the setup from the execution
        _factory.LoadEngineParts(filePath);
    }

    public void Run()
    {
        if (_factory.EngineDictionary == null) return;

        while (_isRunning)
        {
            Console.Write("\nEnter a command (list, get [part number], exit): ");
            string? input = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(input)) continue;

            ProcessCommand(input);
        }
    }

    private void ProcessCommand(string input)
    {
        string[] parts = input.Split(' ');
        string command = parts[0].ToLower();

        switch (command)
        {
            case "exit":
                _isRunning = false;
                Console.WriteLine("Exiting program.");
                break;
            case "list":
                DisplayAllParts();
                break;
            case "get":
                DisplaySinglePart(parts);
                break;
            default:
                Console.WriteLine("Error: Invalid command. Valid: exit, list, get.");
                break;
        }
    }

    private void DisplayAllParts()
    {
        foreach (var kvp in _factory.EngineDictionary!)
        {
            Console.WriteLine(_formatter.GetPartInfo(kvp.Value));
        }
    }

    private void DisplaySinglePart(string[] inputParts)
    {
        if (inputParts.Length < 2)
        {
            Console.WriteLine("Error: 'get' requires a part number.");
            return;
        }

        string partNumber = inputParts[1];
        if (_factory.EngineDictionary!.TryGetValue(partNumber, out var part))
        {
            Console.WriteLine(_formatter.GetPartInfo(part));
        }
        else
        {
            Console.WriteLine($"Error: Part number '{partNumber}' not found.");
        }
    }
}
