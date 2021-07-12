using BattleTechNET.Common;
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
    public class ArmorType:IAliasable, ITechBase
    {
        public ArmorType():this("Standard",TECHNOLOGY_BASE.BOTH, 16,0) { }
        public ArmorType(string sName, TECHNOLOGY_BASE tb, double dPointsPerTons) : this(sName, tb, dPointsPerTons, 0) { }
        public ArmorType(string sName, TECHNOLOGY_BASE tb, double dPointsPerTons, int iCriticalSlotsRequired) : this(sName, tb, dPointsPerTons, iCriticalSlotsRequired, 1) { }
        public ArmorType(string sName, TECHNOLOGY_BASE tb, double dPointsPerTons, int iCriticalSlotsRequired,double dBattleValueModifier) { Name = sName; PointsPerTon = dPointsPerTons; CriticalSlotsRequired = iCriticalSlotsRequired; TechnologyBase = tb; AliasList = new List<string>(); BattleValueModifier = dBattleValueModifier; }
        public string Name { get; set; }
        public TECHNOLOGY_BASE TechnologyBase { get; set; }
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
            //TODO: Verify Technology Bases on Armors
            retval.Add(new ArmorType("Standard", TECHNOLOGY_BASE.BOTH, 16)
                .AddAlias("Standard(Inner Sphere)") as ArmorType);                      //TM56
            retval.Add(new ArmorType("Heavy Industrial", TECHNOLOGY_BASE.BOTH, 16));              //TM56
            retval.Add(new ArmorType("Stealth", TECHNOLOGY_BASE.INNERSPHERE, 16, 12));                   //TM56
            retval.Add(new ArmorType("Prototype Ferro-Fibrous", TECHNOLOGY_BASE.INNERSPHERE, 16 * 1.12, 9)
                .AddAlias("Ferro-Fibrous Prototype(Inner Sphere)") as ArmorType);    //IO72
            retval.Add(new ArmorType("Light Ferro-Fibrous", TECHNOLOGY_BASE.INNERSPHERE, 16*1.06,7)
                .AddAlias("Light Ferro-Fibrous(Inner Sphere)") as ArmorType);    //TM56
            retval.Add(new ArmorType("Ferro-Fibrous (I.S.)", TECHNOLOGY_BASE.INNERSPHERE, 16 * 1.12, 14)
                .AddAlias("Ferro-Fibrous")
                .AddAlias("Ferro-Fibrous(Inner Sphere)")
                .AddAlias("Ferro (Inner Sphere)")
                .AddAlias("Ferro (I.S.)")
                as ArmorType); //TM56
            retval.Add(new ArmorType("Ferro-Fibrous (Clan)", TECHNOLOGY_BASE.CLAN, 16 * 1.2, 7)
                .AddAlias("Ferro-Fibrous")
                .AddAlias("Ferro (Clan)")
                .AddAlias("Ferro-Fibrous(Clan)")
                as ArmorType);     //TM56
            retval.Add(new ArmorType("Heavy Ferro-Fibrous", TECHNOLOGY_BASE.INNERSPHERE, 16 * 1.24, 21));    //TM56
            retval.Add(new ArmorType("Ferro-Lemellor", TECHNOLOGY_BASE.BOTH, 14,2));    //TO280
            retval.Add(new ArmorType("Hardened", TECHNOLOGY_BASE.BOTH, 8, 2));    //TO280
            retval.Add(new ArmorType("Laser-Reflective (I.S.)", TECHNOLOGY_BASE.INNERSPHERE, 16, 10));    //TO280
            retval.Add(new ArmorType("Laser-Reflective (Clan)", TECHNOLOGY_BASE.CLAN, 16, 5));    //TO280
            retval.Add(new ArmorType("Modular", TECHNOLOGY_BASE.BOTH, 10, 1));    //TO280
            retval.Add(new ArmorType("Reactive (I.S.)", TECHNOLOGY_BASE.INNERSPHERE, 16, 14));    //TO280
            retval.Add(new ArmorType("Reactive (Clan)", TECHNOLOGY_BASE.CLAN, 16, 7));    //TO280
            retval.Add(new ArmorType("Vehicle Stealth", TECHNOLOGY_BASE.BOTH, 16, 7));    //TO280

            return retval;
        }
        public double BattleValueModifier { get; set; }
        private List<string> AliasList { get; set; }
        public IEnumerable<string> Aliases { get { return AliasList; } }
        public IAliasable AddAlias(string sAliasable) { AliasList.Add(sAliasable); return this; }
        public IAliasable AddAlias(IEnumerable<string> ieAliasable)
        {
            foreach (string s in ieAliasable)
                AliasList.Add(s);
            return this;
        }
        public IAliasable ClearAliasList() { AliasList.Clear(); return this; }
    }
}
