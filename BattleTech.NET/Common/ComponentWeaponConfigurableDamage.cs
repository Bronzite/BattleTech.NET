using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    public class ComponentWeaponConfigurableDamage:ComponentWeapon
    {
        public ComponentWeaponConfigurableDamage() : base() { MinDamage = 0;MaxDamage = 0; HeatPerDamage = 1; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public double HeatPerDamage { get; set; }
        public int ToHitMinDamage { get; set; }
        public double ToHitMultiplier { get; set; }
        public override Component CreateInstance()
        {
            return new ComponentWeaponConfigurableDamage();
        }

        public override object Clone()
        {
            ComponentWeaponConfigurableDamage retval = base.Clone() as ComponentWeaponConfigurableDamage;
            retval.MinDamage = MinDamage;
            retval.MaxDamage = MaxDamage;
            return retval;
        }
            
        
    }
}
