using BattleTechNET.Common;

namespace BattleTechNET.TotalWarfare
{
    public class CriticalSlot
    {
        public UnitComponent AffectedComponent { get; set; }
        public bool RollAgain { get; set; }        
        public string Label { get; set; }
    }
}