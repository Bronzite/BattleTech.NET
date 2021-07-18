using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.Common
{
    public class ComponentAmmunition:Component
    {
        public ComponentAmmunition() : base() { Tonnage = 1; Volatile = true; }
        public ComponentAmmunition(string sName):this() { Name = sName; }
        public ComponentAmmunition(string sName, int iRounds): this(sName) { Rounds = iRounds; }
        public ComponentAmmunition(string sName, int iRounds, string sTechRating) : this(sName, iRounds) { TechRating = sTechRating; }
        public ComponentAmmunition(string sName, int iRounds, string sTechRating,TECHNOLOGY_BASE techBase) : this(sName, iRounds,sTechRating) { TechnologyBase = techBase; }
        public ComponentAmmunition(string sName, int iRounds, double dTonnage):this(sName,iRounds) { Tonnage = dTonnage; }
        public ComponentAmmunition(string sName, int iRounds, double dTonnage, string sTechRating) : this(sName, iRounds, dTonnage) { TechRating = sTechRating; }
        public ComponentAmmunition(string sName, int iRounds, double dTonnage, string sTechRating, TECHNOLOGY_BASE techBase) : this(sName, iRounds, dTonnage,sTechRating) { TechnologyBase = techBase; }

        //Used to calculate Explosive Ammo for Defensive BV (TM302)
        public bool Volatile { get; set; }


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

    }

    
}
