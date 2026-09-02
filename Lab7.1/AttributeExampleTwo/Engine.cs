using System;
using System.Collections.Generic;
using System.Text;


namespace AttributeExampleTwo
{
    //Apply developer attribute
    [DeveloperInfo("Eduardo", "2024-06-01: Initial version of the Engine class.")]
    internal class Engine
    {
        public void Start() => Console.WriteLine("Engine started.");
    }
}
