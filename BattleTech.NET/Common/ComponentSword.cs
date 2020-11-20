using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    public class ComponentSword : ComponentWeapon, IDesignConfigured
    {
        public ComponentSword()
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
            Name = "Sword";
        }

        public ComponentSword(BattleMechDesign battleMechDesign) : this()
        {
            Configure(battleMechDesign);
        }

        public void Configure(Design design)
        {
            BattleMechDesign battleMechDesign = design as BattleMechDesign;

            Tonnage = Math.Ceiling(2*battleMechDesign.Tonnage / 20)/2D;
            CriticalSpaceMech = (int)Math.Ceiling(battleMechDesign.Tonnage / 15);
            Damage = (int)Math.Ceiling(battleMechDesign.Tonnage / 10) + 1;
        }

        public override Component CreateInstance()
        {
            return new ComponentSword();
        }

        public override object Clone()
        {
            ComponentSword retval = base.Clone() as ComponentSword;
            
            return retval;
        }
    }

}

