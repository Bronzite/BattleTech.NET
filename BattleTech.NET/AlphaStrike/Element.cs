using System;
using System.Collections.Generic;
using BattleTechNET.Common;

namespace BattleTechNET.Common
{
    public class Element:IGameObject,ISpecialAbilities
    {
        public Element()
        {
            MovementModes = new List<MovementMode>();
            Arcs = new List<Arc>();
            SpecialAbilities = new List<SpecialAbility>();
        }

        public SpecialAbility GetSpecialAbility(string sCode)
        {
            foreach (SpecialAbility ability in SpecialAbilities)
            {
                if (ability.Code.Equals(sCode, StringComparison.CurrentCultureIgnoreCase))
                {
                    return ability;
                }
            }
            return null;
        }

        public List<SpecialAbility> GetSpecialAbilities(string sCode)
        {
            List<SpecialAbility> retval = new List<SpecialAbility>();
            foreach (SpecialAbility ability in SpecialAbilities)
            {
                if (ability.Code.Equals(sCode, StringComparison.CurrentCultureIgnoreCase))
                {
                    retval.Add(ability);
                }
            }

                foreach (Arc arc in Arcs)
                {
                    retval.AddRange (arc.GetSpecialAbilities(sCode));
                }

            return retval;
        }

        public bool HasSpecialAbility(string sCode)
        {
            foreach (SpecialAbility ability in SpecialAbilities)
            {
                if (ability.Code.Equals(sCode, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasSpecialAbility(string sCode, bool bIncludeChildren)
        {
            foreach(SpecialAbility ability in SpecialAbilities)
            {
                if(ability.Code.Equals(sCode,StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }
            if(bIncludeChildren)
            {
                foreach(Arc arc in Arcs)
                {
                    if (arc.HasSpecialAbility(sCode)) return true;
                }
            }
            return false;
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
        
            
        public class Arc: ISpecialAbilities
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

            public bool HasSpecialAbility(string sCode)
            {
                foreach (SpecialAbility ability in SpecialAbilities)
                {
                    if (ability.Code.Equals(sCode, StringComparison.CurrentCultureIgnoreCase))
                    {
                        return true;
                    }
                }
                return false;
            }

            public bool HasSpecialAbility(string sCode, bool bIncludeChildren)
            {
                foreach (SpecialAbility ability in SpecialAbilities)
                {
                    if (ability.Code.Equals(sCode, StringComparison.CurrentCultureIgnoreCase))
                    {
                        return true;
                    }
                }
                return false;
            }
            public SpecialAbility GetSpecialAbility(string sCode)
            {
                foreach (SpecialAbility ability in SpecialAbilities)
                {
                    if (ability.Code.Equals(sCode, StringComparison.CurrentCultureIgnoreCase))
                    {
                        return ability;
                    }
                }
                return null;
            }

            public List<SpecialAbility> GetSpecialAbilities(string sCode)
            {
                List<SpecialAbility> retval = new List<SpecialAbility>();
                foreach (SpecialAbility ability in SpecialAbilities)
                {
                    if (ability.Code.Equals(sCode, StringComparison.CurrentCultureIgnoreCase))
                    {
                        retval.Add(ability);
                    }
                }

                return retval;
            }

            public string Name { get; set; }

            public int Short { get; set; }

            public int Medium { get; set; }

            public int Long { get; set; }
            public int Extreme { get; set; }

            public IList<SpecialAbility> SpecialAbilities { get; set; }

        }
    }
}
