using BattleTechNET.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.TotalWarfare
{
    public class HitLocation:IAliasable
    {
        public HitLocation() { AliasList = new List<string>(); }
        public string Name { get; set; }
        public int Armor { get; set; }
        public int MaxArmor { get; set; }
        private List<string> AliasList { get; set; }
        public IEnumerable<string> Aliases { get { return AliasList; } }
        public IAliasable AddAlias(string sAliasable) { AliasList.Add(sAliasable); return this; }
        public IAliasable AddAlias(IEnumerable<string> ieAliasable)
        {
            foreach (string s in ieAliasable)
                AliasList.Add(s);
            return this;
        }
        public IAliasable ClearAliasList() { AliasList.Clear(); return this; }
    }
}
