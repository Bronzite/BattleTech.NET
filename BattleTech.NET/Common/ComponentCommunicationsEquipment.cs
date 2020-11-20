using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    class ComponentCommunicationsEquipment:Component
    {

        public ComponentCommunicationsEquipment():base()
        {
            Name = "Communications Equipment";
            Tonnage = 1;
        }
        public ComponentCommunicationsEquipment(int iSlots):this()
        {
            Tonnage = iSlots;
        }

        public static void ResolveComponent(Design design)
        {
            //TM212: Communications Equipment is 1 ton per
            //Critical Hit location.

            foreach (HitLocation location in design.HitLocations)
            {
                BattleMechHitLocation bmhl = location as BattleMechHitLocation;
                List<CriticalSlot> slots = new List<CriticalSlot>();

                


                foreach (CriticalSlot criticalSlot in bmhl.CriticalSlots)
                {
                    if (criticalSlot.Label.StartsWith("Communications Equipment"))
                        slots.Add(criticalSlot);
                }


                if (slots.Count > 0)
                {
                    ComponentCommunicationsEquipment componentCommunicationsEquipment = new ComponentCommunicationsEquipment(slots.Count);
                    UnitComponent uc = new UnitComponent(componentCommunicationsEquipment, bmhl);
                    design.Components.Add(uc);
                }



            }
        }

        public override Component CreateInstance()
        {
            return new ComponentTargetingComputer();
        }

        public override object Clone()
        {
            ComponentTargetingComputer retval = base.Clone() as ComponentTargetingComputer;
            return retval;
        }
    }
}
