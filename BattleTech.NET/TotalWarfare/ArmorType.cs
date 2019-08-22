using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.TotalWarfare
{
    /// <summary>
    /// Object for storing data about an Armor Type.
    /// TODO: There's more data encoded on TO280, especially regarding Critical
    /// slots.  We need to expand this class to cover them, and possible make
    /// derived classes for some subtypes.
    /// </summary>
    public class ArmorType
    {
        public ArmorType():this("Standard",16,0) { }
        public ArmorType(string sName, double dPointsPerTons) : this(sName, dPointsPerTons, 0) { }
        public ArmorType(string sName, double dPointsPerTons, int iCriticalSlotsRequired) { Name = sName; PointsPerTon = dPointsPerTons; CriticalSlotsRequired = iCriticalSlotsRequired; }
        public string Name { get; set; }
        public double PointsPerTon { get; set; }
        /// <summary>
        /// This is the number of critical slots a Mech must dedicate to having
        /// this kind of armor.  Needs to be expanded to allow for TacOps armor
        /// types that use specific armor locations.
        /// </summary>
        public int CriticalSlotsRequired { get; set; }

        /// <summary>
        /// Return Armor Types listed in core rulebooks.
        /// </summary>
        /// <returns>A list of Armor Types from TM and TO</returns>
        public static List<ArmorType> CanonicalArmorTypes()
        {
            List<ArmorType> retval = new List<ArmorType>();

            retval.Add(new ArmorType("Standard", 16));                      //TM56
            retval.Add(new ArmorType("Heavy Industrial", 16));              //TM56
            retval.Add(new ArmorType("Stealth", 16, 12));                   //TM56
            retval.Add(new ArmorType("Light Ferro-Fibrous", 16*1.06,7));    //TM56
            retval.Add(new ArmorType("Ferro-Fibrous (I.S.)", 16 * 1.12, 14));   //TM56
            retval.Add(new ArmorType("Ferro-Fibrous (Clan)", 16 * 1.2, 7));     //TM56
            retval.Add(new ArmorType("Heavy Ferro-Fibrous", 16 * 1.24, 21));    //TM56
            retval.Add(new ArmorType("Ferro-Lemellor",14,2));    //TO280
            retval.Add(new ArmorType("Hardened", 8, 2));    //TO280
            retval.Add(new ArmorType("Laser-Reflective (I.S.)", 16, 10));    //TO280
            retval.Add(new ArmorType("Laser-Reflective (Clan)", 16, 5));    //TO280
            retval.Add(new ArmorType("Modular", 10, 1));    //TO280
            retval.Add(new ArmorType("Reactive (I.S.)", 16, 14));    //TO280
            retval.Add(new ArmorType("Reactive (Clan)", 16, 7));    //TO280
            retval.Add(new ArmorType("Vehicle Stealth", 16, 7));    //TO280

            return retval;
        }

    }
}
