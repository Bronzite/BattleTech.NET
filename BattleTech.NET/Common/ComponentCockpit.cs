using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    public class ComponentCockpit:Component
    {
        public ComponentCockpit(string sName, int iTonnage, CriticalSlot[] criticalSlots, int iPilotingModifier, TECHNOLOGY_BASE techBase)
        {
            this.Name = Name;
            this.Tonnage = iTonnage;
            this.TechnologyBase = techBase;
            
            PilotingRollModifier = iPilotingModifier;
        }

        public ComponentCockpit()
        {
            
        }

        CriticalSlot[] CriticalSlots { get; set; }
        public int PilotingRollModifier { get; set; }

        public static List<ComponentCockpit> GetCanonicalCockpits()
        {
            List<ComponentCockpit> retval = new List<ComponentCockpit>();

            ComponentCockpit standardCockpit = new ComponentCockpit() 
            { Tonnage = 3, 
              TechnologyBase = TECHNOLOGY_BASE.BOTH, 
              Name = "Standard Cockpit", 
              PilotingRollModifier = 0 };
            standardCockpit.CriticalSlots = new CriticalSlot[]
            {
                new CriticalSlot() {Label = "Life Support",SlotNumber = 1, RollAgain = false },
                new CriticalSlot() {Label = "Life Support",SlotNumber = 6, RollAgain = false },
                new CriticalSlot() {Label = "Cockpit",SlotNumber = 3, RollAgain = false},
                new CriticalSlot() {Label = "Sensor",SlotNumber = 2, RollAgain = false},
                new CriticalSlot() {Label = "Sensor",SlotNumber = 5, RollAgain = false}
            };

            ComponentCockpit smallCockpit = new ComponentCockpit()
            {
                Tonnage = 2,
                TechnologyBase = TECHNOLOGY_BASE.BOTH,
                Name = "Small Cockpit",
                PilotingRollModifier = 1
            };
            smallCockpit.CriticalSlots = new CriticalSlot[]
            {
                new CriticalSlot() {Label = "Life Support",SlotNumber = 1, RollAgain = false },
                new CriticalSlot() {Label = "Cockpit",SlotNumber = 3, RollAgain = false},
                new CriticalSlot() {Label = "Sensor",SlotNumber = 2, RollAgain = false},
                new CriticalSlot() {Label = "Sensor",SlotNumber = 4, RollAgain = false}
            };

            ComponentCockpit torsoCockpit = new ComponentCockpit()
            {
                Tonnage = 4,
                TechnologyBase = TECHNOLOGY_BASE.BOTH,
                Name = "Torso Cockpit",
                PilotingRollModifier = 1
            }.AddAlias("Torso-Mounted Cockpit") as ComponentCockpit;
            torsoCockpit.CriticalSlots = new CriticalSlot[]
            {
                
                new CriticalSlot() {Label = "Cockpit",SlotNumber = 10, RollAgain = false},
                new CriticalSlot() {Label = "Sensor",SlotNumber = 11, RollAgain = false},
                
            };

            retval.Add(standardCockpit);
            retval.Add(smallCockpit);
            retval.Add(torsoCockpit);
            return retval;
        }

        public override Component CreateInstance()
        {
            return new ComponentCockpit();
        }

        public override object Clone()
        {
            ComponentCockpit retval = base.Clone() as ComponentCockpit;
            retval.PilotingRollModifier = PilotingRollModifier;
            //TODO: CriticalSlots clone
            return retval;
        }
    }
}

