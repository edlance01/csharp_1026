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

        // Subscribe to the InventoryExhausted event (register as a listener)
        _factory.engineInventoryManager.InventoryExhausted += (sender, evtArgs) =>
        {
            Console.WriteLine($"Low inventory alert for part: {evtArgs.PartNumber}");
            Console.WriteLine($"sender is {sender?.GetType().Name}");
        };

        //initialize dictionary and map strings to the instance methods
        _commands = new Dictionary<string, Func<string[], EngineFactory, bool>>
        {
            {"exit", ExitCommand },
            {"list", ListCommand },
            {"get", GetCommand  },
            {"listbypriceascending", ListByPriceAscendingCommand },
            {"listbypricedescending", ListByPriceDescendingCommand  },
            {"release", ReleaseCommand }
         
        };

    }

    public void Run()
    {
        if (_factory?.EngineDictionary == null) return;

        while (_isRunning)
        {
            Console.Write("\nEnter a command (list, get [part number], listbypriceascending, listbypricedescending, release [part number], exit): ");
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
          Console.WriteLine("Error: Invalid command. Valid: exit, list, get [part number], listbypriceascending, listbypricedescending.");     
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
        // Performs a shallow copy to prevent modifying the factory's list; 
        // null-conditional (?.) and null-coalescing (??) guard against CS8604 compiler warnings
        List<EnginePart> engineParts = factory.LoadEngineParts()?.ToList() ?? new List<EnginePart>();
       engineParts.Sort((e1, e2) => e1.Price.CompareTo(e2.Price));
        foreach(var part in engineParts)
        {
            Console.WriteLine(_formatter.GetPartInfo(part));
        }

        return true;
    }

    private bool ListByPriceDescendingCommand(string[] args, EngineFactory factory)
    {
        // Performs a shallow copy to prevent modifying the factory's list; 
        // null-conditional (?.) and null-coalescing (??) guard against CS8604 compiler warnings
        List<EnginePart> engineParts = factory.LoadEngineParts()?.ToList() ?? new List<EnginePart>();
        engineParts.Sort((e1, e2) => e2.Price.CompareTo(e1.Price));
        foreach (var part in engineParts)
        {
            Console.WriteLine(_formatter.GetPartInfo(part));
        }
        return true;
    }

    private bool ReleaseCommand(string[] args, EngineFactory factory)
    {
        if (args.Length == 2)
        {
            string partNumber = args[1];
            try
            {
                var releasedPart = factory.engineInventoryManager.Release(partNumber);

                if (releasedPart == null)
                {
                    Console.WriteLine($"Part '{partNumber}' is out of stock.");
                }
                else
                {
                    Console.WriteLine($"Released part: {partNumber}");
                    Console.WriteLine($"Remaining inventory for part {partNumber}: {releasedPart.Count}");
                }
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"Error: Part number '{partNumber}' not found.");
            }
        }
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
