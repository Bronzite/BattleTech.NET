using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    public class ComponentVibroblade : ComponentWeapon
    {
        static public List<ComponentVibroblade> GetCanonicalVibroblades()
        {
            List<ComponentVibroblade> retval = new List<ComponentVibroblade>();

            retval.Add(new ComponentVibroblade()
            {
                Name = "Small Vibroblade",
                Tonnage = 3,
                CriticalSpaceMech = 1
            }.AddAlias("ISSmallVibroblade") as ComponentVibroblade);
            retval.Add(new ComponentVibroblade()
            {
                Name = "Medium Vibroblade",
                Tonnage = 5,
                CriticalSpaceMech = 2
            }.AddAlias("ISMediumVibroblade") as ComponentVibroblade);
            retval.Add(new ComponentVibroblade()
            {
                Name = "Large Vibroblade",
                Tonnage = 3,
                CriticalSpaceMech = 7
            }.AddAlias("ISLargeVibroblade") as ComponentVibroblade);

            return retval;
        }

        public ComponentVibroblade()
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
            Name = "Vibroblade";
            AddAlias("ISSmallVibroblade");
        }

        public static void ResolveComponent(Design design)
        {
            List<Component> components = new List<Component>(GetCanonicalVibroblades());
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

        public override Component CreateInstance()
        {
            return new ComponentVibroblade();


        }

        public override object Clone()
        {
            ComponentVibroblade retval = base.Clone() as ComponentVibroblade;
            
            return retval;
        }
    }

}

