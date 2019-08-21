using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.StrategicBattleForce
{
    public class Formation:IGameObject
    {
        private Guid mID;
        public Guid ID { get { return mID; } set { mID = value; } }

        private string mName;
        public string Name { get { return mName; } set { mName = value; } }

        
    }
}
