using BattleTechNET.AlphaStrike;
using BattleTechNET.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.BattleForce
{
    public class BattleForceUnit : IGameObject
    {
        public BattleForceUnit()
        {
            Elements = new List<Element>();

        }

        public Guid Id { get; set; }

        public string Name { get; set; }


        public List<Element> Elements { get; set; }

        public void CalculateStats()
        {
            double dSize = 0;
            List<MovementMode> lstMovementModes = new List<MovementMode>();
            Dictionary<string, int> dicTypes = new Dictionary<string, int>();

            foreach (Element curElement in Elements)
            {
                dSize += (double)curElement.Size;
                if (!dicTypes.ContainsKey(curElement.UnitType.Code)) dicTypes.Add(curElement.UnitType.Code, 0);

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
                foreach (Element currentElement in Elements)
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


            Size = (int)Math.Round(dSize / (double)Elements.Count);


        }

        public int Size { get; set; }

        public IList<MovementMode> MovementModes { get; set; }

        public int Jump { get; set; }

        public int TMM { get; set; }

        public int Armor { get; set; }

        public int ShortRange { get; set; }

        public int MediumRange { get; set; }

        public int LongRange { get; set; }

        public int Skill { get; set; }

        public int PointValue { get; set; }

        public List<SpecialAbility> SpecialAbilities { get; set; }

        public string Note { get; set; }
    }
}
