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
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = null,
                CriticalSpaceCombatVehicle = 0,
                CriticalSpaceFighters = 0,
                CriticalSpaceDropShips = 0,
                CriticalSpaceSmallCraft = 0,
                CriticalSpaceSupportVehicle = 1
            }.AddAlias("ISArtemisIV").AddAlias("CLArtemisIV") as ComponentFireControlSystem
            );

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
                CriticalSpaceSupportVehicle = 2,


            }.AddAlias("ClanArtemisV").AddAlias("CLArtemisV") as ComponentFireControlSystem
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
                    string sCriticalSlot = criticalSlot.Label.Replace("(omnipod)","").Trim();
                    foreach (string sKey in dicComponents.Keys)
                        if (Utilities.IsSynonymFor(sKey, sCriticalSlot))
                            dicComponents[sKey].Add(criticalSlot);
                }

                foreach (ComponentFireControlSystem component in fireControlSystems)
                {
                    int iSlotCount = dicComponents[component.Name].Count;
                    while (iSlotCount > 0 && component.CriticalSpaceMech.HasValue)
                    {
                        iSlotCount -= component.CriticalSpaceMech.Value;
                        
                        //Add component to design
                        UnitComponent uc = new UnitComponent(component.Clone() as Component, location);
                        foreach (CriticalSlot criticalSlot in dicComponents[component.Name])
                            criticalSlot.AffectedComponent = uc;
                     
                        foreach(CriticalSlot criticalSlot in bmhl.CriticalSlots)
                        {
                            if (criticalSlot.AffectedComponent != null && criticalSlot.Location.Name == location.Name)
                            {
                                ComponentWeaponClustered clustered = criticalSlot.AffectedComponent.Component as ComponentWeaponClustered;
                                if (clustered != null)
                                    if (clustered.Name.Contains("LRM") || clustered.Name.Contains("SRM") || clustered.Name.Contains("MML"))
                                    {
                                        clustered.FireControlSystem = uc.Component as ComponentFireControlSystem;
                                        clustered.Name = $"{clustered.Name} + {uc.Component.Name}";
                                        //clustered.IndirectFire = false; //Artemis can't indirect fire by default
                                        if (clustered.AlphaStrikeAbility == "LRM") clustered.AlphaStrikeAbility = "";
                                    }
                            }
                        }
                        design.Components.Add(uc);
                    }
                }

            }
        }
    }
}
