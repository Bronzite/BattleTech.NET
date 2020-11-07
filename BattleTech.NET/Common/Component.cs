using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.Common
{
    public class Component:ICloneable
    {
        public string Name { get; set; }
        public double Tonnage { get; set; }
        public double BaseCost { get; set; }
        public TECHNOLOGY_BASE TechnologyBase { get; set; }
        public string TechRating { get; set; }
        public object Clone()
        {
            Component retval = new Component();
            retval.Name = Name;
            retval.Tonnage = Tonnage;
            retval.BaseCost = BaseCost;
            retval.TechnologyBase = TechnologyBase;
            retval.CriticalSpaceMech = CriticalSpaceMech;
            retval.CriticalSpaceProtomech = CriticalSpaceProtomech;
            retval.CriticalSpaceCombatVehicle = CriticalSpaceCombatVehicle;
            retval.CriticalSpaceSupportVehicle = CriticalSpaceSupportVehicle;
            retval.CriticalSpaceFighters = CriticalSpaceFighters;
            retval.CriticalSpaceSmallCraft = CriticalSpaceSmallCraft;
            retval.CriticalSpaceDropShips = CriticalSpaceDropShips;
            return retval;
        }


        public int? CriticalSpaceMech { get; set; }
        public int? CriticalSpaceProtomech { get; set; }
        public int? CriticalSpaceCombatVehicle { get; set; }
        public int? CriticalSpaceSupportVehicle { get; set; }
        public int? CriticalSpaceFighters { get; set; }
        public int? CriticalSpaceSmallCraft { get; set; }
        public int? CriticalSpaceDropShips { get; set; }
    }
}
