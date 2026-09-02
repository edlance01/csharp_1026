using System;
using System.Collections.Generic;
using System.Text;

namespace NTier.Aviation
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)   ]
    internal class AviationComponentAttribute  : Attribute
    {

        public string Description { get; }
        public AviationComponentAttribute(string description)
        {
            Description = description;
        }
    }
}
