using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Data
{
    /// <summary>
    /// This class is intended to serve as a volatile library that can be 
    /// loaded at runtime and used to test systems.
    /// </summary>
    public class MemoryLibrary:ILibrary
    {
        private Dictionary<Guid,BattleMechDesign> BattleMechDesigns { get; set; }
        public IDictionary<Guid,string> ListBattleMechDesigns()
        {
            Dictionary<Guid, string> retval = new Dictionary<Guid, string>();
            foreach(Guid currentBattleMechDesignKey in BattleMechDesigns.Keys)
            {
                BattleMechDesign currentBattleMechDesign = BattleMechDesigns[currentBattleMechDesignKey];
                if (!retval.ContainsKey(currentBattleMechDesign.Id))
                    retval.Add(currentBattleMechDesign.Id, currentBattleMechDesign.ToString());
            }

            return retval;
        }

        public BattleMechDesign GetBattleMechDesign(Guid Id)
        {
            if (BattleMechDesigns.ContainsKey(Id))
                return BattleMechDesigns[Id];
            else
                throw new Exception("Library does not contain that BattleMech");
        }

        public void StoreBattleMechDesign(BattleMechDesign battleMechDesign)
        {
            if (!BattleMechDesigns.ContainsKey(battleMechDesign.Id))
                BattleMechDesigns.Add(battleMechDesign.Id, battleMechDesign);
        }


    }
}
