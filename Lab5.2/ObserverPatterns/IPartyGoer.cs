using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    internal interface IPartyGoer
    {
       //the callback
       void Update(string message);
    }
}
