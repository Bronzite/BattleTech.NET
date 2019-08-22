using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.TotalWarfare
{
    public class StructureLocation
    {
        public StructureType StructureType { get; set; }
        //Structure Points need to be decimalized because Reinforced Structure
        //allows BattleMechs to take fractional structure damage that does not
        //round at all (TO343)
        public double StructurePoints { get; set; }
        public double MaxStructurePoints { get; set; }
        public string Name { get; set; }

    }
}
