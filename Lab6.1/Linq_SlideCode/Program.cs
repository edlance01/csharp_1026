

using Linq_SlideCode;

internal class Program
{
   

    static void Main(string[] args)
    {
        var zooAnimals = new List<Animal>
        {
            new Animal { Species = "Capybara" },
            new Animal { Species = "Snow Leopard" },
            new Animal { Species = "Axolotl" },
            new Animal { Species = "Red Panda" },
            new Animal { Species = "Peregrine Falcon" }
        };

        var axolotls = zooAnimals
                    .Where(animal => animal.Species == "Axolotl")
                    .ToList();

        foreach (var animal in axolotls)
        {
            Console.WriteLine($"{animal.Species}");
        }

        //var animalNames = zooAnimals.Select(animal => new {
        //    AnimalSpecies = animal.Species,
        //    AnimalName = animal.Name
        //});

        //foreach (var animal in animalNames)
        //{
        //    Console.WriteLine($"{animal.AnimalName}");
        //}
        
        //this code accomplish the two blocks above
        foreach (var name in zooAnimals.Select(a => a.Name))
        {
            Console.WriteLine(name);
        }

    }

    public string GenerateAnimalName(Animal animal)
    {
        return animal.Species switch
        {
            // The chillest beings in the universe. Names must sound like a relaxed uncle.
            "Capybara" => "Gort the Unbothered",

            // High-altitude parkour cats with giant tails. 
            "Snow Leopard" => "Sir Fluff-Bottom of the Crags",

            // Always smiling, perpetually confused, regenerating limbs for fun.
            "Axolotl" => "Pinky the Water-Pokemon",

            // 50% bear, 50% raccoon, 100% dramatic snack-thief.
            "Red Panda" => "Master Shifu's Intern",

            // The literal fastest animal. Names must be short because they're already gone.
            "Peregrine Falcon" => "Zoom",

            // Default for anything we missed.
            _ => "Standard-Issue Biological Unit"
        };
    }
}