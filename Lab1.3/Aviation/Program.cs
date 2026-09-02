using System;
using System.Collections.Generic;
using System.Text;

using System;
using NTier.Aviation; 

namespace AviationApp  //note changed namespace just to show clients are not always in the same namespace

{
    class Program
    {
       

        static void Main(string[] args)
        {
            EnginePart enginePart = new EnginePart
            {
                PartNumber = "EP-100",
                Description = "Turbofan Engine",
                Price = 15_000.00,
                EngineType = "GE-90"
            };

            AirplanePart airplanePartTwo = new EnginePart
            {
                PartNumber = "AP-200",
                Description = "Wing Flap",
                Price = 5_000.00,
                EngineType = "GE-90-2"
            };

            Console.WriteLine("\n-----Engine Part-----");
            Console.WriteLine(enginePart.GetPartInfo());
            Console.WriteLine(enginePart.SelfTest()); // Testing the self-test method from ISelfTest interface

            Console.WriteLine("\n-----Airplane Part----");
            AirplanePart airplanePart = enginePart;
            Console.WriteLine(airplanePart.GetPartInfo());  // polymorphism in action
            // Console.WriteLine(((ISelfTest)airplanePart).SelfTest()); // Accessing the self-test method through the AirplanePart reference

            Console.WriteLine("\n-----Airplane Part Two-----");
            Console.WriteLine(airplanePartTwo.GetPartInfo()); // polymorphism in action
        }
    }
}
