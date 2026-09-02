using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Aviation
{
    internal class EngineInventoryManager
    {
        private EngineFactory _engineFactory;

        //make it a publisher
        public event EventHandler<InventoryEventArgs>? InventoryExhausted;

        public EngineInventoryManager(EngineFactory engineFactory)
        {
          _engineFactory = engineFactory;
        }

        
        public EnginePart Release(string partNumber)
        {
            if (_engineFactory.EngineDictionary == null)
            {
                throw new InvalidOperationException("Engine factory is not properly initialized, parts not loaded.");
            }

            if (_engineFactory.EngineDictionary.ContainsKey(partNumber))
            {
                EnginePart enginePart = _engineFactory.EngineDictionary[partNumber];
                if (enginePart.Count > 0)
                {
                    enginePart.Count--;
                    if(enginePart.Count < enginePart.Threshold)
                    {
                        InventoryExhausted?.Invoke(this, new InventoryEventArgs(partNumber));
                    }
                    return enginePart;
                }
                else
                {
                    return null; //no parts available
                }
            }
            else
            {
                throw new ArgumentException($"Part number {partNumber} does not exist in inventory.");
            }
                

        }
    }
}
