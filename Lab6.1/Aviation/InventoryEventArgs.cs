using System;
using System.Collections.Generic;
using System.Text;

namespace NTier.Aviation
{
    internal class InventoryEventArgs
    {
        public string? PartNumber { get; }
        public InventoryEventArgs(string? partNumber)
        {
            PartNumber = partNumber;
        }
    }
}
