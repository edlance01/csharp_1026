using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Aviation
{
    internal class Sort
    {
        public static void StartSort()
        {

            // Use an initializer to create a list of SortBy objects
            List<SortBy> sortList = new List<SortBy>
        {
            new SortBy { Order = "down" },
            new SortBy { Order = "up" }
        };

            // Loop through the list and print the value of Order for each element
            foreach (SortBy item in sortList)
            {
                Console.WriteLine("Order: " + item.Order);
            }

            // Keep the console window open until a key is pressed (optional)
            Console.ReadKey();
        }
    }
}
