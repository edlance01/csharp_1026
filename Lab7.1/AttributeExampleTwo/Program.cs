

// Attributes don't do anything by themselves.
// They are just metadata. You need to write code that
// reads the attributes and does something based on them.
// This example demonstrates how to define a custom attribute and then read it using reflection


using System;

namespace AttributeExampleTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Engine);

            // Look for our custom attribute on the Engine class
            object[] attributes = type.GetCustomAttributes(typeof(DeveloperInfoAttribute), false);

            if (attributes.Length > 0)
            {
                DeveloperInfoAttribute info = (DeveloperInfoAttribute)attributes[0];
                Console.WriteLine($"Module: {type.Name}");
                Console.WriteLine($"Developer: {info.Name}");
                Console.WriteLine($"Notes: {info.Description}");
            }
        }
    }
    
}