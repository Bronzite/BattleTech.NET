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

        public override object Clone()
        {
         
            ComponentWeaponClustered retval = base.Clone() as ComponentWeaponClustered;
            (retval as ComponentWeapon).CopyComponents(this);
            retval.SalvoSize = SalvoSize;
            retval.DamagePerMissile = DamagePerMissile;
            if(FireControlSystem != null)
            retval.FireControlSystem = (ComponentFireControlSystem)FireControlSystem.Clone();
            return retval;
        }

        public override Component CreateInstance()
        {
            return new ComponentWeaponClustered();
        }

    }
}
