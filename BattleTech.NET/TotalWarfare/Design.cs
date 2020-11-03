using System.Collections.Generic;
using BattleTechNET.Common;

namespace BattleTechNET.TotalWarfare
{
    public class Design
    {
        public ICollection<UnitComponent> Components { get; set; }
        public string Variant { get; set; }
        public string Model { get; set; }
        public double Tonnage { get; set; }
        public ICollection<HitLocation> HitLocations { get; set; }
        public double BV {get;}
        public BattleTechNET.Common.TECHNOLOGY_BASE TechnologyBase { get; set; }

    }
}
