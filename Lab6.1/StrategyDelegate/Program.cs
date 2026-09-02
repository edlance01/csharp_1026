using System.Diagnostics;

namespace StrategyDelegate
{
    public class Program
    {
        public static void Main()
        {
            var processor = new OrderProcessor();
            // 1. US Order (3%) - Using a Lambda expression
            Console.WriteLine("Processing US Order:");
            processor.TaxStrategy = (amount) => amount * 0.03m;
            processor.ProcessOrder(100.00m);

            // 2. Canadian Order (5%)
            Console.WriteLine("Processing Canadian Order:");
            processor.TaxStrategy = (amount) => amount * 0.05m;
            processor.ProcessOrder(100.00m);

            // 3. Chinese Order (7%)
            Console.WriteLine("Processing Chinese Order:");
            processor.TaxStrategy = (amount) => amount * 0.07m;
            processor.ProcessOrder(100.00m);
        }
    }
}

/*
 * Why this is better than a switch statement
You might be tempted to just use a switch(countryCode) inside the ProcessOrder method. However, using a delegate strategy provides several advantages:

Open/Closed Principle: You can add a "UK Order" or a "Tax-Free Order" tomorrow without ever touching the OrderProcessor code. You simply pass in a new lambda.

Decoupling: The OrderProcessor doesn't need to know about international tax laws. It only knows that it has a function that turns a number into a tax amount.

Testability: You can easily pass in a "Mock" tax strategy (like one that always returns $0) to test your order processing logic in isolation.
 * */