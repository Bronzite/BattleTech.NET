using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    public class ComponentWeaponClustered:ComponentWeapon
    {
        public int SalvoSize { get; set; }
        public int DamagePerMissile { get { return Damage; } set { Damage = value; } }
        public ComponentFireControlSystem FireControlSystem { get; set; }

        public new object Clone()
        {
            ComponentWeaponClustered retval = new ComponentWeaponClustered();
            retval.Name = Name;
            retval.Tonnage = Tonnage;
            retval.BaseCost = BaseCost;
            retval.TechnologyBase = TechnologyBase;
            retval.Heat = Heat;
            retval.AeroHeat = AeroHeat;
            retval.HeatIsPerShot = HeatIsPerShot;
            retval.Damage = Damage;
            retval.AeroDamage = AeroDamage;
            retval.MinimumRange = MinimumRange;
            retval.ShortRange = ShortRange;
            retval.MediumRange = MediumRange;
            retval.LongRange = LongRange;
            retval.AeroRange = AeroRange;
            retval.AmmoPerTon = AmmoPerTon;
            retval.CriticalSpaceMech = CriticalSpaceMech;
            retval.CriticalSpaceProtomech = CriticalSpaceProtomech;
            retval.CriticalSpaceCombatVehicle = CriticalSpaceCombatVehicle;
            retval.CriticalSpaceDropShips = CriticalSpaceDropShips;
            retval.CriticalSpaceFighters = CriticalSpaceFighters;
            retval.CriticalSpaceSmallCraft = CriticalSpaceSmallCraft;
            retval.CriticalSpaceSupportVehicle = CriticalSpaceSupportVehicle;
            retval.TechRating = TechRating;
            retval.LauncherType = LauncherType;
            retval.FireControlSystem = (ComponentFireControlSystem)FireControlSystem.Clone();
            return retval;
        }


    }
}
