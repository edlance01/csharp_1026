

using NTier.Aviation;

namespace Aviation
{

    class Program
    {
        private AirplanePart? _part;
   
        static void Main(string[] args)
        {

            Program program = new Program();
            program._part = new EnginePart
            {
                PartNumber = "EP-100",
                Description = "Turbofan Engine",
                Price = 15_000.00,
                EngineType = "GE-90"
            };

            Console.WriteLine("\n-----Engine Part-----");
            //NOTE the cast
            Console.WriteLine(((EnginePart)program._part).GetPartInfo());

            Console.WriteLine("\n-----Engine Part without the cast ('new' prevents polymorphism)-----");
            Console.WriteLine(program._part.GetPartInfo());

            Console.WriteLine("\n-----Airplane Part----");
            AirplanePart airplanePart = program._part;
            Console.WriteLine(airplanePart.GetPartInfo());


        }
    }
}