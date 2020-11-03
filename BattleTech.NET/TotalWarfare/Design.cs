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
        public HitLocation GetHitLocationByName(string sName)
        {
            foreach(HitLocation hl in HitLocations)
            {
                if (Utilities.IsSynonymFor(sName, hl.Name) && sName.Equals(hl.Name,System.StringComparison.CurrentCultureIgnoreCase))
                    return hl;
            }
            return null;
        }

        public double BV {get;}
        public BattleTechNET.Common.TECHNOLOGY_BASE TechnologyBase { get; set; }
        public virtual double ComputedTonnage
        {
            get
            {
                double dTonnage = 0;
                foreach(UnitComponent component in Components)
                {
                    dTonnage += component.Component.Tonnage;
                }
                return dTonnage;
            }

        }


    }
}
