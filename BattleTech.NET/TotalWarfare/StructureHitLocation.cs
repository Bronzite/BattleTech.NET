using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.TotalWarfare
{
    public class StructureHitLocation: HitLocation
    {
        public StructureHitLocation() : base() { }
        public string Type { get { return "Standard"; } }

        public StructureLocation Structure { get; set; }

    }
}
