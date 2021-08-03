using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    class ComponentSpike:ComponentWeapon
    {
        public ComponentSpike()
        {
            TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE;
            CriticalSpaceCombatVehicle = int.MaxValue;
            CriticalSpaceDropShips = int.MaxValue;
            CriticalSpaceFighters = int.MaxValue;
            CriticalSpaceMech = 1;
            CriticalSpaceProtomech = int.MaxValue;
            CriticalSpaceSmallCraft = int.MaxValue;
            CriticalSpaceSupportVehicle = int.MaxValue;
            AeroDamage = 0;
            Heat = 0;
            AeroHeat = 0;
            AeroRange = AerospaceWeaponRanges.SHORT;
            TechRating = "B";
            AeroRange = AerospaceWeaponRanges.NA;
            HeatIsPerShot = true;
            Tonnage = 0.5;
            Name = "Spike";
            BV = 4;
            DefensiveBV = true;
            AddAlias("Spikes");
        }


        public override Component CreateInstance()
        {
            return new ComponentSpike();
        }

        public static void ResolveComponent(Design design)
        {
            List<Component> components = new List<Component>()
                {
                new ComponentSpike()
                };
            foreach (HitLocation location in design.HitLocations)
            {
                BattleMechHitLocation bmhl = location as BattleMechHitLocation;
                Dictionary<Component, List<CriticalSlot>> dicComponents = new Dictionary<Component, List<CriticalSlot>>();
                foreach (Component component in components)
                {
                    dicComponents.Add(component, new List<CriticalSlot>());
                }

                foreach (CriticalSlot criticalSlot in bmhl.CriticalSlots)
                {
                    foreach (Component sKey in dicComponents.Keys)
                        if (Utilities.IsSynonymFor(sKey, criticalSlot.Label))
                            dicComponents[sKey].Add(criticalSlot);
                }

                foreach (Component component in dicComponents.Keys)
                {
                    if (dicComponents[component].Count == component.CriticalSpaceMech)
                    {
                        //Add component to design
                        UnitComponent uc = new UnitComponent(component.Clone() as Component, location);
                        foreach (CriticalSlot criticalSlot in dicComponents[component])
                        {
                            criticalSlot.AffectedComponent = uc;
                        }
                        design.Components.Add(uc);
                    }
                }
            }
        }

        public override object Clone()
        {
            ComponentSpike retval = base.Clone() as ComponentSpike;

            return retval;
        }

        public override double BV { get => base.BV; set => base.BV = value; }
    }
}
