using BattleTechNET.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.TotalWarfare
{
    public class MyomerType:ITechBase
    {
        public MyomerType() {
            Name = "Standard";
            MassFraction = 0;
            CriticalHitSlots = 0;
            TechnologyBase = Common.TECHNOLOGY_BASE.BOTH;
            HeatActivationThreshold = 0;
            BattleMechPhysicalAttackDamageMultipler = 0;
            BattleMechPhysicalAttackToHitModifier = 0;
            BattleMechPilotingRollModifier = 0;
            BattleMechWalkingMPIncrease = 0;
            MASCRollTrack = new int[0];
            MASCRunSpeedMultiplier = 1.5;
        }
        public MyomerType(string sName, TECHNOLOGY_BASE tBase, double dMassFraction, double dCriticalHitSlotsAsFractionOfMass, int iCriticalHitSlots):this() { Name = sName; TechnologyBase = tBase; MassFraction = dMassFraction; CriticalHitSlots = iCriticalHitSlots;CriticalHitSlotsAsFractionOfMass = dCriticalHitSlotsAsFractionOfMass; }
        public string Name { get; set; }
        public BattleTechNET.Common.TECHNOLOGY_BASE TechnologyBase { get; set; }
        public double MassFraction { get; set; }
        public int CriticalHitSlots { get; set; }
        public double CriticalHitSlotsAsFractionOfMass { get; set; }
        public int HeatActivationThreshold { get; set; }
        public int BattleMechWalkingMPIncrease { get; set; }
        public double BattleMechPhysicalAttackDamageMultipler { get; set; }
        public int BattleMechPhysicalAttackToHitModifier { get; set; }
        public int BattleMechPilotingRollModifier { get; set; }
        public int[] MASCRollTrack { get; set; }
        public double MASCRunSpeedMultiplier { get; set; }
        public static List<MyomerType> GetCanonicalMyomerTypes ()
        {
            List<MyomerType> retval = new List<MyomerType>();

            retval.Add(new MyomerType("Standard",TECHNOLOGY_BASE.BOTH, 0, 0, 0)); //TM52
            retval.Add(new MyomerType("MASC", TECHNOLOGY_BASE.INNERSPHERE, 0.05, 0.05, 0) { MASCRunSpeedMultiplier = 2,MASCRollTrack = new int[] { 3, 4, 6, 10, 13 } }) ; //TM52, TW137
            retval.Add(new MyomerType("MASC (Clan)", TECHNOLOGY_BASE.CLAN, 0.04, 0.04, 0) { MASCRunSpeedMultiplier= 2,MASCRollTrack = new int[] { 3, 4, 6, 10, 13 } } ); //TM52, TW137
            retval.Add(new MyomerType("TSM", TECHNOLOGY_BASE.INNERSPHERE, 0, 0, 6) { HeatActivationThreshold = 9, BattleMechWalkingMPIncrease = 2, BattleMechPhysicalAttackDamageMultipler = 2 }); //TM52, TW143
            retval.Add(new MyomerType("Industrial TSM", TECHNOLOGY_BASE.INNERSPHERE, 0, 0, 6) { BattleMechPilotingRollModifier = 1, BattleMechPhysicalAttackToHitModifier = 2 }); //TM240, TW143


            return retval;

        }

    }
}
