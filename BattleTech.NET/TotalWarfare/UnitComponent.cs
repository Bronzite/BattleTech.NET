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
        public bool RearFacing { get; set; }

        
        public string HitLocationString
        {
            get
            {
                if (RearFacing) return $"{HitLocation}R";
                else return HitLocation.ToString();
            }
        }
        public override string ToString()
        {
            return $"{Component} [{HitLocation}]";
        }
    }
}
