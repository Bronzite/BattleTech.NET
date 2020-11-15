using BattleTechNET.Common;

namespace BattleTechNET.TotalWarfare
{
    public class CriticalSlot
    {
        public UnitComponent AffectedComponent { get; set; }
        public bool RollAgain { get; set; }        
        public string Label { get; set; }
        public int SlotNumber { get; set; }
        public BattleMechHitLocation Location { get; set; }
        public bool Omnipod { get; set; }
    }
}