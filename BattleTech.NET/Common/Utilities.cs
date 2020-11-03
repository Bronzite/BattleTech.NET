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
        //file to be desitrbuted with it.

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
            new string[] {"AC2","AC/2","Autocannon 2", "Autocannon/2" },
            new string[] {"AC5","AC/5","Autocannon 5", "Autocannon/5" },
            new string[] {"AC10","AC/10","Autocannon 10", "Autocannon/10" },
            new string[] {"AC20","AC/20","Autocannon 20", "Autocannon/20" },
            new string[] {"SRM 2","SRM/2","SRM2"},
            new string[] {"SRM 4","SRM/4","SRM4"},
            new string[] {"SRM 6","SRM/4","SRM6"},
            new string[] {"LRM 5","LRM/5","LRM5"},
            new string[] {"LRM 10","LRM/10","LRM10"},
            new string[] {"LRM 15","LRM/15","LRM15"},
            new string[] {"LRM 20","LRM/20","LRM20"},
            new string[] {"Machine Gun","MGun","MG"},
            new string[] {"Endo Steel", "Endo Steel (I.S.)", "Endo Steel (Clan)" },
            new string[] {"TSM","Triple-Strength","Triple-Strength Myomer"},
            new string[] {"Standard","IS Standard","Clan Standard"},
            new string[] {"PPC","Particle Cannon"},
            new string[] {"UAC2","Ultra AC/2","Ultra Autocannon 2", "Ultra Autocannon/2" },
            new string[] {"UAC5", "Ultra AC/5", "Ultra Autocannon 5", "Ultra Autocannon/5" },
            new string[] {"UAC10", "Ultra AC/10", "Ultra Autocannon 10", "Ultra Autocannon/10" },
            new string[] {"UAC20", "Ultra AC/20", "Ultra Autocannon 20", "Ultra Autocannon/20" },
            new string[] {"Standard","Fusion","Fusion (IS)","Fusion (Clan)" },
            new string[] {"XL","Extra-Light","XL (IS)","XL (Clan)" },




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
            for (int i = 0; i < sSynonyms.GetLength(0); i++)
            {
                if ((sSynonyms[i].Contains(a)) && (sSynonyms[i].Contains(b)))
                    return true;
            }
            return false;
        }
    }
}
