using NTier.Aviation;

public class EngineConsoleApp
{
    private EngineFactory? _factory;
    private readonly EnginePartFormatter _formatter = new();
    private bool _isRunning = true;

    /*
    * The Value: Func<string[], EngineFactory, bool>
   The value in this dictionary is a delegate, specifically a Func. 
   A Func is a built-in C# delegate that always returns a value. 
   The types listed inside the angle brackets < > define the method's "contract" or signature:
       Input 1 (string[]): This represents the arguments passed with the 
       command (e.g., the "123" in "get 123").
       Input 2 (EngineFactory): This is the data source the method needs to perform its work.
       Output (bool): The very last type in a Func is always the return type. 
       In this lab, it determines if the command loop should continue (true) or exit (false).
   */
    private Dictionary<string, Func<string[], EngineFactory, bool>>? _commands;

    public EngineConsoleApp(string filePath)
    {
        _factory = new EngineFactory(filePath);
        _factory.LoadEngineParts();

        //initialize dictionary and map strings to the instance methods
        _commands = new Dictionary<string, Func<string[], EngineFactory, bool>>
        {
            {"exit", ExitCommand },
            {"list", ListCommand },
            {"get", GetCommand  }
        };

    }

    public void Run()
    {
        if (_factory?.EngineDictionary == null) return;

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
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string command = parts[0].ToLower();
        
        if(_commands!.TryGetValue(command, out var commandDelegate))
        {
            _isRunning = commandDelegate(parts, _factory!);
        }
        else 
        { 
          Console.WriteLine("Error: Invalid command. Valid: exit, list, get.");     
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

    private void DisplayAllParts()
    {
        if (_factory?.EngineDictionary == null) return;

        foreach (var kvp in _factory.EngineDictionary)
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

        if (_factory?.EngineDictionary == null)
        {
            Console.WriteLine("Error: No engine parts loaded.");
            return;
        }

        string partNumber = inputParts[1];
        /* ! The exclamation mark is a null-forgiving operator, which tells the
            compiler that you are sure the value is not null. In this case, it is
            used to assert that EngineDictionary is not null when accessing it.
            However, it's important to ensure that EngineDictionary is indeed
        /*  initialized before using it to avoid potential runtime exceptions.

        /*
            TryGetValue performs a highly efficient hash-table lookup, which is
            generally faster than using ContainsKey followed by indexing.
            Ask - does the key (partNumber) exist in the dictionary? 
            If it does, retrieve the value (part) and pass it to out parameter (part).
            If it does not exist, the method returns false, and part will be 
            set to its default value (null for reference types).
         */
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
