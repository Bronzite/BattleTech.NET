using BattleTechNET.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.TotalWarfare
{
    public class UnitComponent
    {
        public UnitComponent() { }
        public UnitComponent(Component component, HitLocation hitlocation)
        {
            Component = component;
            HitLocation = hitlocation;
        }
        public Component Component { get; set; }
        public HitLocation HitLocation { get; set; }
    }
}
