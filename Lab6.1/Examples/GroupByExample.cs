using System;
using System.Collections.Generic;
using System.Linq;

// 1. Define the class
public class Animal
{
    public string Name { get; set; }
    public string Species { get; set; }
}

public class Program
{
    public static void Main()
    {
        // 2. Sample data
        var zooAnimals = new List<Animal>
        {
            new Animal { Name = "Leo", Species = "Lion" },
            new Animal { Name = "Simba", Species = "Lion" },
            new Animal { Name = "Dumbo", Species = "Elephant" },
            new Animal { Name = "Horton", Species = "Elephant" },
            new Animal { Name = "George", Species = "Monkey" }
        };

        // 3. Group by Species using Method Syntax (as shown in your slide)
        var animalsBySpecies = zooAnimals.GroupBy(animal => animal.Species);

        // 4. Iterate over the results
        // Each 'group' is an IGrouping<string, Animal>
        foreach (var group in animalsBySpecies)
        {
            // group.Key contains the value we grouped by (e.g., "Lion")
            Console.WriteLine($"Species: {group.Key}");

            // The group itself contains the matching Animal objects
            foreach (var animal in group)
            {
                Console.WriteLine($" - {animal.Name}");
            }
            Console.WriteLine();
        }
    }
}