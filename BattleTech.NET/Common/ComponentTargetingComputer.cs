﻿using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    class ComponentTargetingComputer:Component,IDesignConfigured
    {
        public ComponentTargetingComputer()
        {
            Name = "Targeting Computer";
        }

        public static void ResolveComponent(Design design)
        {
            
            foreach (HitLocation location in design.HitLocations)
            {
                BattleMechHitLocation bmhl = location as BattleMechHitLocation;
                List<CriticalSlot> slots = new List<CriticalSlot>();

                ComponentTargetingComputer componentTargetingComputer = new ComponentTargetingComputer();

                componentTargetingComputer.Configure(design);

                foreach (CriticalSlot criticalSlot in bmhl.CriticalSlots)
                {
                        if (Utilities.IsSynonymFor(criticalSlot.Label, "Targeting Computer"))
                            slots.Add(criticalSlot);
                }


                if (slots.Count == (int)(Math.Ceiling(componentTargetingComputer.Tonnage)))
                {
                    UnitComponent uc = new UnitComponent(componentTargetingComputer, bmhl);
                    design.Components.Add(uc);
                }

                

            }
        }

        public void Configure(Design design)
        {
            //TM238: The weight of a targeting computer is based on the weight
            //of all direct-fire, non-missile heavy weaspons, not counting
            //machine guns, flamers, or TAG systems.
            TechnologyBase = design.TechnologyBase;
            double dWeaponsMass = 0;
            foreach(UnitComponent component in design.Components)
            {

                ComponentWeapon weapon = component.Component as ComponentWeapon;
                if(weapon != null)
                {
                    if (weapon.ContributesToTargetingComputerMass)
                        dWeaponsMass += weapon.Tonnage;
                }
            }

            if(TechnologyBase == TECHNOLOGY_BASE.CLAN)
                Tonnage = Math.Ceiling(dWeaponsMass / 5);
            else
                Tonnage = Math.Ceiling(dWeaponsMass / 4);
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

