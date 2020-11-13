using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    public class ComponentArtillery:ComponentWeapon
    {
        public int ArtilleryRange { get; set; }
        public override Component CreateInstance()
        {
            return new ComponentAmmunition();
        }

        public override object Clone()
        {
            ComponentArtillery retval = base.Clone() as ComponentArtillery;
            retval.ArtilleryRange = ArtilleryRange;
            return retval;
        }
    }
}

