using System.Reflection;
using System.Runtime.InteropServices;

namespace NTier.Aviation
{
    public class Program
    {
        public static void Main()
        {


            var product = new Product { Price = 100.00m };

            // Use reflection to find the compiler-generated field
            FieldInfo backingField = typeof(Product)
                .GetField("<Price>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic);

            if (backingField != null)
            {
                // Read the value directly from the backing field
                decimal value = (decimal)backingField.GetValue(product);

                // Set the value directly, bypassing any property setters
                backingField.SetValue(product, 150.00m);
            }

            Console.WriteLine($"Backing Field Value: {(decimal)backingField.GetValue(product)}");

        }
    }
}