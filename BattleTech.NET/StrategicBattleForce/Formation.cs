using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.StrategicBattleForce
{
    public class Formation:IGameObject
    {
        
        public Guid Id { get; set; }

        private string mName;
        public string Name { get { return mName; } set { mName = value; } }

        
    }
}
