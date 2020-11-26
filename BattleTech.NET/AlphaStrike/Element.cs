using System;
using System.Collections.Generic;
using BattleTechNET.Common;

namespace BattleTechNET.AlphaStrike
{
    public class Element:IGameObject 
    {
        public Element()
        {
            MovementModes = new List<MovementMode>();
            Arcs = new List<Arc>();
            SpecialAbilities = new List<SpecialAbility>();
        }

        public MovementMode GetMovementMode(string sMovementMode)
        {
            foreach(MovementMode movementMode in MovementModes)
            {
                if(movementMode.Code.Equals(sMovementMode,StringComparison.CurrentCultureIgnoreCase))
                {
                    return movementMode;
                }
            }
            return null;
        }

        public Guid Id { get; set; }

        public int PV { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// The type of this unit.
        /// </summary>
        public UnitType UnitType { get; set; }

        public IList<Arc> Arcs { get; set; }

        public IList<MovementMode> MovementModes { get; set; }

        public int OverheatValue { get; set; }

        public int HeatScale { get; set; }

        public int MaxArmor { get; set; }

        public int CurrentArmor { get; set; }

        public int MaxStructure { get; set; }

        public int CurrentStructure { get; set; }

        public int Size { get; set; }

        public IList<SpecialAbility> SpecialAbilities { get; set; }
        
            
        public class Arc
        {
            public Arc(string sName, int iShort, int iMedium, int iLong, IEnumerable<SpecialAbility> eSpecialAbilities) : this(sName, iShort, iMedium, iLong, 0, eSpecialAbilities) { }
            public Arc(string sName,int iShort,int iMedium, int iLong, int iExtreme, IEnumerable<SpecialAbility> eSpecialAbilities)
            {
                Name = sName;
                Short = iShort;
                Medium = iMedium;
                Long = iLong;
                Extreme = iExtreme;
                SpecialAbilities = new List<SpecialAbility>();
                if(eSpecialAbilities != null)
                foreach(SpecialAbility sa in eSpecialAbilities)
                {
                    SpecialAbilities.Add(sa);
                }
            }

            public string Name { get; set; }

            public int Short { get; set; }

            public int Medium { get; set; }

            public int Long { get; set; }
            public int Extreme { get; set; }

            public List<SpecialAbility> SpecialAbilities { get; set; }

        }
    }
}
