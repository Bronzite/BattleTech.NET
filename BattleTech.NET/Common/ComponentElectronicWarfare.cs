using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BattleTechNET.Common
{
    public class ComponentElectronicWarfare:Component
    {
        public static List<ComponentElectronicWarfare> CanonicalECMs { 
            get
            {
                List<ComponentElectronicWarfare> componentECMs = new List<ComponentElectronicWarfare>();
                componentECMs.Add(new ComponentElectronicWarfare
                {
                    Name = "Electronic Warfare Equipment",
                    TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                    Tonnage = 7.5,
                    BaseCost = 500000,
                    TechRating = "D",
                    ECMRange = 3,
                    ActiveRange = 3,
                    CriticalSpaceMech=4,
                    CriticalSpaceCombatVehicle=1,
                    CriticalSpaceSupportVehicle=4,
                    CriticalSpaceSmallCraft = 1,
                    CriticalSpaceFighters = 1,
                    CriticalSpaceDropShips =0
                }); //TO407
                componentECMs.Add(new ComponentElectronicWarfare
                {
                    Name = "Guardian ECM Suite",
                    TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                    Tonnage = 1.5,
                    BaseCost = 500000, //TODO: Lookup this number
                    TechRating = "E",
                    ECMRange = 6,
                    ActiveRange = 0,
                    CriticalSpaceMech = 2,
                    CriticalSpaceCombatVehicle = 1,
                    CriticalSpaceSupportVehicle = 2,
                    CriticalSpaceSmallCraft = 1,
                    CriticalSpaceFighters = 1,
                    CriticalSpaceDropShips = 0
                }); //TM342

                componentECMs.Add(new ComponentElectronicWarfare
                {
                    Name = "Beagle Active Probe",
                    TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                    Tonnage = 1.5,
                    BaseCost = 500000, //TODO: Lookup this number
                    TechRating = "D",
                    ECMRange = 0,
                    ActiveRange = 4,
                    CriticalSpaceMech = 2,
                    CriticalSpaceCombatVehicle = 1,
                    CriticalSpaceSupportVehicle = 2,
                    CriticalSpaceSmallCraft = 1,
                    CriticalSpaceFighters = 1,
                    CriticalSpaceDropShips = 0
                }); //TM342

                componentECMs.Add(new ComponentElectronicWarfare
                {
                    Name = "C3 Computer Master",
                    TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                    Tonnage = 5,
                    BaseCost = 500000, //TODO: Lookup this number
                    TechRating = "E",
                    ECMRange = 0,
                    ActiveRange = 0,
                    CriticalSpaceMech = 5,
                    CriticalSpaceCombatVehicle = 1,
                    CriticalSpaceSupportVehicle = 1,
                    CriticalSpaceSmallCraft = null,
                    CriticalSpaceFighters = null,
                    CriticalSpaceDropShips = null
                }); //TM342
                componentECMs.Add(new ComponentElectronicWarfare
                {
                    Name = "C3 Computer Slave",
                    TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                    Tonnage = 1,
                    BaseCost = 500000, //TODO: Lookup this number
                    TechRating = "E",
                    ECMRange = 0,
                    ActiveRange = 0,
                    CriticalSpaceMech = 1,
                    CriticalSpaceCombatVehicle = 1,
                    CriticalSpaceSupportVehicle = 1,
                    CriticalSpaceSmallCraft = null,
                    CriticalSpaceFighters = null,
                    CriticalSpaceDropShips = null
                }); //TM342
                componentECMs.Add(new ComponentElectronicWarfare
                {
                    Name = "Improved C3 Computer",
                    TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                    Tonnage = 2.5,
                    BaseCost = 500000, //TODO: Lookup this number
                    TechRating = "E",
                    ECMRange = 0,
                    ActiveRange = 0,
                    CriticalSpaceMech = 2,
                    CriticalSpaceCombatVehicle = 1,
                    CriticalSpaceSupportVehicle = 1,
                    CriticalSpaceSmallCraft = null,
                    CriticalSpaceFighters = null,
                    CriticalSpaceDropShips = null
                }); //TM342
                return componentECMs;
            }
        }

        public static void ResolveComponent(Design design)
        {
            List<ComponentElectronicWarfare> ewComponents = CanonicalECMs;
            foreach(HitLocation location in design.HitLocations)
            {
                BattleMechHitLocation bmhl = location as BattleMechHitLocation;
                Dictionary<string, List<CriticalSlot>> dicComponents = new Dictionary<string, List<CriticalSlot>>();
                foreach(ComponentElectronicWarfare component in ewComponents)
                {
                    dicComponents.Add(component.Name, new List<CriticalSlot>());
                }

                foreach(CriticalSlot criticalSlot in bmhl.CriticalSlots)
                {
                    foreach (string sKey in dicComponents.Keys)
                        if (Utilities.IsSynonymFor(criticalSlot.Label, sKey))
                            dicComponents[sKey].Add(criticalSlot);
                }

                foreach(ComponentElectronicWarfare component in ewComponents)
                {
                    if(dicComponents[component.Name].Count == component.CriticalSpaceMech)
                    {
                        //Add component to design
                        UnitComponent uc = new UnitComponent(component.Clone() as Component, location);
                        foreach(CriticalSlot criticalSlot in dicComponents[component.Name])
                        {
                            criticalSlot.AffectedComponent = uc;
                        }
                        design.Components.Add(uc);
                    }
                }
                
            }
        }

        public int ECMRange { get; set; }
        public int ActiveRange { get; set; }
        
    }
}
