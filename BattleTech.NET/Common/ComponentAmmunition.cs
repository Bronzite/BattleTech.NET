using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.Common
{
    public class ComponentAmmunition:Component
    {
        public ComponentAmmunition() : base() { Tonnage = 1; }
        public ComponentAmmunition(string sName):this() { Name = sName; }
        public ComponentAmmunition(string sName, int iRounds): this(sName) { Rounds = iRounds; }
        public ComponentAmmunition(string sName, int iRounds, string sTechRating) : this(sName, iRounds) { TechRating = sTechRating; }
        public ComponentAmmunition(string sName, int iRounds, string sTechRating,TECHNOLOGY_BASE techBase) : this(sName, iRounds,sTechRating) { TechnologyBase = techBase; }
        public ComponentAmmunition(string sName, int iRounds, double dTonnage):this(sName,iRounds) { Tonnage = dTonnage; }
        public ComponentAmmunition(string sName, int iRounds, double dTonnage, string sTechRating) : this(sName, iRounds, dTonnage) { TechRating = sTechRating; }
        public ComponentAmmunition(string sName, int iRounds, double dTonnage, string sTechRating, TECHNOLOGY_BASE techBase) : this(sName, iRounds, dTonnage,sTechRating) { TechnologyBase = techBase; }




        public int Rounds { get; set; }

        public override Component CreateInstance()
        {
            return new ComponentAmmunition();
        }

        public override object Clone()
        {
            ComponentAmmunition retval = base.Clone() as ComponentAmmunition;
            retval.Rounds = Rounds;
            return retval;
        }

        public List<ComponentAmmunition> GetCanonicalAmmunitions()
        {
            List<ComponentAmmunition> retval = new List<ComponentAmmunition>();
            retval.Add(new ComponentAmmunition("Machine Gun Ammo", 200,"A",TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("SRM 2 Ammo", 50,"C",TECHNOLOGY_BASE.BOTH ));
            retval.Add(new ComponentAmmunition("SRM 4 Ammo", 25,"C", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("SRM 6 Ammo", 15,"C", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 5 Ammo", 24,"C", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 10 Ammo", 12,"C", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 15 Ammo", 8,"C", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 20 Ammo", 6,"C", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("Autocannon/2 Ammo", 45, "C",TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Autocannon/5 Ammo", 20, "C", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Autocannon/10 Ammo", 10, "C", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Autocannon/20 Ammo", 5, "C", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LB 2-X AC Ammo", 45, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LB 5-X AC Ammo", 20, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LB 10-X AC Ammo", 10, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LB 20-X AC Ammo", 5, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("Light Autocannon/2 Ammo", 45, "D", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Light Autocannon/5 Ammo", 20, "D", TECHNOLOGY_BASE.INNERSPHERE));


            return retval;
        }
    }

    
}
