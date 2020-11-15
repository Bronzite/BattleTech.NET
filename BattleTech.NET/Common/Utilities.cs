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
            new string[] {"Medium Laser","MLaser","ISMediumLaser" },
            new string[] {"Small Laser","SLaser","ISSmallLaser" },
            new string[] {"Large Laser","LLaser","ISLargeLaser" },
            new string[] {"Medium Pulse Laser","MPLaser","ISMediumPulseLaser","CLMediumPulseLaser" },
            new string[] {"Small Pulse Laser","SPLaser","ISSmallPulseLaser","CLSmallPulseLaser" },
            new string[] {"Large Pulse Laser","LPLaser","ISLargePulseLaser","CLLargePulseLaser" },
            new string[] {"ER Medium Laser","ERMPLaser","ISERMediumLaser","CLERMediumLaser" },
            new string[] {"ER Small Laser","ERSLaser","ISERSmallLaser","CLERSmallLaser" },
            new string[] {"ER Large Laser","ERLLaser","ISERLargeLaser","CLERLargeLaser" },
            new string[] {"AC2","AC/2","Autocannon 2", "Autocannon/2","ISAC2" },
            new string[] {"AC5","AC/5","Autocannon 5", "Autocannon/5","ISAC5" },
            new string[] {"AC10","AC/10","Autocannon 10", "Autocannon/10","ISAC10" },
            new string[] {"AC20","AC/20","Autocannon 20", "Autocannon/20","ISAC20" },
            new string[] {"SRM 2","SRM/2","SRM2","ISSRM2","CLSRM2"},
            new string[] {"SRM 4","SRM/4","SRM4","ISSRM4","CLSRM4"},
            new string[] {"SRM 6","SRM/4","SRM6","ISSRM6","CLSRM6"},
            new string[] {"LRM 5","LRM/5","LRM5","ISLRM5","CLLRM5"},
            new string[] {"LRM 10","LRM/10","LRM10","ISLRM10","CLLRM10"},
            new string[] {"LRM 15","LRM/15","LRM15","ISLRM15","CLLRM15"},
            new string[] {"LRM 20","LRM/20","LRM20","ISLRM20","CLLRM20"},
            new string[] {"Machine Gun","MGun","MG", "ISMachine Gun","ISMG"},
            new string[] {"Endo Steel", "Endo Steel (I.S.)", "Endo Steel (Clan)", "IS Endo Steel", "IS Endo-Steel", "Endo-Steel","Clan Endo Steel","Endo Steel Prototype" },
            new string[] {"TSM","Triple-Strength","Triple-Strength Myomer","Triple Strength Myomer"},
            new string[] {"MASC","ISMASC"},
            new string[] {"MASC (Clan)","CLMASC"},
            new string[] {"Standard","IS Standard","Clan Standard"},
            new string[] { "Extra-Light Gyro","XL Gyro","XL" },
            new string[] { "Heavy Duty Gyro","Heavy-Duty Gyro" },
            new string[] {"PPC","Particle Cannon", "ISPPC"},
            new string[] {"ER PPC","ER Particle Cannon", "ISERPPC","CLERPPC"},
            new string[] {"Snub-Nose PPC","ISSNPPC"},
            new string[] {"UAC2","Ultra AC/2","Ultra Autocannon 2", "Ultra Autocannon/2","CLUltraAC2","ISUltraAC2" },
            new string[] {"UAC5", "Ultra AC/5", "Ultra Autocannon 5", "Ultra Autocannon/5","CLUltraAC5","ISUltraAC5" },
            new string[] {"UAC10", "Ultra AC/10", "Ultra Autocannon 10", "Ultra Autocannon/10","CLUltraAC10","ISUltraAC10" },
            new string[] {"UAC20", "Ultra AC/20", "Ultra Autocannon 20", "Ultra Autocannon/20","CLUltraAC20","ISUltraAC20" },
            new string[] {"Standard","Fusion","Fusion (IS)","Fusion (Clan)" },
            new string[] {"XL","Extra-Light","XL (IS)","XL (Clan)", "XL (Clan) (IS)", "XL Fusion" },
            new string[] {"Light", "Light (IS)", "Light (Clan)", "Light Fusion" },
            new string[] {"Compact","Compact Fusion","Compact (IS)","Compact (Clan)" },
            new string[] { "Ferro-Fibrous(Inner Sphere)", "Ferro-Fibrous (I.S.)","Ferro (I.S.)","Ferro-Fibrous","Ferro-Fibrous (I.S.)" },
            new string[] { "Ferro-Fibrous(Clan)", "Ferro-Fibrous (Clan)","Ferro (Clan)","Ferro-Fibrous" },
            new string[] { "Light Ferro-Fibrous(Inner Sphere)", "Light Ferro-Fibrous" },
            new string[] { "CASE","ISCASE","ClanCASE" },
            new string[] {"LRM 5 + Artemis IV","LRM/5 + Artemis IV","LRM5 + Artemis IV"},
            new string[] { "Collapsible Command Module", "ISCollapsibleCommandModule" },
            new string[] { "Electronic Warfare Equipment","ISElectronicWarfareEquipment" },
            new string[] { "Guardian ECM","ISGuardianECM","Guardian ECM Suite","ISGuardianECMSuite" },
            new string[] {"ECM Suite", "CLECMSuite" },
            new string[] { "Beagle Active Probe","ISBeagleActiveProbe" },
            new string[] { "ISArtemisIV", "Artemis IV","CLArtemisIV"},
            new string[] { "ClanArtemisV","Artemis V" },
            new string[] { "IS Machine Gun Ammo - Half", "IS Machine Gun - Half","Clan Machine Gun Ammo - Half","Clan Light Machine Gun Ammo - Half" },
            new string[] { "LB 2-X AC","ISLBXAC2" },
            new string[] { "LB 5-X AC","ISLBXAC5" },
            new string[] { "LB 10-X AC","ISLBXAC10" },
            new string[] { "LB 20-X AC","ISLBXAC20" },
            new string[] {"LAC2","LAC/2","Light Autocannon 2", "Light Autocannon/2","ISLAC2","Light Auto Cannon/2" },
            new string[] {"LAC5","LAC/5","Light Autocannon 5", "Light Autocannon/5","ISLAC5","Light Auto Cannon/5" },
            new string[] {"Heavy PPC","ISHeavyPPC" },
            new string[] {"Light PPC","ISLightPPC" },
            new string[] {"ISTAG","TAG" },
            new string[] {"Clan TAG","TAG" },
            new string[] { "Gauss Rifle","ISGaussRifle" },
            new string[] { "Light Gauss Rifle","ISLightGaussRifle" },
            new string[] { "Heavy Gauss Rifle","ISHeavyGaussRifle" },
            new string[] {"Anti-Missile System","ISAntiMissileSystem","AMS","CLAntiMissileSystem" },
            new string[] {"C3 Computer Master","ISC3MasterComputer","C3 Master with TAG" },
            new string[] {"C3 Computer Slave","ISC3SlaveUnit" },
            new string[] {"Streak SRM 2","ISStreakSRM2","CLStreakSRM2" },
            new string[] {"Streak SRM 4","ISStreakSRM4","CLStreakSRM4" },
            new string[] {"Streak SRM 6","ISStreakSRM6","CLStreakSRM6" },
            new string[] { "Hyper-Assault Gauss 40","HAG/40" },
            new string[] { "Hyper-Assault Gauss 30","HAG/30" },
            new string[] { "Hyper-Assault Gauss 20","HAG/20" },
            new string[] { "Rocket Launcher 10" ,"ISRocketLauncher10"},
            new string[] { "Rocket Launcher 15" ,"ISRocketLauncher15"},
            new string[] { "Rocket Launcher 20" ,"ISRocketLauncher20"},
            new string[] { "Arrow IV Missile","ISArrowIVSystem" },
            new string[] { "Improved C3 Computer","ISImprovedC3CPU" },
            new string[] { "Machine Gun Array","ISMGA", "ISLMGA", "Light Machine Gun Array","Heavy Machine Gun Array" },
            new string[] {"MML 3","ISMML3"},
            new string[] {"MML 5","ISMML5"},
            new string[] {"MML 7","ISMML7"},
            new string[] {"MML 9","ISMML9"},
            new string[] {"Plasma Rifle","ISPlasmaRifle"},
            new string[] {"MRM 10", "ISMRM10"},
            new string[] {"MRM 20", "ISMRM20"},
            new string[] {"MRM 30", "ISMRM30"},
            new string[] {"MRM 40", "ISMRM40"},
            new string[] {"Rotary AC/2", "ISRotaryAC2"},
            new string[] {"Rotary AC/5", "ISRotaryAC5"},
            new string[] { "LB 2-X AC","CLLBXAC2" },
            new string[] { "LB 5-X AC","CLLBXAC5" },
            new string[] { "LB 10-X AC","CLLBXAC10" },
            new string[] { "LB 20-X AC","CLLBXAC20" },
            new string[] { "Narc Missile Beacon","Narc","ISNarcBeacon" },
            new string[] { "Improved Narc Launcher","ISImprovedNarc" },
            new string[] { "Flamer","ISFlamer" },
            new string[] { "Light Machine Gun","ISLightMG" },
            new string[] { "SRM 2 (OS)","ISSRM2 (OS)" },
            new string[] { "SRM 4 (OS)","ISSRM4 (OS)" },
            new string[] { "SRM 6 (OS)","ISSRM6 (OS)" },
            new string[] { "Targeting Computer","ISTargeting Computer","CLTargeting Computer","CLTargeting Computer"},
            new string[] { "CLAntiPersonnelPod","A-Pod","A-Pods","CLAntiPersonnelPod" },
            new string[] {"Active Probe","CLActiveProbe"},
            new string[] {"Light Active Probe","CLLightActiveProbe"},


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
    }
}
