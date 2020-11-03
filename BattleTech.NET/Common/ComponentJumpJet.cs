using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.Common
{
    class ComponentJumpJet:Component
    {
        public ComponentJumpJet() { }
        public ComponentJumpJet(int iMechTonnage, bool bImproved) 
        {
            Name = "Jump Jet";
            if(iMechTonnage >= 10 && iMechTonnage < 60) { Tonnage = 0.5; CriticalSpaceMech = 1; }
            if (iMechTonnage >= 60 && iMechTonnage < 90) { Tonnage = 1; CriticalSpaceMech = 1; }
            if (iMechTonnage >= 90) { Tonnage = 2; CriticalSpaceMech = 1; }

            if(bImproved)
            {
                Name = "Improved Jump Jet";
                Tonnage *= 2;
                CriticalSpaceMech *= 2;
            }

        }

        public int CriticalSpaceMech { get; set; }
        
    }
}
