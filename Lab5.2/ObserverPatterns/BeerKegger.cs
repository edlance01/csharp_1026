using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
   // Observable aka Subject
   internal class BeerKegger
    {
        private readonly List<IPartyGoer> _guests = new();

        public void Register(IPartyGoer partyGoer)
        {
            _guests.Add(partyGoer);
            if (partyGoer is PartyGoer pg)
            {
                Console.WriteLine($"{pg.Name} has registered for the party!");
            }
        }

        //event trigger
        public void BuyKey()
        {
            Console.WriteLine("\n Keg has been purchased! Notifying all party goers...");
            NotifyGuests();
        }

        public void NotifyGuests()
        {
            foreach (var guest in _guests)
            {
                guest.Update("The keg is here! Let's party!");
            }
        }

    }
}
