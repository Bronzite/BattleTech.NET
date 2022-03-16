using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.Common
{
    public class MovementMode:ICloneable
    {
        private string[] mValidCodes = {
            "bm", //Default ground-based movement/Battlemech Movement
            "j", //Infantry Jump (SO219,AS31)
            "h", //Vehicle Hover (SO217, AS31)
            "n", //Vehicle Naval (SO217, AS31)
            "s", //Vehicle Submersible (SO217, AS31)
            "r", //Rail (SO355)
            "t", //Vehicle/Mechanized Infantry Tracked (SO217, SO219, AS31)
            "v", //Vehicle/Battle Armor VTOL (SO217, AS31)
            "w", //Vehicle/Mechanized Infantry Wheeled (SO217, SO219, AS31)
            "g", //Vehicle WiGE (SO217, AS31)
            "f", //Infantry Foot (SO219, AS31)
            "h", //Vehicle/Mechanized Infantry Hover (SO217, SO219, AS31)
            "k", //Stationkeeping (SO355)
            "i", //Airship Aerospace (SO220)
            "a", //Aerodyne Aerospace (SO220)
            "p", //Spheroid Aerospace (SO220)
            "w(b)", //Vehicle Wheeled (Bicycle) (SO217, AS31)
            "w(m)", //Vehicle Wheeled (Motorcycle) (SO217, AS31)
            "m", //Infantry Motorized (SO217, AS31)
            "u" //Underwater Movement Unit (SO355)
        };


        public MovementMode (int iPoints, string sCode) { Points = iPoints; Code = sCode; }

        public int Points { get; set; }

        private string mCode = "";
        public string Code {
            get { return mCode; }
            set
            {
                string sCode = mCode;
                if (sCode == "") sCode = "bm";
                if (mValidCodes.Contains(sCode.ToLower()))
                    mCode = sCode.ToLower();
                else
                    throw new Exception(string.Format("Unknown Movement Type Code: {0}", sCode));
            }
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", Points, Code);
        }

        public object Clone()
        {
            return new MovementMode(Points,Code);
        }
    }
}
