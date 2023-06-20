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

        public virtual double BV { get { return 0; } }
        public BattleTechNET.Common.TECHNOLOGY_BASE TechnologyBase { get; set; }
        public bool MixedTechBase { get; set; }
        public bool IsCompatible(ITechBase techbased)
        {
            if (MixedTechBase) return true;
            if (TechnologyBase == techbased.TechnologyBase) return true;
            if (techbased.TechnologyBase == TECHNOLOGY_BASE.BOTH) return true;
            return false;

        }

        public int ArmorFactor
        {
            get
            {
                int retval = 0;

                foreach(ArmorHitLocation hl in HitLocations)
                {
                    foreach(ArmorFacing facing in hl.ArmorFacings.Values)
                    {
                        retval += facing.ArmorPoints;
                    }
                }

                return retval;
            }
        }
        public virtual double ComputedTonnage
        {
            get
            {
                decimal dTonnage = 0;
                foreach(UnitComponent component in Components)
                {
                    dTonnage += (decimal)component.Component.Tonnage;
                }
                return (double)dTonnage;
            }

        }

    }
}
