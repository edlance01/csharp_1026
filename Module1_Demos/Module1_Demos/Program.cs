using System;

public class Payment
{
    public virtual void Process() => Console.WriteLine("Base Payment Process");
}

public class CreditCardPayment : Payment
{
    // OVERRIDE: Replaces the base behavior globally
    public override void Process() => Console.WriteLine("Credit Card: Overridden");
}

public class BitcoinPayment : Payment
{
    // NEW: Hides the base method; they are now two separate methods
    public new void Process() => Console.WriteLine("Bitcoin: Hidden/New");
}

class Program
{
    static void Main()
    {
        // 1. Overriding behavior
        Payment cc = new CreditCardPayment();
        cc.Process();
        // Output: "Credit Card: Overridden" (Polymorphism works)

        // 2. Hiding behavior
        Payment btcAsPayment = new BitcoinPayment();
        btcAsPayment.Process();
        // Output: "Base Payment Process" (The "new" method is ignored!)

        BitcoinPayment btcAsBtc = new BitcoinPayment();
        btcAsBtc.Process();
        // Output: "Bitcoin: Hidden/New" (Only works when called as Bitcoin type)
    }
}