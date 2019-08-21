using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.TotalWarfare
{
    public class StructureLocation
    {
        public virtual string Type { get { return "Standard"; } }
        public int StructurePoints { get; set; }
        public int MaxStructurePoints { get; set; }
        public string Name { get; set; }

    }
}
