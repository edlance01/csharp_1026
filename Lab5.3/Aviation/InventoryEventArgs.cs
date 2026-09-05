using System;
using System.Collections.Generic;
using System.Text;

namespace NTier.Aviation
{
    internal class InventoryEventArgs : EventArgs
    {
        public string? PartNumber { get; private set;  }

        public InventoryEventArgs(string partNumber)
        {
            PartNumber = partNumber;
        }
    }
}
