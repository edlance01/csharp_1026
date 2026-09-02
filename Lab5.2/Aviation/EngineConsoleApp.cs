using NTier.Aviation;

public class EngineConsoleApp
{
    private readonly EnginePartFormatter _formatter = new();
    private EngineFactory _factory;
    private bool _isRunning = true;
    /*
     * The Value: Func<string[], EngineFactory, bool>
    The value in this dictionary is a delegate, specifically a Func. A Func is a built-in C# delegate that always returns a value. The types listed inside the angle brackets < > define the method's "contract" or signature:

    Input 1 (string[]): This represents the arguments passed with the command (e.g., the "123" in "get 123").

    Input 2 (EngineFactory): This is the data source the method needs to perform its work.

    Output (bool): The very last type in a Func is always the return type. In this lab, it determines if the command loop should continue (true) or exit (false).
    */
    private readonly Dictionary<string, Func<string[], EngineFactory, bool>> _commands;

    public EngineConsoleApp(string filePath)
    {
        // Load data - separate the setup from the execution
        _factory = new EngineFactory(filePath);
        _factory.LoadEngineParts();

        // Initialize the dictionary and map strings to the instance methods
        _commands = new Dictionary<string, Func<string[], EngineFactory, bool>>
    {
        { "exit", ExitCommand },
        { "list", ListCommand },
        { "get",  GetCommand },
        { "listbypriceascending", ListByPriceAscendingCommand },
        { "listbypricedescending", ListByPriceDescendingCommand }
    };
    }




    public void Run()
    {
        if (_factory.EngineDictionary == null) return;

        while (_isRunning)
        {
            Console.Write("\nEnter a command (list, listbypriceascending, listbypricedescending, get [part number], exit): ");
            string? input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input)) continue;

            // Extract the parsing and execution logic
            ExecuteFromInput(input);
        }
    }

    private void ExecuteFromInput(string input)
    {
        // Job 1: Parsing
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string commandKey = parts[0].ToLower();

        // Job 2: Validation and Execution
        if (_commands.TryGetValue(commandKey, out var commandDelegate))
        {
            _isRunning = commandDelegate(parts, _factory);
        }
        else
        {
            Console.WriteLine($"Error: Command '{commandKey}' not recognized.");
        }
    }


    private bool ExitCommand(string[] args, EngineFactory factory)
    {
        Console.WriteLine("Exiting program.");
        return false;
    }

    private bool ListCommand(string[] args, EngineFactory factory)
    {
        DisplayAllParts();
        return true;
    }

    private bool GetCommand(string[] args, EngineFactory factory)
    {
        DisplaySinglePart(args);
        return true;
    }

    private bool ListByPriceAscendingCommand(string[] args, EngineFactory factory)
    {
       // LINQ
       // var sortedParts = factory.EngineDictionary!.Values.OrderBy(part => part.Price);
       List<EnginePart>? engineParts = factory.LoadEngineParts();
        if (engineParts != null)
        {
            engineParts.Sort((x,y) => x.Price.CompareTo(y.Price));
             foreach (var part in engineParts)
            {
                Console.WriteLine(_formatter.GetPartInfo(part));
            }
        }  
        return true;
    }

    private bool ListByPriceDescendingCommand(string[] arguments, EngineFactory engineFactory)
    {
        List<EnginePart>? engineParts = engineFactory.LoadEngineParts()?.ToList();
        if (engineParts != null)
        {
            engineParts.Sort((x, y) => y.Price.CompareTo(x.Price));
            foreach (var part in engineParts)
            {
                Console.WriteLine(_formatter.GetPartInfo(part));
            }
        }

        return true;
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
