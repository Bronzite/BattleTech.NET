using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Conversion
{
    /// <summary>
    /// This class is used only for conversion, not for gameplay.
    /// </summary>
    public class AlphaStrikeWeapon
    {
        public string Name { get; set; }
        public double Heat { get; set; }
        public double ShortRangeDamage { get; set; }
        public double MediumRangeDamage { get; set; }
        public double LongRangeDamage {get;set;}
        public double ExtremeRangeDamage { get; set; }
        public bool HeatWeapon { get; set; }
        public bool FlakWeapon { get; set; }
        public bool PointDefenseWeapon { get; set; }
        public bool IndirectFireWeapon { get; set; }
        public string SpecialAbilityCode { get; set; }

    }
}
