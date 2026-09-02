using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NTier.Aviation
{
    internal class EngineTest
    {
        private List<EnginePart>? _engines;

        public List<EnginePart> Engines
        {
            get 
            {
                if (_engines == null)
                {
                    _engines = new();

                    _engines.Add(new EnginePart()
                    {
                        PartNumber = "0579AECB",
                        Description = "Pratt & Whitney - Quiet turbofan for business jets",
                        Price = 3_212_436.93,
                        EngineType = "Turbofan"
                    });
                    _engines.Add(new EnginePart()
                    {
                        PartNumber = "B36D800E",
                        Description = "IHI Corporation - High - thrust afterburning turbojet",
                        Price = 3_654_294.49,
                        EngineType = "Turbojet"
                    });
                    _engines.Add(new EnginePart()
                    {
                        PartNumber = "031DC97A",
                        Description = "Aero Engine Corporation of China - Efficient turboprop for regional transport",
                        Price = 4_876_983.64,
                        EngineType = "Turbofan"
                    });
                }

                return _engines;
            }
        }
    }
}
