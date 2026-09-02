using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyDelegate
{
   
    internal class OrderProcessor
    {
        //A delegate that acts as a strategy for processing orders
        public Func<decimal, decimal>? TaxStrategy { get; set; }

        public void ProcessOrder(decimal subtotal)
        {
            if (TaxStrategy == null)
            {
                throw new InvalidOperationException("Tax strategy must be set before processing the order.");
            }
            decimal tax = TaxStrategy(subtotal);
            decimal total = subtotal + tax;
            Console.WriteLine($"Subtotal: {subtotal:N2}");
            Console.WriteLine($"Tax:    ${tax:N2}");
            Console.WriteLine($"Total:  ${total:N2}");
            Console.WriteLine("-----------------------------");


        }
    }
}
