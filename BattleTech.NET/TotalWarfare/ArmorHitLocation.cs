using System;
using System.Collections.Generic;

namespace BattleTechNET.TotalWarfare
{
    public class ArmorHitLocation:StructureHitLocation
    {
        public ArmorHitLocation():base()
        {
            mArmorFacings = new Dictionary<string, ArmorFacing>();
        }

        private Dictionary<string, ArmorFacing> mArmorFacings;
        public Dictionary<string, ArmorFacing> ArmorFacings { get { return mArmorFacings;} set { mArmorFacings = value; } }

    }
}
