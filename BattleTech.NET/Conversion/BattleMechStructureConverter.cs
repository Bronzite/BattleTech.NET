using BattleTechNET.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Conversion
{
    public static class BattleMechStructureConverter
    {
        static private Dictionary<string, int[]> ISStructureLookup = new Dictionary<string, int[]>()
        {
            {"Compact",     new int[] {1,2,2,3,3,4,4,5,5,6,7,7,7,8,8,9,10,10,10} },
            {"Fusion",      new int[] {1,1,2,2,3,3,3,4,4,5,5,5,6,6,6,7,7,8,8} },
            {"Large Fusion",new int[] {1,1,1,2,2,2,2,3,3,4,4,4,4,5,5,5,6,6,6} },
            {"Light Fusion",new int[] {1,1,1,1,2,2,2,2,3,3,3,4,4,4,4,5,5,5,5} },
            {"XL Fusion",   new int[] {1,1,1,1,1,2,2,2,2,3,3,3,3,3,4,4,4,4,4} },
            {"Large XL Fusion",   new int[] {1,1,1,1,1,1,2,2,2,2,3,3,3,3,3,4,4,4} },
            {"Large XXL Fusion",   new int[] {1,1,1,1,1,1,1,1,2,2,2,2,2,2,3,3,3,3,3} }

        };

        static private Dictionary<string, int[]> ClanStructureLookup = new Dictionary<string, int[]>()
        {
            {"XL Fusion",        new int[] {1,1,1,1,2,2,2,2,3,3,3,4,4,4,4,5,5,5,5} },
            {"Large XL Fusion",  new int[] {1,1,1,1,1,2,2,2,2,3,3,3,3,3,4,4,4,4,4} },
            {"XXL Fusion",       new int[] {1,1,1,1,1,1,1,1,2,2,2,2,2,2,3,3,3,3,3} },
            {"Large XXL Fusion", new int[] {1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,3,3,3} }

        };

        /// <summary>
        /// Encoding of the 'Mech Structure Conversion table
        /// on SO359.
        /// </summary>
        /// <param name="sEngineType"></param>
        /// <param name="MechTonnage"></param>
        /// <returns></returns>
        static public int GetStructure(ComponentEngine engine, int MechTonnage)
        {
            Dictionary<string, int[]> dicTechnologyBase = null;
            if (engine.TechnologyBase == TECHNOLOGY_BASE.CLAN)
                dicTechnologyBase = ClanStructureLookup;
            else
                dicTechnologyBase = ISStructureLookup;

            foreach(string sEngineType in dicTechnologyBase.Keys)
                if(Utilities.IsSynonymFor(sEngineType,engine.EngineType))
                {
                    return dicTechnologyBase[sEngineType][(int)((MechTonnage - 10) / 5)];
                }
            
            return 0;
        }

    }
}
