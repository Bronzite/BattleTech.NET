using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.AlphaStrike
{
    public abstract class UnitType
    {
        public UnitType()
        {
            
        }
        public virtual string Code { get { return ""; } }
    }

    public class UnitTypeBattleMech:UnitType
    {
        public override string Code { get { return "BM"; } }
    }
}
