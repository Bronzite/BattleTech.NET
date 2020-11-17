using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    public interface IAliasable
    {
        string Name { get; }
        IEnumerable<string> Aliases { get; }
        IAliasable AddAlias(string sAliasable);
        IAliasable AddAlias(IEnumerable<string> sAliases);
        IAliasable ClearAliasList();
    }
}
