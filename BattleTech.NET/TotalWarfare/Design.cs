using System.Collections.Generic;


namespace BattleTechNET.TotalWarfare
{
    public class Design
    {
        public string Variant { get; set; }
        public string Model { get; set; }
        public double Tonnage { get; set; }
        public List<HitLocation> HitLocations { get; set; }
        public double BV {get;}
        public BattleTechNET.Common.TECHNOLOGY_BASE TechnologyBase { get; set; }

    }
}
