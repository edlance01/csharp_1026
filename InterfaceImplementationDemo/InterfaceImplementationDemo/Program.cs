
namespace InterfaceImplementationDemo
{

    class Program
    {
        public static void Main(string[] args)
        {

            // Create instances typed as the Interface
            ILogger defaultLogger = new ConsoleLogger();
            ILogger customLogger = new CustomLogger();

            Console.WriteLine("--- Default Implementation ---");
            defaultLogger.LogMessage("System Started.");
            defaultLogger.LogError("Disk is full");

            Console.WriteLine("--- Overridden Implementation ---");
            customLogger.LogMessage("User logged in.");
            customLogger.LogError("Invalid credentials!");

            Console.WriteLine("--- Direct Class Instance vs Interface Reference ---");
            ConsoleLogger directConsole = new ConsoleLogger();
            directConsole.LogMessage("Direct call works fine.");

            //Uncommenting this will cause a compile error
            // directConsole.LogError("This won't compile")

            // To call the default method on a concrete instance, casts to the interface
            ((ILogger)directConsole).LogError("Must cast to ILogger to access default interface method.")
        }

    }
}