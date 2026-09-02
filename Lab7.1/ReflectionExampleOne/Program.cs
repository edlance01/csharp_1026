

using System;
using System.Reflection;


namespace ReflectionExampleOne
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the type of the SecretAgent class
            Type type = typeof(SecretAgent);

            // Create an instance of the SecretAgent class
            object agent = Activator.CreateInstance(type);

            Console.WriteLine($"Base Type of {type.Name}: {type.BaseType.Name}");

            Console.WriteLine($"Methods found in {type.Name}:");
            Console.WriteLine("-------------------------------------");

            //get all methods of the SecretAgent class
            MethodInfo[] methods = type.GetMethods();
            foreach (MethodInfo method in methods)
            {
                //print the return type and the name of the method
                Console.WriteLine($"-> {method.ReturnType.Name} {method.Name}");
            }
        }
    }
}