using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    class ComponentWeaponRotaryAutocannon:ComponentWeapon
    {
        public ComponentWeaponRotaryAutocannon() : base() { }
        public int ArtilleryRange { get; set; }
        public override Component CreateInstance()
        {
            return new ComponentWeaponRotaryAutocannon();
        }

        public override object Clone()
        {
            ComponentWeaponRotaryAutocannon retval = base.Clone() as ComponentWeaponRotaryAutocannon;
            retval.ArtilleryRange = ArtilleryRange;
            return retval;
        }
        public override double BVHeatPoints { get { return base.Heat * 6; } }
    }
}
