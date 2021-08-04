using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleTechNET.Common
{
    public class Utilities
    {
        //NOTE: I really want to read this array from a file, but I don't think
        //the usability of this library is as great if it requires a lookup
        //file to be distributed with it.

        private static string[][] sSynonyms = new string[][]
        {
            new string[] {"LA","Left Arm" },
            new string[] {"RA","Right Arm" },
            new string[] {"LL","Left Leg" },
            new string[] {"RL","Right Leg" },
            new string[] {"FLL","Front Left Leg" },
            new string[] {"FRL","Front Right Leg" },
            new string[] {"RLL","Rear Left Leg" },
            new string[] {"RRL","Rear Right Leg" },
            new string[] {"RT","Right Torso" },
            new string[] {"LT","Left Torso" },
            new string[] {"CT","Center Torso" },
            new string[] {"HD","Head" },

            
            new string[] {"Endo Steel", "Endo Steel (I.S.)", "Endo Steel (Clan)", "IS Endo Steel", "IS Endo-Steel", "Endo-Steel","Clan Endo Steel","Endo Steel Prototype" },
            new string[] {"TSM","Triple-Strength","Triple-Strength Myomer","Triple Strength Myomer"},
            new string[] {"MASC","ISMASC"},
            new string[] {"MASC (Clan)","CLMASC"},
            new string[] {"Standard","IS Standard","Clan Standard"},
            new string[] { "Extra-Light Gyro","XL Gyro","XL" },
            new string[] { "Heavy Duty Gyro","Heavy-Duty Gyro" },




            new string[] {"ICE","I.C.E","I.C.E.","ICE (IS)" },
            new string[] {"Standard","Fusion","Fusion (IS)","Fusion (Clan)", "Fusion  (Clan)","Fusion (Clan) (IS)" },
            new string[] {"XL","Extra-Light","XL (IS)","XL (Clan)", "XL (Clan) (IS)", "XL Fusion","XL  (Inner Sphere)", "XL Fusion  (Clan)" },
            new string[] {"XXL", "XXL (IS)", "XXL (Clan)", "XXL (Clan) (IS)","XXL Fusion" },
            new string[] {"Light", "Light (IS)", "Light (Clan)", "Light Fusion" },
            new string[] {"Compact","Compact Fusion","Compact (IS)","Compact (Clan)" },
            new string[] {"Fuel Cell","Fuel Cell (IS)","Cell","Fuel-Cell" },
            new string[] {"Fission", "Fission (IS)", "Fission (Clan)"},


            new string[] { "CASE","ISCASE","ClanCASE" },
            new string[] { "Collapsible Command Module", "ISCollapsibleCommandModule" },
            
            
            
            
            new string[] { "ISArtemisIV", "Artemis IV","CLArtemisIV"},
            new string[] { "ClanArtemisV","Artemis V" },



            new string[] { "Targeting Computer","ISTargeting Computer","CLTargeting Computer","CLTargeting Computer"},
            

        };


        /// <summary>
        /// This function exists because interoperating with multiple sources
        /// and standards frequently results in the same concept being spelled
        /// in a few different ways.  For example, LA and Left Arm are both
        /// used in regular text and in technical files such as MTF's.  This
        /// function provides a canonical way to assess if two strings are
        /// likely referring to the same thing.
        /// </summary>
        static public bool IsSynonymFor(string a, string b)
        {
            if (a.Equals(b)) return true;
            for (int i = 0; i < sSynonyms.GetLength(0); i++)
            {
                if ((sSynonyms[i].Contains(a)) && (sSynonyms[i].Contains(b)))
                    return true;
            }
            return false;
        }

        static public bool IsSynonymFor(string sAlias, IAliasable oAliasable) { return IsSynonymFor(oAliasable, sAlias); }
        static public bool IsSynonymFor(IAliasable oAliasable, string sAlias)
        {
            if (sAlias.Equals(oAliasable.Name, StringComparison.CurrentCultureIgnoreCase)) return true;
            foreach(string sA in oAliasable.Aliases)
            {
                if(sAlias.Equals(sA,StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        static public bool LocationHasCASE(BattleMechHitLocation hitLocation)
        {
            foreach (CriticalSlot slot in hitLocation.CriticalSlots)
            {
                if (slot.AffectedComponent != null)
                {
                    ComponentCASE caseComponent = slot.AffectedComponent.Component as ComponentCASE;
                    if (caseComponent != null) return true;
                }
            }
            return false;
        }

        public static int MaxmiumDefensiveModifier(BattleMechDesign design)
        {
            //TODO: Need to add calculations for MASC, TSM, and Stealth
            //Armor TM315
            double WalkDistance = Math.Truncate(design.Engine.EngineRating / design.Tonnage);
            double RunDistance = Math.Round(WalkDistance * 1.5D, 0,MidpointRounding.AwayFromZero);
            int iRunModifier = BattleTechNET.TotalWarfare.CombatRules.TargetMovementModifier(RunDistance);
            int iJumpModifier = BattleTechNET.TotalWarfare.CombatRules.TargetMovementModifier((double)design.JumpMP);// + 1;


            return (Math.Max(iRunModifier, iJumpModifier));
        }
    }
}
