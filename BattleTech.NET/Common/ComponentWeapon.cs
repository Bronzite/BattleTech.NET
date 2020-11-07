﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.Common
{
    public enum AerospaceWeaponRanges { SHORT,MEDIUM,LONG,EXTREME};
    public class ComponentWeapon:Component
    {
        
        public int Heat { get; set; }
        public int AeroHeat { get; set; }
        public bool HeatIsPerShot { get; set; }
        public int Damage { get; set; }
        public int AeroDamage { get; set; }
        public int MinimumRange { get; set; }
        public int ShortRange { get; set; }
        public int MediumRange { get; set; }
        public int LongRange { get; set; }
        public AerospaceWeaponRanges AeroRange { get; set; }
        public double AmmoPerTon { get; set; }

        public string LauncherType { get; set; }

        public new object Clone()
        {
            ComponentWeapon retval = new ComponentWeapon();
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
            return retval;
        }
    }
}
