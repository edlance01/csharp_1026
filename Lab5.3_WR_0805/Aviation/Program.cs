using NTier.Aviation;
using System.Collections;
using System.ComponentModel.Design;
using System.IO;
using System.Runtime.CompilerServices;

namespace com.ntier.Avaiation
{
    class Program
    {
        private Dictionary<string, Func<string[], EngineFactory, bool>>? _commands;
        private EnginePartFormatter partFormatter = new EnginePartFormatter();

        static void Main(string[] args)
        {
            Program program = new Program();
            try
            {
          
                EngineFactory engineFactory = new EngineFactory(@"C:\Users\H6\source\repos\csharp_051126\Lab5.3_WR_0805\Aviation\parts.csv");
                List<EnginePart>? engineParts = engineFactory
                    .LoadEngineParts();

                engineFactory.inventoryManager.InventoryExhausted += (sender, evtArgs) =>
                {
                    Console.WriteLine($"Alert: Inventory for part number '{evtArgs.PartNumber}' is low!");
                    Console.WriteLine($"sender is: {sender?.GetType().Name}");
                };

                program._commands = new Dictionary<string, Func<string[], EngineFactory, bool>>
               {
                   {"exit", program.ExitCommand },
                   {"get", program.GetCommand },
                   {"list", program.ListCommand},
                   {"listbypriceascending", program.ListByPriceAscendingCommand},
                   {"listbypricedescending", program.ListByPriceDescendingCommand},
                    {"release", program.ReleaseCommand}

               };

                if (engineFactory.EngineDictionary != null)
                {
                    bool runLoop = true;

                    while (runLoop)
                    {
                        Console.WriteLine("\nEnter a command (list, get [part number], listbypriceascending, listbypricedescending, release [part number], exit): ");
                        string? input = Console.ReadLine()?.Trim();

                        if (string.IsNullOrWhiteSpace(input)) continue;

                        string[] arguments = input.Trim().Split(' ');
                        string command = arguments[0].ToLower();
                      
                        if (program._commands.TryGetValue(command, out var commandDelegate))
                        {
                            runLoop = commandDelegate(arguments, engineFactory);
                        }
                        else 
                        { 
                            Console.WriteLine($"Error: {command} is an invalid command. Valid commands are: exit, list, get, listbypriceascending, listbypricedescending.");
                            continue;
                        }

                        
                        
                    }
                }

         
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine($"File not found: {fnfe.Message}");
            }
            catch (IOException ioe)
            {
                Console.WriteLine($"File error: {ioe.Message}");
            }
            catch (FormatException fe)
            {
                Console.WriteLine($"Format error: {fe.Message}");
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine($"Error: {ae.Message}");
            }
            catch (PartNumberInvalidFormatException pnife)
            {
                Console.WriteLine($"Error: {pnife.Message}");
                Console.WriteLine($"The value '{pnife.InvalidPartNumber}' is not allowed");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                //Not required in this example, but good practice to include for cleanup if needed
                Console.WriteLine("Program Completed.");
            }
        }//Main

        private bool ExitCommand(string[] args, EngineFactory factory)
        {
            Console.WriteLine("Exiting program");
            return false;
        }

        private bool GetCommand(string[] args, EngineFactory factory)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Error: 'get' requires a part number.  Example: get 123-ABC");
            }
            else
            {
                string partNumber = args[1];
                if (factory.EngineDictionary!.TryGetValue(partNumber, out EnginePart? part))
                {
                    Console.WriteLine(partFormatter.GetPartInfo(part));
                }
                else
                {
                    Console.WriteLine($"Part number {partNumber} not found");
                }
            }

             return true;
        }

        private bool ListCommand(string[] args, EngineFactory factory)
        {
            foreach (KeyValuePair<string, EnginePart> kvp in factory.EngineDictionary!)
            {
                Console.Write(partFormatter.GetPartInfo(kvp.Value));
            }
            return true;
        }

        private bool ListByPriceAscendingCommand(string[] args, EngineFactory factory)
        {
            List<EnginePart>? engineParts = factory.LoadEngineParts()?.ToList();
            if (engineParts != null)
            {
                engineParts.Sort((x,y) => x.Price.CompareTo(y.Price));
                foreach (var part in engineParts)
                {
                    Console.WriteLine(partFormatter.GetPartInfo(part));
                }
            }

            return true;

        }

        private bool ListByPriceDescendingCommand(string[] args, EngineFactory factory)
        {
            List<EnginePart>? engineParts = factory.LoadEngineParts()?.ToList();
            if (engineParts != null)
            {
                engineParts.Sort((x, y) => y.Price.CompareTo(x.Price));
                foreach (var part in engineParts)
                {
                    Console.WriteLine(partFormatter.GetPartInfo((part)));
                }
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
                    EnginePart? releasedPart = factory.inventoryManager?.Release(partNumber);
                    if (releasedPart != null)
                    {
                        Console.WriteLine($"Part number '{partNumber}' has been released.  Remaining inventory: {releasedPart.Count}");
                    }
                    else
                    {
                        Console.WriteLine($"No parts available for {partNumber}.");
                    }
                }
                catch (KeyNotFoundException knfe)
                {
                    Console.WriteLine($"Error: Part number '{partNumber} not found. {knfe.Message}");
                }
            }
            else
            {
                Console.WriteLine("Usage: release [part number");
            }

            return true;
        }
    }
}