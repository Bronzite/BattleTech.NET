using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.AbstractCombatSystem
{
    public class CombatUnit:IGameObject 
    {

        public Guid ID { get; set; }

        public string Name { get; set; }

        public int NoSupplyCount { get; set; }


    }
}
