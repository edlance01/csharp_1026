using System;
using System.Collections.Generic;
using System.Text;

namespace Examples
{
    public class MathProcessor
    {
        // Func<int, int, int> is a standard delegate 
        // It takes two ints and returns an int.
        public void ProcessNumbers(int a, int b, Func<int, int, int> operation)
        {
            int result = operation(a, b);
            Console.WriteLine($"Result: {result}");
        }

        // Action<string> is a standard delegate 
        // It takes a string and returns void.
        public void PrintMessage(string msg, Action<string> displayMethod)
        {
            displayMethod(msg);
        }
    }
}
