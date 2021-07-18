using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.Common
{
    public class Component:ICloneable,IAliasable,ITechBase,IBattleValue
    {
        public Component()
        {
            AliasList = new List<string>();
        }
        public string Name { get; set; }
        public double Tonnage { get; set; }
        public double BaseCost { get; set; }
        public TECHNOLOGY_BASE TechnologyBase { get; set; }
        public string TechRating { get; set; }
        public bool Omnipod { get; set; }
        public virtual object Clone()
        {
            Component retval = CreateInstance();
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
            retval.BV = BV;
            retval.DefensiveBV = DefensiveBV;
            foreach (string s in Aliases) retval.AddAlias(s);
            return retval;
        }


        public int? CriticalSpaceMech { get; set; }
        public int? CriticalSpaceProtomech { get; set; }
        public int? CriticalSpaceCombatVehicle { get; set; }
        public int? CriticalSpaceSupportVehicle { get; set; }
        public int? CriticalSpaceFighters { get; set; }
        public int? CriticalSpaceSmallCraft { get; set; }
        public int? CriticalSpaceDropShips { get; set; }

        public virtual Component CreateInstance()
        {
            return new Component();
        }

        public override string ToString()
        {
            return Name;
        }
        private List<string> AliasList { get; set; }
        public IEnumerable<string> Aliases { get { return AliasList; } }
        public IAliasable AddAlias(string sAliasable) { AliasList.Add(sAliasable); return this; }
        public IAliasable AddAlias(IEnumerable<string> ieAliasable) 
        { 
            foreach(string s in ieAliasable)
                AliasList.Add(s); 
            return this; 
        }
        public IAliasable ClearAliasList() { AliasList.Clear(); return this; }

        public virtual double BV { get; set; }
        public bool DefensiveBV { get; set; }
    }
}
