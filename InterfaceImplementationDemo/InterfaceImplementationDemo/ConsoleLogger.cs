using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceImplementationDemo
{
    // Uses the default ILogger.LogError implementation
    internal class ConsoleLogger : ILogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine($"Console Output: {message}");
        }
    }
}
