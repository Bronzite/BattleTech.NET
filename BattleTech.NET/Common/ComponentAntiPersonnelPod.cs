using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    class ComponentAntiPersonnelPod:ComponentWeapon
    {

        public override object Clone()
        {
            ComponentWeapon retval = base.Clone() as ComponentWeapon;

            return retval;
        }
        public override Component CreateInstance()
        {
            return new ComponentAntiPersonnelPod();
        }
    }
}
