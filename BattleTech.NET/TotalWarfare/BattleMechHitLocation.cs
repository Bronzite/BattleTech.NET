using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.TotalWarfare
{
    public class BattleMechHitLocation:ArmorHitLocation
    {
        public int CriticalSlotCount { get; set; }
        public List<CriticalSlot> CriticalSlots { get; set; }

        public void AddCriticalSlot(CriticalSlot slot)
        {
            CriticalSlot replaceSlot = null;
            int iFirstAvailableSlot = 1;
            CriticalSlots.Sort((a, b) => { return a.SlotNumber.CompareTo(b.SlotNumber); });
            foreach(CriticalSlot curSlot in CriticalSlots)
            {
                if (curSlot.SlotNumber == slot.SlotNumber)
                    replaceSlot = curSlot;
                else
                    if (curSlot.SlotNumber == iFirstAvailableSlot && !curSlot.RollAgain)
                    iFirstAvailableSlot++;
            }

            if(replaceSlot == null)
            {
                if (slot.SlotNumber == 0) slot.SlotNumber = iFirstAvailableSlot;
                slot.Location = this;
                CriticalSlots.Add(slot);
            }
            else
            {
                replaceSlot.Label = slot.Label;
                replaceSlot.SlotNumber = iFirstAvailableSlot;
            }
        }
    }
}
