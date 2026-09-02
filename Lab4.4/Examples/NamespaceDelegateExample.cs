using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Examples
{
    //Declareing a delegate at the namespace level
    public delegate string LoggerDelegate(string message);

    //think FileLogger, ConsoleLogger, etc. that can all use the same delegat
    public class FileLogger
    {
        public void Log(string msg, LoggerDelegate formatter)
        {
            string logEntry = $"[{DateTime.Now}] LOG: {msg}{Environment.NewLine}";
            var output = formatter(logEntry);
            //write output to file
            File.AppendAllText("log.txt", output);
        }
    }

    public class ConsoleLogger
    {
        public void Log(string msg, LoggerDelegate formatter)
        {
            var output = formatter(msg);
            Console.WriteLine(output);
        }
    }

}
