using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    public class ComponentMachineGunArray:ComponentWeapon
    {
        public List<ComponentWeapon> MemberMachineGuns { get; set; }

        public override Component CreateInstance()
        {
            return new ComponentMachineGunArray();
        }

        public override object Clone()
        {
            ComponentMachineGunArray retval = base.Clone() as ComponentMachineGunArray;
            //TODO: This is something of a problem.  We need to copy MemberMachineGuns

            return retval;
        }
    }
}

