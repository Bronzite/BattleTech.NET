using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    class ComponentPPCCapacitor:Component
    {

            public ComponentPPCCapacitor()
            {
                Tonnage = 1;
                CriticalSpaceMech = 1;
                CriticalSpaceFighters = 1;
                CriticalSpaceSupportVehicle = 1;
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE;
                TechRating = "E";
                BaseCost = 150000; //TO411
                Name = "PPC Capacitor";
                AddAlias("ISPPCCapacitor");

            }

            public static void ResolveComponents(Design design)
            {
                foreach (HitLocation location in design.HitLocations)
                {
                    BattleMechHitLocation bmhl = location as BattleMechHitLocation;
                    List<CriticalSlot> slots = new List<CriticalSlot>();

                    ComponentPPCCapacitor ComponentPPCCapacitor = new ComponentPPCCapacitor();
                    //TODO: We need to associate this capacitor
                    //to a specific PPC component on the Mech.

                    if (design.IsCompatible(ComponentPPCCapacitor))
                    {


                        foreach (CriticalSlot criticalSlot in bmhl.CriticalSlots)
                        {
                            if (Utilities.IsSynonymFor(ComponentPPCCapacitor, criticalSlot.Label))
                                slots.Add(criticalSlot);
                        }


                        if (slots.Count == (int)(Math.Ceiling(ComponentPPCCapacitor.Tonnage)))
                        {
                            UnitComponent uc = new UnitComponent(ComponentPPCCapacitor, bmhl);
                            design.Components.Add(uc);
                        }
                    }
                }

            }



            public override Component CreateInstance()
            {
                return new ComponentPPCCapacitor();
            }

            public override object Clone()
            {
                Component retval = base.Clone() as ComponentPPCCapacitor;
                return base.Clone();
            }



    }
}
