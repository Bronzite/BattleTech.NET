using BattleTechNET.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.TotalWarfare
{
    public class StructureType:ICloneable,ITechBase,IAliasable
    {
        public StructureType() : this("Standard", TECHNOLOGY_BASE.BOTH , 0.1, 0, 1, false,1) { }
        public StructureType(string sName, TECHNOLOGY_BASE eTechnologyBase, double dTonnageMultipler, int iCriticalHitSlots, double dDamageMultiplier, bool bCriticalLocationsTreatedAsRollAgain) : this(sName, eTechnologyBase, dTonnageMultipler, iCriticalHitSlots, dDamageMultiplier, bCriticalLocationsTreatedAsRollAgain, 1.0) { }
        public StructureType(string sName, TECHNOLOGY_BASE eTechnologyBase, double dTonnageMultipler, int iCriticalHitSlots, double dDamageMultiplier, bool bCriticalLocationsTreatedAsRollAgain, double dBattleValueModifier)
        {
            Name = sName;
            TechnologyBase = eTechnologyBase;
            TonnageMultipler = dTonnageMultipler;
            CriticalHitSlots = iCriticalHitSlots;
            DamageMultiplier = dDamageMultiplier;
            CriticalLocationsTreatedAsRollAgain = bCriticalLocationsTreatedAsRollAgain;
            BattleValueModifier = dBattleValueModifier;
            AliasList = new List<string>();
        }

        public string Name { get; set; }
        /// <summary>
        /// Property for Composite and Reinforced Structures (TO342)
        /// </summary>
        public double DamageMultiplier { get; set; }
        /// <summary>
        /// Structure weight is always linear, so you can multiply tonnage by
        /// this value and round to the nearest half-ton. (TM47)
        /// </summary>
        public double TonnageMultipler { get; set; }
        /// <summary>
        /// The number of critical hit slots that must be allocated to this 
        /// structure type.
        /// </summary>
        public int CriticalHitSlots { get; set; }
        /// <summary>
        /// If this value is true, critical hits to locations using this type
        /// of structure are treated as Roll Again results.  (TO342)
        /// </summary>
        public bool CriticalLocationsTreatedAsRollAgain { get; set; }
        /// <summary>
        /// The modifier applied to the Structure component of the BV2
        /// calculation.
        /// </summary>
        public double BattleValueModifier { get; set; }
        public TECHNOLOGY_BASE TechnologyBase { get; set; }
        public static List<StructureType> GetCanonicalStructureTypes()
        {
            List<StructureType> retval = new List<StructureType>();

            retval.Add(new StructureType()
                .AddAlias("IS Standard")
                .AddAlias("Clan Standard") as StructureType); //Standard Structure TM47

            retval.Add(new StructureType("Industrial", TECHNOLOGY_BASE.BOTH, 0.2, 0, 1, false)
                .AddAlias("Clan Industrial")
                .AddAlias("IS Industrial") as StructureType); //TM47
            retval.Add(new StructureType("Endo Steel (I.S.)", TECHNOLOGY_BASE.INNERSPHERE, 0.05, 14, 1, false)
                .AddAlias("Endo Steel")
                .AddAlias("IS Endo-Steel")
                .AddAlias("Endo-Steel")
                
                .AddAlias("IS Endo Steel") as StructureType); //TM47
            retval.Add(new StructureType("Endo Steel (Clan)", TECHNOLOGY_BASE.CLAN, 0.05, 7, 1, false)
                .AddAlias("Endo Steel")
                .AddAlias("Clan Endo-Steel")
                .AddAlias("Endo-Steel")

                .AddAlias("Clan Endo Steel")
                .AddAlias("Clan Endo Steel") as StructureType);//TM47

            retval.Add(new StructureType("Endo Steel Prototype (Clan)", TECHNOLOGY_BASE.CLAN, 0.05, 9, 1, false)
                .AddAlias("Endo Steel Prototype")
                .AddAlias("Clan Endo-Steel Prototype")
                as StructureType);//TM47
            retval.Add(new StructureType("Endo Steel Prototype (IS)", TECHNOLOGY_BASE.INNERSPHERE, 0.05, 16, 1, false)
                .AddAlias("Endo Steel Prototype")
                .AddAlias("IS Endo-Steel Prototype")
                as StructureType);//TM47
            retval.Add(new StructureType("Composite", TECHNOLOGY_BASE.INNERSPHERE, 0.05, 0, 2, false)
                .AddAlias("IS Composite") as StructureType); //TO342
            retval.Add(new StructureType("Endo-Composite (I.S.)", TECHNOLOGY_BASE.INNERSPHERE, 0.075, 7, 1, true)
                .AddAlias("Endo-Composite")
                .AddAlias("IS Endo-Composite") as StructureType); //TO342
            retval.Add(new StructureType("Endo-Composite (Clan)", TECHNOLOGY_BASE.CLAN, 0.075, 4, 1, true)
                .AddAlias("Endo-Composite")
                .AddAlias("Clan Endo-Composite") as StructureType); //TO342
            retval.Add(new StructureType("Reinforced", TECHNOLOGY_BASE.BOTH, 0.2, 0, 0.5, false)
                .AddAlias("Clan Reinforced")
                .AddAlias("IS Reinforced") as StructureType); //TO343

            return retval;
        }

        public object Clone()
        {
            return new StructureType(Name, TechnologyBase, TonnageMultipler, CriticalHitSlots, DamageMultiplier, CriticalLocationsTreatedAsRollAgain);
        }
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
