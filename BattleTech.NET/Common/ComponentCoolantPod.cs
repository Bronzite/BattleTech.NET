using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    class ComponentCoolantPod:Component
    {
        public ComponentCoolantPod()
        {
            Tonnage = 1;
            CriticalSpaceMech = 1;
            CriticalSpaceFighters = 1;
            TechnologyBase = TECHNOLOGY_BASE.BOTH;
            TechRating = "B";
            BaseCost = 50000; //TO407
            Name = "Coolant Pod";
            AddAlias("Clan Coolant Pod");
        }

        public static void ResolveComponents(Design design)
        {
            foreach (HitLocation location in design.HitLocations)
            {
                BattleMechHitLocation bmhl = location as BattleMechHitLocation;
                List<CriticalSlot> slots = new List<CriticalSlot>();

                Component componentCoolingPod = new ComponentCoolantPod();
                    if (design.IsCompatible(componentCoolingPod))
                    {
                        

                        foreach (CriticalSlot criticalSlot in bmhl.CriticalSlots)
                        {
                            if (Utilities.IsSynonymFor(componentCoolingPod, criticalSlot.Label))
                                slots.Add(criticalSlot);
                        }


                        if (slots.Count == (int)(Math.Ceiling(componentCoolingPod.Tonnage)))
                        {
                            UnitComponent uc = new UnitComponent(componentCoolingPod, bmhl);
                            design.Components.Add(uc);
                        }
                    }
            }

        }
        


        public override Component CreateInstance()
        {
            return new ComponentCoolantPod();
        }

        public override object Clone()
        {
            Component retval = base.Clone() as ComponentCoolantPod;
            return base.Clone();
        }
    }
}
