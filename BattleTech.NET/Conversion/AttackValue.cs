using BattleTechNET.AlphaStrike;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Conversion
{
    public class AttackValue
    {
        public AttackValue() { }
        public AttackValue (AlphaStrikeWeapon asw)
        {
            Name = asw.Name;
            Heat = asw.Heat;
            ShortRangeDamage = asw.ShortRangeDamage;
            MediumRangeDamage = asw.MediumRangeDamage;
            LongRangeDamage = asw.LongRangeDamage;
            ExtremeRangeDamage = asw.ExtremeRangeDamage;
        }
        public string Name { get; set; }
        public double Heat { get; set; }
        public double ShortRangeDamage { get; set; }
        public double MediumRangeDamage { get; set; }
        public double LongRangeDamage { get; set; }
        public double ExtremeRangeDamage { get; set; }
        
        public static AttackValue operator +(AttackValue a, AttackValue b)
        {
            AttackValue retval = new AttackValue();
            retval.Name = a.Name;
            retval.Heat = a.Heat + b.Heat;
            retval.ShortRangeDamage = a.ShortRangeDamage + b.ShortRangeDamage;
            retval.MediumRangeDamage = a.MediumRangeDamage + b.MediumRangeDamage;
            retval.LongRangeDamage = a.LongRangeDamage + b.LongRangeDamage;
            retval.ExtremeRangeDamage = a.ExtremeRangeDamage + b.ExtremeRangeDamage;

            return retval;
        }
        public int[] ToFinalDamageValueIntArray()
        {
            //SO362 calls these out as rounding normally
            if (Name.Equals("AC") ||
                Name.Equals("IF") ||
                Name.Equals("FLK") ||
                Name.Equals("LRM") ||
                Name.Equals("SRM"))
            {
                return new int[] { (int)Math.Round(ShortRangeDamage/10, 0), (int)Math.Round(MediumRangeDamage / 10, 0), (int)Math.Round(LongRangeDamage / 10, 0), (int)Math.Round(ExtremeRangeDamage / 10, 0) };
            }
            else
            {
                return new int[] { (int)Math.Ceiling(ShortRangeDamage / 10), (int)Math.Ceiling(MediumRangeDamage / 10), (int)Math.Ceiling(LongRangeDamage / 10), (int)Math.Ceiling(ExtremeRangeDamage / 10) };
            }
        }

        public Element.Arc ToFinalDamageValueArc()
        {
            //SO362 calls these out as rounding normally
            if (Name.Equals("AC") ||
                Name.Equals("IF") ||
                Name.Equals("FLK") ||
                Name.Equals("LRM") ||
                Name.Equals("SRM"))
            {
                return new Element.Arc(Name,(int)Math.Round(ShortRangeDamage / 10, 0), (int)Math.Round(MediumRangeDamage / 10, 0), (int)Math.Round(LongRangeDamage / 10, 0), (int)Math.Round(ExtremeRangeDamage / 10, 0) ,null);
            }
            else
            {
                return new Element.Arc(Name, (int)Math.Ceiling(ShortRangeDamage / 10), (int)Math.Ceiling(MediumRangeDamage / 10), (int)Math.Ceiling(LongRangeDamage / 10), (int)Math.Ceiling(ExtremeRangeDamage / 10),null) ;
            }
        }
    }
}
