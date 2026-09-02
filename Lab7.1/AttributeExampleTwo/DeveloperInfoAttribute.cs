using System;
using System.Collections.Generic;
using System.Text;

namespace AttributeExampleTwo
{
    internal class DeveloperInfoAttribute : Attribute
    {
                public string Name { get; }
                public string Description { get; }

                public DeveloperInfoAttribute(string name, string description)
                {
                    Name = name;
                    Description = description;
                }
    }
}
