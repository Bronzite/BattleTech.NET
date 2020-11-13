using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    public class ComponentFireControlSystem:Component
    {
        static public List<ComponentFireControlSystem> GetCanonicalFireControlSystems()
        {
            List<ComponentFireControlSystem> retval = new List<ComponentFireControlSystem>();

            retval.Add(new ComponentFireControlSystem()
            {
                Name = "Artemis IV",
                Tonnage = 1,
                ToHitModifier = 0,
                ClusterHitsModifier = 2,
                TechnologyBase = TECHNOLOGY_BASE.BOTH,
                TechRating = "E",
                CriticalSpaceMech=1,
                CriticalSpaceProtomech = null,
                CriticalSpaceCombatVehicle=0,
                CriticalSpaceFighters=0,
                CriticalSpaceDropShips=0,
                CriticalSpaceSmallCraft=0,
                CriticalSpaceSupportVehicle =1
            }
            ) ;

            retval.Add(new ComponentFireControlSystem()
            {
                Name = "Artemis V",
                Tonnage = 1.5,
                ToHitModifier = -1,
                ClusterHitsModifier = 3,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                TechRating = "E",
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = null,
                CriticalSpaceCombatVehicle = 0,
                CriticalSpaceFighters = 0,
                CriticalSpaceDropShips = 0,
                CriticalSpaceSmallCraft = 0,
                CriticalSpaceSupportVehicle = 2
            }
            );

            return retval;
        }

        public int ToHitModifier { get; set; }
        public int ClusterHitsModifier { get; set; }

        public override object Clone()
        {
            ComponentFireControlSystem retval = base.Clone() as ComponentFireControlSystem;
            retval.ToHitModifier = ToHitModifier;
            retval.ClusterHitsModifier = ClusterHitsModifier;
            return retval;
        }

        public override Component CreateInstance()
        {
            return new ComponentFireControlSystem();
        }

        public static void ResolveComponent(Design design)
        {
            List<ComponentFireControlSystem> fireControlSystems = GetCanonicalFireControlSystems();
            foreach (HitLocation location in design.HitLocations)
            {
                BattleMechHitLocation bmhl = location as BattleMechHitLocation;
                Dictionary<string, List<CriticalSlot>> dicComponents = new Dictionary<string, List<CriticalSlot>>();
                foreach (ComponentFireControlSystem component in fireControlSystems)
                {
                    dicComponents.Add(component.Name, new List<CriticalSlot>());
                }

                foreach (CriticalSlot criticalSlot in bmhl.CriticalSlots)
                {
                    foreach (string sKey in dicComponents.Keys)
                        if (Utilities.IsSynonymFor(criticalSlot.Label, sKey))
                            dicComponents[sKey].Add(criticalSlot);
                }

                foreach (ComponentFireControlSystem component in fireControlSystems)
                {
                    if (dicComponents[component.Name].Count == component.CriticalSpaceMech)
                    {
                        //Add component to design
                        UnitComponent uc = new UnitComponent(component.Clone() as Component, location);
                        foreach (CriticalSlot criticalSlot in dicComponents[component.Name])
                        {
                            criticalSlot.AffectedComponent = uc;
                        }
                        design.Components.Add(uc);
                    }
                }

            }
        }
    }
}
