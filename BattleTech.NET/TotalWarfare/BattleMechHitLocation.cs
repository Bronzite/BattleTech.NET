using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.TotalWarfare
{
    public class BattleMechHitLocation:ArmorHitLocation
    {
        public int CriticalSlotCount { get; set; }
        public List<CriticalSlot> CriticalSlots { get; set; }
    }
}
