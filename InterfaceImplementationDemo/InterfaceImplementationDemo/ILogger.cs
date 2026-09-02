using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace InterfaceImplementationDemo
{
    internal interface ILogger
    {
        // abstract method - must be implemented by subclass
        void LogMessage(string message);

        // concrete method with default implementation
        void LogError(string errorMessage)
        {
            LogMessage($"[ERROR:] {errorMessage}");
        }
    }
}
