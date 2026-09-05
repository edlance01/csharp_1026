using System;
using System.Collections.Generic;
using System.Text;

namespace NTier.Aviation
{
    internal class EngineInventoryManager
    {
        private EngineFactory _engineFactory;

        // This makes EngineInventoryManager a publisher of the InventoryExhausted event,
        // which can be subscribed to by other classes (subscribers)
        public event EventHandler<InventoryEventArgs>? InventoryExhausted;



        public EngineInventoryManager(EngineFactory engineFactory)
        {
            _engineFactory = engineFactory;
        }

        public EnginePart? Release(string partNumber)
        {
            // Guard clause for uninitialized dictionary
            if (_engineFactory.EngineDictionary == null)
            {
                throw new InvalidOperationException("Engine factory is not properly initialized, parts not loaded.");
            }

            // Fast, single lookup using TryGetValue
            if (!_engineFactory.EngineDictionary.TryGetValue(partNumber, out var enginePart))
            {
                throw new KeyNotFoundException($"Part number '{partNumber}' does not exist in inventory."); ;
            }

            // Return null if out of stock
            if (enginePart.Count <= 0)
            {
              return null;
            }

            // Decrement stock and fire low-inventory event
            enginePart.Count--;
           
            if (enginePart.Count < enginePart.Threshold)
            {
                // this is passes because it's the object that is raising the event 
                InventoryExhausted?.Invoke(this, new InventoryEventArgs(partNumber));
            }

            return enginePart;
        }
    }
}
