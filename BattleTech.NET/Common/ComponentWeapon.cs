using System;
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
        public double Mass { get; set; }
        public int CriticalSpaceMech { get; set; }
        public int CriticalSpaceProtomech { get; set; }
        public int CriticalSpaceCombatVehicle { get; set; }
        public int CriticalSpaceSupportVehicle { get; set; }
        public int CriticalSpaceFighters { get; set; }
        public int CriticalSpaceSmallCraft { get; set; }
        public int CriticalSpaceDropShips { get; set; }
        public string TechRating { get; set; }
        public string LauncherType { get; set; }

    }
}
