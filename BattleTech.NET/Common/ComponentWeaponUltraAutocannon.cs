using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    public class ComponentWeaponUltraAutocannon:ComponentWeapon
    {
        public ComponentWeaponUltraAutocannon() : base() { }
        public int ArtilleryRange { get; set; }
        public override Component CreateInstance()
        {
            return new ComponentWeaponUltraAutocannon();
        }

        public override object Clone()
        {
            ComponentWeaponUltraAutocannon retval = base.Clone() as ComponentWeaponUltraAutocannon;
            retval.ArtilleryRange = ArtilleryRange;
            return retval;
        }
        public override double BVHeatPoints { get { return base.Heat * 2; } }
    }
}
