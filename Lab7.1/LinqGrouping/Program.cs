using System;
using System.Linq;
using System.Collections.Generic;

public class Pet
{
    public string Name { get; set; }
    public string Species { get; set; }
}

public class Program
{
    public static void Main()
    {
        List<Pet> pets = new List<Pet>
        {
            new Pet { Name = "Barnaby", Species = "Dog" },
            new Pet { Name = "Whiskers", Species = "Cat" },
            new Pet { Name = "Goldie", Species = "Fish" },
            new Pet { Name = "Rex", Species = "Dog" },
            new Pet { Name = "Mittens", Species = "Cat" }
        };

        // LINQ Grouping
        var groupedPets = pets.GroupBy(p => p.Species);

        foreach (var group in groupedPets)
        {
            // The 'Key' is the property we grouped by (Species)
            Console.WriteLine($"Species: {group.Key}");

            foreach (var pet in group)
            {
                Console.WriteLine($" - {pet.Name}");
            }
        }
    }
}