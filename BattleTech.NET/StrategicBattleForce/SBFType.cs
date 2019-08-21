using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.StrategicBattleForce
{
    public class SBFType
    {
        private string mDescription;
        public string Description { get { return mDescription; } set { mDescription = value; } }

        private string mCode;
        public string Code { get { return mCode; } set { mCode = value; } }

        private bool mAeroType;
        public bool AeroType { get { return mAeroType; } set { mAeroType = value; } }
        
    }
}
