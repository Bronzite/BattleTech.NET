using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BattleTechNET.Common
{
    public class ComponentHatchet:ComponentWeapon,IDesignConfigured
    {
        public ComponentHatchet()
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
            Name = "Hatchet";
        }

        public ComponentHatchet(BattleMechDesign battleMechDesign):this()
        {
            Configure(battleMechDesign);
        }

        public void Configure(Design design)
        {
            BattleMechDesign battleMechDesign = design as BattleMechDesign;

            int iHatchetBaseStat = (int)Math.Ceiling(battleMechDesign.Tonnage / 15);
            Tonnage = (double)iHatchetBaseStat;
            CriticalSpaceMech = iHatchetBaseStat;
            Damage = (int)Math.Ceiling(battleMechDesign.Tonnage / 5);
        }

        public override Component CreateInstance()
        {
            return new ComponentHatchet();
        }

        public override object Clone()
        {
            ComponentHatchet retval = base.Clone() as ComponentHatchet;
            return retval;
        }

        public override double BV { get => (int)(Damage * 1.5); set => base.BV = value; }
    }
}

