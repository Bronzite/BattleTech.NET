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
        public object Clone()
        {
            Component retval = new Component();
            retval.Name = Name;
            retval.Tonnage = Tonnage;
            retval.BaseCost = BaseCost;
            retval.TechnologyBase = TechnologyBase;
            return retval;
        }
    }
}
