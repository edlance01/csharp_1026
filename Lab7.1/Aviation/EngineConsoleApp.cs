using NTier.Aviation;

public class EngineConsoleApp
{
    private List<EnginePart>? _engineParts;
    private Dictionary<string, EnginePart>? _enginePartsDictionary;
    private EngineInventoryManager? _engineInventoryManager;
    private readonly EnginePartFormatter _formatter = new();
    private EngineFactory _factory;
    private bool _isRunning = true;
    private readonly Dictionary<string, Func<string[], bool>> _commands;

    public EngineConsoleApp(string filePath)
    {
        // Load data - separate the setup from the execution
        _factory = new EngineFactory(filePath);
       
            // Initialize the dictionary and map strings to the instance methods
            _commands = new Dictionary<string, Func<string[], bool>>
        {
            { "exit", ExitCommand },
            { "list", ListCommand },
            { "get",  GetCommand },
            { "listbypriceascending", ListByPriceAscendingCommand },
            { "listbypricedescending", ListByPriceDescendingCommand },
            {"listbyenginetype", ListByEngineTypeCommand },
            {"listbypricebetween", ListByPriceBetweenCommand },
            {"release", ReleaseCommand }
        };
    }

    public async Task LoadEngineParts() // Instantitated EngineFactory when app is created.
    {
        //await the factory call
        _engineParts = await _factory.LoadEnginePartsAsync();

        //initialize the local fields from the factory state
        _enginePartsDictionary = _factory.EngineDictionary;
        _engineInventoryManager = _factory.EngineInventoryManager;

        //wire up events
        _factory.EngineInventoryManager.InventoryExhausted += (sender, e) =>
        {
            Console.WriteLine($"Alert: Inventory for part number '{e.PartNumber}' is low!");
        };
    }

    public void Run()
    {
       // remove this when testing async responsiveness ...as it will intially be null and this will return
       // if (_factory.EngineDictionary == null) return;

        while (_isRunning)
        {
            Console.Write("\nEnter a command (list, listbypriceascending, listbypricedescending, listbyenginetype, listbypricebetween, get [part number], release [part number], exit): ");
            string? input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input)) continue;

            // Extract the parsing and execution logic
            ExecuteFromInput(input);
        }
    }

    private void ExecuteFromInput(string input)
    {
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string commandKey = parts[0].ToLower();

        if (_commands.TryGetValue(commandKey, out var commandDelegate))
        {
            // LAB REQUIREMENT: If parts are null, show warning and STOP here
            if (_engineParts == null && commandKey != "exit")
            {
                Console.WriteLine("Warning: Engine parts have not finished loading yet. Please wait.");
                return; // This return is vital; it prevents the crash!
            }

            _isRunning = commandDelegate(parts);
        }
        else
        {
            Console.WriteLine($"Error: Command '{commandKey}' not recognized.");
        }
    }

    private bool ExitCommand(string[] args)
    {
        Console.WriteLine("Exiting program.");
        return false;
    }

    private bool ListCommand(string[] args)
    {
        DisplayAllParts();
        return true;
    }

    private bool GetCommand(string[] args)
    {
        DisplaySinglePart(args);
        return true;
    }

    private bool ListByPriceAscendingCommand(string[] args)
    {
       
        if (_engineParts != null)
        {
            _engineParts.Sort((x,y) => x.Price.CompareTo(y.Price));
             foreach (var part in _engineParts)
            {
                Console.WriteLine(_formatter.GetPartInfo(part));
            }
        }  
        return true;
    }

    private bool ListByPriceDescendingCommand(string[] arguments)
    {
     
        if (_engineParts != null)
        {
            _engineParts.Sort((x, y) => y.Price.CompareTo(x.Price));
            foreach (var part in _engineParts)
            {
                Console.WriteLine(_formatter.GetPartInfo(part));
            }
        }

        return true;
    }

    private bool ReleaseCommand(string[] arguments)
    {
        if (arguments.Length == 2)
        {

            string partNumber = arguments[1];
            try
            {
                EnginePart? releasedPart = _engineInventoryManager?.Release(partNumber);
                if (releasedPart != null)
                {
                    Console.WriteLine($"Part number '{partNumber}' has been released. Remaining inventory: {releasedPart.Count}");
                }
                else
                {
                    Console.WriteLine($"No parts available for {partNumber}.");
                }

            }
            catch (KeyNotFoundException knfe)
            {
                Console.WriteLine($"Error: Part number '{partNumber}' not found. {knfe.Message}");
            }
        }
        else
        {
            Console.WriteLine("Usage: release [part number]");
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

    private bool ListByEngineTypeCommand(string[] arguments)
    {
        if (arguments.Length == 2)
        {
            string type = arguments[1];
            EnginePartFormatter formatter = new EnginePartFormatter();
          
            List<EnginePart>? filteredParts = null;
            if (_engineParts != null)
            {
                filteredParts = (from part in _engineParts
                                 where part.EngineType.Equals(type, StringComparison.OrdinalIgnoreCase)
                                 select part).ToList();
            }
            if (filteredParts != null)
            {
                foreach (EnginePart part in filteredParts)
                {
                    Console.WriteLine(formatter.GetPartInfo(part));
                }
            }
        }
        else
        {
            Console.WriteLine("Usage: listbytype <engine_type>");
        }
        return true;
    }


    private bool ListByPriceBetweenCommand(string[] arguments)
    {
        if (arguments.Length == 3)
        {
            if (double.TryParse(arguments[1], out double minPrice) && double.TryParse(arguments[2], out double maxPrice))
            {
                if (minPrice > maxPrice)
                {
                    double swap = minPrice;
                    minPrice = maxPrice;
                    maxPrice = swap;
                }
               
                var filteredParts = _engineParts?
                    .Where(part => part.Price >= minPrice && part.Price <= maxPrice)
                    .ToList();

                if (filteredParts != null && filteredParts.Count > 0)
                {
                    foreach(EnginePart part in filteredParts)
                    {
                        Console.WriteLine(_formatter.GetPartInfo(part));
                    }
                }
                else
                {
                    Console.WriteLine($"No parts found in the {minPrice} to {maxPrice} range");
                }
            }
            else
            {
                Console.WriteLine("Invalid price format, please enter numbers.");
            }
        
        }
        else
        {
            Console.WriteLine("Usage: listbypricebetween <min_price> <max_price>");
        }
        return true;
    }

   



}

