using System;
using System.Collections.Generic;
using System.Text;

namespace AttributeExampleOne
{
    internal class ToolBox
    {
        //This attribute will generate a compiler warning
        [Obsolete("This method is obsolete. Use NewMethod instead.")]
        public void OldMethod()
        {
            Console.WriteLine("This is the old method.");
        }   

        public void NewMethod()
        {
            Console.WriteLine("This is the new method.");
        }   
    }
}
