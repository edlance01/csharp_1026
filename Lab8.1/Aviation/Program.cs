using NTier.Aviation;

namespace com.ntier.Avaiation
{
    class Program
    {
        static void Main(string[] args)
        {
            AirplanePart enginePart = new EnginePart
            {
                PartNumber = "EP-100",
                Description = "Turbofan Engine",
                Price = 15_000.00,
                EngineType = "GE-90"
            };

           
            EnginePartFormatter enginePartFormatter = new EnginePartFormatter();
            Console.WriteLine(enginePartFormatter.GetPartInfo(enginePart));
            ((EnginePart)enginePart).SelfTest();

            Console.WriteLine();

            // careful, enginePart usually should have an EnginePartFormatter
            // unless you truly want to treat it like a generic AirplanePart, then you can use the AirplanePartFormatter
            AirplanePart airplanePart = enginePart;
            AirplanePartFormatter airplanePartFormatter = new AirplanePartFormatter();
            Console.WriteLine(airplanePartFormatter.GetPartInfo(airplanePart));

            reflect(airplanePart);

           

        }

        static void reflect(AirplanePart airplanePart)
        {
           Type? type = airplanePart.GetType();
           Console.WriteLine($"airplanePart true type: {type.Name}");

           while (type != null)
           {
               Console.WriteLine($"field values for type {type.Name}:");
               var fields = type.GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
               foreach (var field in fields)
               {
                   var value = field.GetValue(airplanePart);
                   Console.WriteLine($"  {field.Name} = {value}");
               }
               type = type.BaseType;
            }

            Console.WriteLine($"\nAttributes on the class {airplanePart.GetType().Name}");
            var attributes = airplanePart.GetType().GetCustomAttributes(inherit: false);

            foreach (var attr in attributes)
            {
                if(attr is AviationComponentAttribute aviationAttr)
                {
                    Console.WriteLine($"  {attr.GetType().Name}: {aviationAttr.Description}");
                }
                else
                {
                    Console.WriteLine($"-{attr.GetType().Name}");
                }
            }

            Console.WriteLine("End of introspection")  ;
        }
    }
}