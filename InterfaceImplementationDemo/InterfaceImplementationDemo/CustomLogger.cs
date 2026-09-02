using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceImplementationDemo
{
    // Overrides the defualt ILogger.LogError implementation
    internal class CustomLogger : ILogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine($"**Custom** Output: {message}");
        }

        // Overriding the default interface method
        public void LogError(string errorMessage)
        {
            Console.WriteLine($"Custom OVERRIDE Error: {errorMessage.ToUpper()}");
        }


    }
}
