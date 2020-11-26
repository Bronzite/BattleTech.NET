using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.Common
{
    public enum AerospaceWeaponRanges { SHORT,MEDIUM,LONG,EXTREME,POINTDEFENSE,NA};
    public class ComponentWeapon:Component
    {
        public ComponentWeapon()
        {
            ContributesToTargetingComputerMass = true;
        }
        public int Heat { get; set; }
        public int AeroHeat { get; set; }
        public bool HeatIsPerShot { get; set; }
        private int mDamage = 0;
        public int Damage { get
            {
                return mDamage;
            }

            set 
            {
                mDamage = value;
                ShortRangeDamage = mDamage;
                MediumRangeDamage = mDamage;
                LongRangeDamage = mDamage;
            } 
        }
        public int AeroDamage { get; set; }
        public int MinimumRange { get; set; }
        public int ShortRange { get; set; }
        public int MediumRange { get; set; }
        public int LongRange { get; set; }
        public AerospaceWeaponRanges AeroRange { get; set; }
        public double AmmoPerTon { get; set; }
        public string LauncherType { get; set; }
        public int ToHitModifier { get; set; }
        public bool ContributesToTargetingComputerMass { get; set; }
        public string AlphaStrikeAbility { get; set; }
        public bool IndirectFire { get; set; }
        public int ShortRangeDamage { get; set; }
        public int MediumRangeDamage { get; set; }
        public int LongRangeDamage { get; set; }

        public void CopyComponents(ComponentWeapon weapon)
        {
            Name = weapon.Name;
            Tonnage = weapon.Tonnage;
            BaseCost = weapon.BaseCost;
            TechnologyBase = weapon.TechnologyBase;
            Heat = weapon.Heat;
            AeroHeat = weapon.AeroHeat;
            HeatIsPerShot = weapon.HeatIsPerShot;
            Damage = weapon.Damage;
            AeroDamage = weapon.AeroDamage;
            MinimumRange = weapon.MinimumRange;
            ShortRange = weapon.ShortRange;
            MediumRange = weapon.MediumRange;
            LongRange = weapon.LongRange;
            AeroRange = weapon.AeroRange;
            AmmoPerTon = weapon.AmmoPerTon;
            CriticalSpaceMech = weapon.CriticalSpaceMech;
            CriticalSpaceProtomech = weapon.CriticalSpaceProtomech;
            CriticalSpaceCombatVehicle = weapon.CriticalSpaceCombatVehicle;
            CriticalSpaceDropShips = weapon.CriticalSpaceDropShips;
            CriticalSpaceFighters = weapon.CriticalSpaceFighters;
            CriticalSpaceSmallCraft = weapon.CriticalSpaceSmallCraft;
            CriticalSpaceSupportVehicle = weapon.CriticalSpaceSupportVehicle;
            ToHitModifier = weapon.ToHitModifier;
            TechRating = weapon.TechRating;
            LauncherType = weapon.LauncherType;
            ContributesToTargetingComputerMass = weapon.ContributesToTargetingComputerMass;
            AlphaStrikeAbility = weapon.AlphaStrikeAbility;
            ShortRangeDamage = weapon.ShortRangeDamage;
            MediumRangeDamage = weapon.MediumRangeDamage;
            LongRangeDamage = weapon.LongRangeDamage;
            IndirectFire = weapon.IndirectFire;

        }
        public override object Clone()
        {
            ComponentWeapon retval = base.Clone() as ComponentWeapon;
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
            retval.ToHitModifier = ToHitModifier;
            retval.LauncherType = LauncherType;
            retval.ContributesToTargetingComputerMass = ContributesToTargetingComputerMass;
            retval.AlphaStrikeAbility = AlphaStrikeAbility;
            retval.IndirectFire = IndirectFire;
            retval.ShortRangeDamage = ShortRangeDamage;
            retval.MediumRangeDamage = MediumRangeDamage;
            retval.LongRangeDamage = LongRangeDamage;
            return retval;
        }
        public ComponentWeapon SetRangeDamage(int iShort, int iMedium, int iLong)
        {
            ShortRangeDamage = iShort;
            MediumRangeDamage = iMedium;
            LongRangeDamage = iLong;
            return this;
        }
        public override Component CreateInstance()
        {
            return new ComponentWeapon();
        }
    }
}
