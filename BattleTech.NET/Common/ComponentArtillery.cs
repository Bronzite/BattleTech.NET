using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    public class ComponentArtillery:ComponentWeapon
    {
        public ComponentArtillery() : base() { }
        public int ArtilleryRange { get; set; }
        public override Component CreateInstance()
        {
            return new ComponentArtillery();
        }

        public override object Clone()
        {
            ComponentArtillery retval = base.Clone() as ComponentArtillery;
            retval.ArtilleryRange = ArtilleryRange;
            return retval;
        }
    }
}

