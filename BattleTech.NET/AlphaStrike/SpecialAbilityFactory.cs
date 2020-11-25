using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.AlphaStrike
{
    static class SpecialAbilityFactory
    {
        static public SpecialAbility CreateSpecialAbility(string sCode)
        {
            SpecialAbility retval = null;

            char[] cChars = sCode.ToCharArray();
            string sSACode = "";
            string sVector = "";
            bool bVector = false;
            for(int i = 0;i<cChars.Length;i++)
            {
                if(!bVector)
                if (char.IsLetter(cChars[i]))
                    sSACode += cChars[i];
                else
                    bVector = true;

                if (bVector)
                    sVector += cChars[i];

            }
            string[] sVectorValues = sVector.Split('/');
            if (bVector)
            {
                List<int> lstVectorValues = new List<int>();
                foreach(string s in sVectorValues)
                {
                    int iParseTry = 0;
                    if (int.TryParse(s, out iParseTry))
                        lstVectorValues.Add(iParseTry);

                    retval = new SpecialAbilityVector(sSACode, lstVectorValues);
                }
            }
            else
            {
                retval = new SpecialAbility();
                retval.Code = sSACode;
            }
            return retval;
        }

    }
}
