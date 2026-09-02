using System;
using System.Collections.Generic;
using System.Text;

namespace EventDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Boiler myBoiler = new Boiler();

            // Subscribe to the event
            myBoiler.OnCriticalTemp += HandleCriticalTemperature;

            //Simulate heating up the boiler
            for (int temp = 50; temp <= 120; temp += 10)
            {
                Console.WriteLine($"Current Temperature: {temp}°C");
                myBoiler.HeatUp(temp);
            }

            Console.ReadLine();
        }

        static void HandleCriticalTemperature(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
