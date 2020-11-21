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
                }
                .AddAlias("ISElectronicWarfareEquipment") as ComponentElectronicWarfare); //TO407
                componentECMs.Add(new ComponentElectronicWarfare
                {
                    Name = "ECM Suite",
                    TechnologyBase = TECHNOLOGY_BASE.CLAN,
                    Tonnage = 1,
                    BaseCost = 500000, //TODO: Lookup this number
                    TechRating = "F",
                    ECMRange = 6,
                    ActiveRange = 0,
                    CriticalSpaceMech = 1,
                    CriticalSpaceCombatVehicle = 1,
                    CriticalSpaceSupportVehicle = 1,
                    CriticalSpaceSmallCraft = 1,
                    CriticalSpaceFighters = 1,
                    CriticalSpaceDropShips = 0
                }
                .AddAlias("CLECMSuite") as ComponentElectronicWarfare); //TM342
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
                }
                .AddAlias("ISGuardianECM")
                .AddAlias("Guardian ECM")
                .AddAlias("ISGuardianECMSuite") as ComponentElectronicWarfare);//TM342+
                componentECMs.Add(new ComponentElectronicWarfare
                {
                    Name = "Angel ECM Suite",
                    TechnologyBase = TECHNOLOGY_BASE.BOTH,
                    Tonnage = 2,
                    BaseCost = 750000, //TO405
                    TechRating = "F",
                    ECMRange = 6,
                    ActiveRange = 0,
                    CriticalSpaceMech = 2,
                    CriticalSpaceCombatVehicle = 1,
                    CriticalSpaceSupportVehicle = 2,
                    CriticalSpaceSmallCraft = 1,
                    CriticalSpaceFighters = 1,
                    CriticalSpaceDropShips = 0
                }
                .AddAlias("ISAngelECM")
                .AddAlias("Angel ECM")
                .AddAlias("ISAngelECMSuite") as ComponentElectronicWarfare);//TO405
                componentECMs.Add(new ComponentElectronicWarfare
                {
                    Name = "Beagle Active Probe",
                    TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                    Tonnage = 1.5,
                    BaseCost = 500000, //TODO: Lookup this number
                    TechRating = "E",
                    ECMRange = 0,
                    ActiveRange = 5,
                    CriticalSpaceMech = 2,
                    CriticalSpaceCombatVehicle = 1,
                    CriticalSpaceSupportVehicle = 1,
                    CriticalSpaceSmallCraft = 1,
                    CriticalSpaceFighters = 1,
                    CriticalSpaceDropShips = 0
                }
                .AddAlias("BeagleActiveProbe")
                .AddAlias("ISBeagleActiveProbe") as ComponentElectronicWarfare); //TM342
                componentECMs.Add(new ComponentElectronicWarfare
                {
                    Name = "Light Active Probe",
                    TechnologyBase = TECHNOLOGY_BASE.CLAN,
                    Tonnage = 0.5,
                    BaseCost = 500000, //TODO: Lookup this number
                    TechRating = "F",
                    ECMRange = 0,
                    ActiveRange = 3,
                    CriticalSpaceMech = 1,
                    CriticalSpaceCombatVehicle = 1,
                    CriticalSpaceSupportVehicle = 1,
                    CriticalSpaceSmallCraft = 1,
                    CriticalSpaceFighters = 1,
                    CriticalSpaceDropShips = 0
                }
                .AddAlias("CLLightActiveProbe") as ComponentElectronicWarfare); //TM343
                componentECMs.Add(new ComponentElectronicWarfare
                {
                    Name = "Active Probe",
                    TechnologyBase = TECHNOLOGY_BASE.CLAN,
                    Tonnage = 1,
                    BaseCost = 500000, //TODO: Lookup this number
                    TechRating = "E",
                    ECMRange = 0,
                    ActiveRange = 5,
                    CriticalSpaceMech = 1,
                    CriticalSpaceCombatVehicle = 1,
                    CriticalSpaceSupportVehicle = 1,
                    CriticalSpaceSmallCraft = 1,
                    CriticalSpaceFighters = 1,
                    CriticalSpaceDropShips = 0
                }
                .AddAlias("CLActiveProbe") as ComponentElectronicWarfare); //TM343
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
                }
                .AddAlias("ISC3MasterComputer")
                .AddAlias("ISC3MasterUnit")
                .AddAlias("C3 Master with TAG") as ComponentElectronicWarfare); //TM342
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
                }
                .AddAlias("ISC3SlaveUnit") as ComponentElectronicWarfare); //TM342
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
                }
                .AddAlias("ISC3iUnit")
                .AddAlias("ISImprovedC3CPU") as ComponentElectronicWarfare); //TM342

                
                return componentECMs;
            }
        }

        public static void ResolveComponent(Design design)
        {
            List<ComponentElectronicWarfare> ewComponents = CanonicalECMs;
            foreach(HitLocation location in design.HitLocations)
            {
                BattleMechHitLocation bmhl = location as BattleMechHitLocation;
                Dictionary<ComponentElectronicWarfare, List<CriticalSlot>> dicComponents = new Dictionary<ComponentElectronicWarfare, List<CriticalSlot>>();
                foreach(ComponentElectronicWarfare component in ewComponents)
                {
                    dicComponents.Add(component, new List<CriticalSlot>());
                }

                foreach(CriticalSlot criticalSlot in bmhl.CriticalSlots)
                {
                    foreach (ComponentElectronicWarfare sKey in dicComponents.Keys)
                        if (Utilities.IsSynonymFor(sKey,criticalSlot.Label))
                            dicComponents[sKey].Add(criticalSlot);
                }

                foreach(ComponentElectronicWarfare component in dicComponents.Keys)
                {
                    if(dicComponents[component].Count == component.CriticalSpaceMech)
                    {
                        //Add component to design
                        UnitComponent uc = new UnitComponent(component.Clone() as Component, location);
                        foreach(CriticalSlot criticalSlot in dicComponents[component])
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

        public override Component CreateInstance()
        {
            return new ComponentElectronicWarfare();
        }

        public override object Clone()
        {
            ComponentElectronicWarfare retval = base.Clone() as ComponentElectronicWarfare;
            retval.ECMRange = ECMRange;
            retval.ActiveRange = ActiveRange;
            return retval;
        }
    }
}

