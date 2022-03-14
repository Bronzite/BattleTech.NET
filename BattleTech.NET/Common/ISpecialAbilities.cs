using BattleTechNET.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    public interface ISpecialAbilities
    {
        IList<SpecialAbility> SpecialAbilities { get; set; }

        bool HasSpecialAbility(string sCode);

        bool HasSpecialAbility(string sCode, bool bIncludeChildren);

        SpecialAbility GetSpecialAbility(string sCode);
        List<SpecialAbility> GetSpecialAbilities(string sCode);
    }
}
