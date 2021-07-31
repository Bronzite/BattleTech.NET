using BattleTechNET.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.StrategicBattleForce
{
    public class Formation : IGameObject
    {
        public Formation()
        {
            mUnits = new List<Unit>();
            MovementModes = new List<MovementMode>();
        }

        public Guid Id { get; set; }

        private string mName;
        public string Name { get { return mName; } set { mName = value; } }

        private List<Unit> mUnits { get; set; }
        public List<Unit> Units { 
            get { return mUnits; }
            set
            {
                if (value.Count <= 4) mUnits = value;
                throw new Exception("Formation May Not Contain More Than 4 Units.");
            } 
        }

        public void CalculatedValues()
        {
            //Calculate Values for a Formation (IO329)
            double dSize = 0;
            int iPV = 0;
            List<MovementMode> lstMovementModes = new List<MovementMode>();
            Dictionary<string, int> dicTypes = new Dictionary<string, int>();

            foreach (Unit curElement in mUnits)
            {
                dSize += (double)curElement.Size;
                iPV += curElement.PointValue;
                
                foreach (MovementMode curMode in curElement.MovementModes)
                {
                    bool bModeAlreadyInList = false;
                    foreach (MovementMode lstMode in lstMovementModes)
                    {
                        //If the element MovementMode code equals the unit MovementMode
                        //that we're currently examining...
                        if (lstMode.Code == curMode.Code)
                        {
                            //Note that this mode is already in the list (so we don't need to add it.)
                            bModeAlreadyInList = true;
                            //If this element has a lower movement point value than the unit as a whole,
                            //return the unit's movement points to match.
                            if (lstMode.Points > curMode.Points) lstMode.Points = curMode.Points;
                        }
                    }
                    //If we didn't already see this MovementMode Code in the unit MovementMode list...
                    if (!bModeAlreadyInList)
                    {
                        //Add a copy of this unit's MovementMode to the Unit's MovementMode List.
                        lstMovementModes.Add(curMode.Clone() as MovementMode);
                    }
                }
            }

            //Note that we may have Movement Modes in the list at this point that only some of the
            //unit have.  We need that every Element can move at least the unit's MovementModes.
            MovementModes = new List<MovementMode>();
            //For each movement mode we think the unit has...
            foreach (MovementMode UnitMovementMode in lstMovementModes)
            {
                bool bMovementModeIsValid = true;
                //Cycle through each Element in the Unit.
                foreach (Unit currentElement in mUnits)
                {
                    bool bElementMeetsMovementRequirement = false;
                    foreach (MovementMode ElementMovementMode in currentElement.MovementModes)
                    {
                        //If the Element has the appropriate Movement Mode and at least as many points as the Unit,
                        //Mark the Element as meeting the Movement Requirement.
                        if (UnitMovementMode.Code == ElementMovementMode.Code && ElementMovementMode.Points >= UnitMovementMode.Points)
                        {
                            bElementMeetsMovementRequirement = true;
                        }
                    }
                    //If this unit didn't meet the Requirement for the UnitMovementMode,
                    //mark this MovementMode as invalid.
                    if (!bElementMeetsMovementRequirement) bMovementModeIsValid = false;
                }
                //If Every element of the unit can move at least this many points in this
                //movement mode, add the MovementMode to the Unit.
                if (bMovementModeIsValid) MovementModes.Add(UnitMovementMode.Clone() as MovementMode);
            }


            Type = SBFType.GetAggregateUnitType(dicTypes);
            Size = (int)Math.Round(dSize / (double)mUnits.Count);
            PointValue = iPV;
        }

        public SBFType Type { get; set; }
        public int Size { get; set; }
        public List<MovementMode> MovementModes { get; set; }
        public string Jump { get; set; }
        public string TransportMove { get; set; }
        public string TMM { get; set; }
        public string Tactics {get;set;}
        public string Morale { get; set; }
        public string Skill { get; set; }
        public int PointValue { get; set; }
        public List<AlphaStrike.SpecialAbility> SpecialAbilities { get; set; }
    }
}
