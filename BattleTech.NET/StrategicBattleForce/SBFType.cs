using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.StrategicBattleForce
{
    public class SBFType
    {
        
        public string Description { get; set; }

        public string Code { get; set; }

        public bool AeroType { get; set; }

        public static SBFType GetAggregateUnitType(Dictionary<string,int> dicCodes)
        {

            bool bLargeAerospace = false;
            string sMostPopularCode = "MX";
            int iMostPopularCount = 0;
            int iTotalCount = 0;
            foreach(string sCode in dicCodes.Keys)
            {
                SBFType sbfType = GetCanonicalTypeByCode(sCode);
                if (sCode.Equals("LA")) bLargeAerospace = true;
                if(dicCodes[sCode] > iMostPopularCount)
                {
                    sMostPopularCode = sCode;
                    iMostPopularCount = dicCodes[sCode];
                }
                iTotalCount += dicCodes[sCode];
            }

            string sSelectedCode = "MX";
            if (bLargeAerospace) sSelectedCode = "LA";
            if ((double)iMostPopularCount >= (double)(2 * iTotalCount) / 3D)
                sSelectedCode = sMostPopularCode;

            return GetCanonicalTypeByCode(sSelectedCode);
        }

        public static SBFType GetCanonicalTypeByCode(string sCode)
        {
            List<SBFType> types = GetCanonicalTypes();
            foreach(SBFType t in types)
            {
                if(t.Code.Equals(sCode,StringComparison.CurrentCultureIgnoreCase))
                {
                    return t;
                }
            }
            throw new Exception($"No SBF Type {sCode}.");
        }

        public static List<SBFType> GetCanonicalTypes()
        {
            List<SBFType> retval = new List<SBFType>();

            retval.Add(new SBFType() { Description = "Aerospace", Code = "AS", AeroType = true });
            retval.Add(new SBFType() { Description = "Large Aerospace", Code = "LA", AeroType = true });
            retval.Add(new SBFType() { Description = "BattleMechs", Code = "BM", AeroType = false });
            retval.Add(new SBFType() { Description = "ProtoMech", Code = "PM", AeroType = false });
            retval.Add(new SBFType() { Description = "Conventional Infantry", Code = "CI", AeroType = false });
            retval.Add(new SBFType() { Description = "Battle Armor", Code = "BA", AeroType = false });
            retval.Add(new SBFType() { Description = "Vehicles", Code = "V", AeroType = false });
            retval.Add(new SBFType() { Description = "Mobile Structures", Code = "MS", AeroType = false });
            retval.Add(new SBFType() { Description = "Mixed Ground", Code = "MX", AeroType = false });

            return retval;
        }
    }
}
