using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.Common
{
    public class SpecialAbility
    {

        public SpecialAbility() { }
        public SpecialAbility (string sCode) { Code = sCode; }

        public virtual string Code { get; protected internal set; }

        
        public string Description { get; protected internal set; }

        public override string ToString()
        {
            return Code;
        }

    }
}
