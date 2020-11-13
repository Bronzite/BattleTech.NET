using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.Common
{
    public class ComponentAmmunition:Component
    {
        public int Rounds { get; set; }

        public override Component CreateInstance()
        {
            return new ComponentAmmunition();
        }

        public override object Clone()
        {
            ComponentAmmunition retval = base.Clone() as ComponentAmmunition;
            retval.Rounds = Rounds;
            return retval;
        }
    }

    
}
