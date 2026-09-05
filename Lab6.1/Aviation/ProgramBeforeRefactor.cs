//using NTier.Aviation;
//using System.Collections;

//namespace com.ntier.Avaiation
//{
//    class ProgramBeforeRefactor
//    {
//        static void Main(string[] args)
//        {
//            try
//            {
//                EnginePartFormatter partFormatter = new EnginePartFormatter();
//                EngineFactory engineFactory = new EngineFactory();

//                List<EnginePart>? engineParts = engineFactory
//                    .LoadEngineParts(@"C:\Users\heidi\source\repos\Lab4.2\Aviation\parts.csv");

//                List<string> commands = new List<string> { "exit", "list", "get" };

//                if (engineFactory.EngineDictionary != null)
//                {
//                    bool runLoop = true;

//                    while (runLoop)
//                    {
//                        Console.Write("\nEnter a command (list, get [part number], exit): ");
//                        string? input = Console.ReadLine()?.Trim();
                        
//                        if (string.IsNullOrWhiteSpace(input)) continue;

//                        string[] parts = input.Trim().Split(' ');
//                        string command = parts[0].ToLower();

//                        if (!commands.Contains(command))
//                        {
//                            Console.WriteLine("Error: Invalid command. Valid commands are: exit, list, get.");
//                            continue;
//                        }

//                        if (command == "exit")
//                        { 
//                            runLoop = false;
//                            Console.WriteLine("Exiting program.");
//                        }
//                        else if (command == "list")
//                        {
//                            // Use "list" to show the whole list
//                            foreach (var kvp in engineFactory.EngineDictionary)
//                            {
//                                Console.WriteLine(partFormatter.GetPartInfo(kvp.Value));
//                            }
//                        }
//                        else if (command == "get")
//                        {
//                            if (parts.Length < 2)
//                            {
//                                Console.WriteLine("Error: 'get' requires a part number. Example: get 123-ABC");
//                            }

//                        if (parts.Length < 2)
//                        {
//                            Console.WriteLine("Error: 'get' command requires a part number. Usage: get [part number]");
//                            continue;
//                        }
//                        else
//                        {                     
//                            string partNumber = parts[1];
//                                if (engineFactory.EngineDictionary.TryGetValue(partNumber, out EnginePart? part))
//                                {
//                                    Console.WriteLine(partFormatter.GetPartInfo(part));
//                                }
//                                else
//                                {
//                                    Console.WriteLine($"Error: Part number '{partNumber}' not found.");
//                                }
//                            }
//                        }
               
//                    }
//                }
                
//            }
//            catch (FileNotFoundException fnfe)
//            {
//                Console.WriteLine($"File not found: {fnfe.Message}");
//            }
//            catch (IOException ioe)
//            {
//                Console.WriteLine($"File error: {ioe.Message}");
//            }
//            catch (FormatException fe)
//            {
//                Console.WriteLine($"Format error: {fe.Message}");
//            }
//            catch (ArgumentException ae)
//            {

//                Console.WriteLine($"Error: {ae.Message}");
//            }
//            catch (PartNumberInvalidFormatException pnife)
//            {
//                Console.WriteLine($"Error: {pnife.Message}");
//                Console.WriteLine($"The value '{pnife.InvalidPartNumber}' is not allowed");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
//            }
//            finally
//            {
//                //Not required in this example, but good practice to include for cleanup if needed
//                Console.WriteLine("Program Completed.");
//            }
//        }
//    }
//}