using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Data
{
    /// <summary>
    /// This interface is intended to serve as a general interface to
    /// various libraries that might store reference data that is used to
    /// construct other objects such as Mech Designs, Weapons, etc.
    /// </summary>
    public interface ILibrary
    {
        /// <summary>
        /// Get a list of all BattleMech Designs available in this library,
        /// returned as a Dictionary of GUIDs and Names.
        /// </summary>
        /// <returns></returns>
        IDictionary<Guid,string> ListBattleMechDesigns();

        /// <summary>
        /// Return a BattleMech Design from this Library.
        /// </summary>
        /// <param name="Id">The Id propery of the BattleMech Design to be returned.</param>
        /// <returns></returns>
        BattleMechDesign GetBattleMechDesign(Guid Id);

        /// <summary>
        /// Store a BattleMech Design in this library.
        /// </summary>
        /// <param name="battleMechDesign">BattleMechDesign object to store.</param>
        void StoreBattleMechDesign(BattleMechDesign battleMechDesign);
        
    }
}
