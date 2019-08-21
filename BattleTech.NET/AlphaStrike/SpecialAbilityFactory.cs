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
            SpecialAbility retval = new SpecialAbility();

            char[] cChars = sCode.ToCharArray();
            string sSACode = "";
            for(int i = 0;i<cChars.Length;i++)
            {
                if (char.IsLetter(cChars[i]))
                    sSACode += cChars[i];
                else
                    break;
            }

            retval.Code = sSACode;

            return retval;
        }

    }
}
