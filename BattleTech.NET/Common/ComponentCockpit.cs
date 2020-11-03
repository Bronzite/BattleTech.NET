using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    public class ComponentCockpit:Component
    {
        public enum COCKPIT_TYPE
        { 
            COCKPIT_STANDARD,
            COCKPIT_COMMANDCONSOLE
        };

        public COCKPIT_TYPE CockpitType { get; set; }

    }
}
