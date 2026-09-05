
using ObserverPattern;
    

public class Program
{
    public static void Main(string[] args)
    {
        // Create the observable (subject)
        var beerKegger = new BeerKegger();
        // Create observers (party goers)
        var alice = new PartyGoer("Alice");
        var bob = new PartyGoer("Bob");
        var charlie = new PartyGoer("Charlie");
        // Register observers with the observable
        beerKegger.Register(alice);
        beerKegger.Register(bob);
        beerKegger.Register(charlie);
        // Trigger an event in the observable
        beerKegger.BuyKey();
    }
}