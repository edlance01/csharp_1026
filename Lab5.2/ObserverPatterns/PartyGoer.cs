using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    internal class PartyGoer : IPartyGoer
    {
        public string Name { get; private set;}

        public PartyGoer(string name)
        {
            Name = name;
        }

        // callback implementation
        public void Update(string message)
        {
            Console.WriteLine($"[Notification for {Name}]: {message}");
        }
    }
}
