using System;
using System.Collections.Generic;
using BattleTechNET.Common;
using BattleTechNET.Common;

namespace BattleTechNET.StrategicBattleForce
{
    public class Unit:IGameObject
    {
        public Unit()
        {
            Elements = new List<Element>();

        }

        public Guid Id { get; set; }

        public string Name { get; set; }


        public List<Element> Elements { get; set; }

        private static bool IsGroundMovement (string sCode)
        {
            string sCodeLower = sCode.ToLower();
            string[] sGroundsCode = new string[] { "l", "j", "s", "qt", "qw", "h", "n", "s", "r", "t", "v", "w", "g","f" };
            for (int i = 0; i < sGroundsCode.Length; i++)
                if (sGroundsCode[i] == sCodeLower) return true;
            return false;
        }

        private static bool IsAerospaceMovement(string sCode)
        {
            string sCodeLower = sCode.ToLower();
            string[] sAerospaceCode = new string[] { "k","i","a","a","l","p","aw" };
            for (int i = 0; i < sAerospaceCode.Length; i++)
                if (sAerospaceCode[i] == sCodeLower) return true;
            return false;
        }


        /// <summary>
        /// Returns true if any element of this unit has the specified ability.
        /// </summary>
        /// <param name="sCode">The Code for a special ability</param>
        /// <returns>True if any unit in this unit has that ability, otherwise false.</returns>
        public bool AnyElementHasAbility(string sCode)
        {
            foreach(Element element in Elements)
            {
                for(int i=0;i<element.SpecialAbilities.Count;i++)
                {
                    if (sCode.Equals(element.SpecialAbilities[i].Code, StringComparison.CurrentCultureIgnoreCase))
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns true if all elements of this unit have the specified ability.
        /// </summary>
        /// <param name="sCode">The Code for a special ability</param>
        /// <returns>True if all elements in this unit have that ability, otherwise false.</returns>
        public bool AllElementsHaveAbility(string sCode)
        {
            foreach (Element element in Elements)
            {
                bool bAbilityFound = false;
                for (int i = 0; i < element.SpecialAbilities.Count; i++)
                {
                    if (sCode.Equals(element.SpecialAbilities[i].Code, StringComparison.CurrentCultureIgnoreCase))
                        bAbilityFound = true;
                }
                if (!bAbilityFound) return false;
            }
            return true;
        }

        private int TargetMovementModifier(int iAvailableMP,string sUnitType)
        {
            //NOTE: We bring in Unit Type in case Unit Type hasn't been set 
            //by the time this function is called.

            int retval = -4;
            if (iAvailableMP > 0) retval = 0;
            if (iAvailableMP > 2) retval++;
            if (iAvailableMP > 4) retval++;
            if (iAvailableMP > 6) retval++;
            if (iAvailableMP > 9) retval++;
            if (iAvailableMP > 17) retval++;
            if (sUnitType.Equals("BA", StringComparison.CurrentCultureIgnoreCase)) retval++;
            if (sUnitType.Equals("PM", StringComparison.CurrentCultureIgnoreCase)) retval++;
            //TODO: The Target Movement Modifier Table on IO328 lists Unit Types
            //of VTOL and WiGE, neither of which are types in the SBF Element Type
            //Table.  Both roll into the generic Vehicle (V) type.  It is unclear
            //how those modifiers should be applied.
            if (AnyElementHasAbility("LG")) retval--;
            if (AnyElementHasAbility("VLG") || AnyElementHasAbility("SLG")) retval -= 2;
            if (AllElementsHaveAbility("MAS") || AllElementsHaveAbility("MAS")) retval += 2;

            return retval;

        }

        private static string GetPreferredMovementType(string[] sCode)
        {
            string[] sIndexList = new string[] { "l", "j", "s", "qt", "qw", "h", "n", "r", "t", "v", "w", "g", "f", "k", "i", "a", "p", "aw", "bm" };
            int iLowest = int.MaxValue;
            foreach(string s in sCode)
            {
                int iIndex = Array.IndexOf<string>(sIndexList, s.ToLower());
                if (iIndex < iLowest) iLowest = iIndex;
            }
            return sIndexList[iLowest];
        }

        private static int RestrictionRank(string sCode, string sType)
        {
            //Encoding of Movement Mode Table (IO328)
            if (sType.Equals("CI", StringComparison.CurrentCultureIgnoreCase))
            {
                if (sCode.Equals("f", StringComparison.CurrentCultureIgnoreCase)) return 5;
                if (sCode.Equals("w", StringComparison.CurrentCultureIgnoreCase)) return 2;
                if (sCode.Equals("h", StringComparison.CurrentCultureIgnoreCase)) return 3;
                if (sCode.Equals("j", StringComparison.CurrentCultureIgnoreCase)) return 5;
                if (sCode.Equals("v", StringComparison.CurrentCultureIgnoreCase)) return 8;
            }
            else
            {
                if (sCode.Equals("l", StringComparison.CurrentCultureIgnoreCase) || sCode.Equals("") || sCode.Equals("bm"))
                    if (sType.Equals("BM", StringComparison.CurrentCultureIgnoreCase)) return 6;
                    else return 5;
                if (sCode.Equals("j", StringComparison.CurrentCultureIgnoreCase))
                    if (sType.Equals("BM", StringComparison.CurrentCultureIgnoreCase)) return 7;
                    else return 6;
                if (sCode.Equals("s", StringComparison.CurrentCultureIgnoreCase))
                    if (sType.Equals("BM", StringComparison.CurrentCultureIgnoreCase)) return 6;
                    else return 5;
                if (sCode.Equals("qt", StringComparison.CurrentCultureIgnoreCase)) return 6;
                if (sCode.Equals("qw", StringComparison.CurrentCultureIgnoreCase)) return 6;
                
                if (sCode.Equals("r", StringComparison.CurrentCultureIgnoreCase)) return 1;
                if (sCode.Equals("t", StringComparison.CurrentCultureIgnoreCase)) return 4;
                if (sCode.Equals("v", StringComparison.CurrentCultureIgnoreCase)) return 8;
                
                if (sCode.Equals("g", StringComparison.CurrentCultureIgnoreCase)) return 8;
                
                if (sCode.Equals("k", StringComparison.CurrentCultureIgnoreCase)) return 1;
                if (sCode.Equals("i", StringComparison.CurrentCultureIgnoreCase)) return 4;
                if (sCode.Equals("a", StringComparison.CurrentCultureIgnoreCase)) return 5;
                //TODO: Difference listed for LAMS and BiModal LAMS
                if (sCode.Equals("l", StringComparison.CurrentCultureIgnoreCase)) return 6;
                if (sCode.Equals("p", StringComparison.CurrentCultureIgnoreCase)) return 2;
                if (sCode.Equals("aw", StringComparison.CurrentCultureIgnoreCase)) return 3;
            }
            throw new Exception($"Unknown Movement Code {sCode} for {sType}");
        }

        public void CalculateStats()
        {
            //TODO: Step 1A ProtoMech Adjustments

            double dSize = 0;
            List<MovementMode> lstMovementModes = new List<MovementMode>();
            Dictionary<string, int> dicTypes = new Dictionary<string, int>();
            double dTotalGroundMovement = 0;
            double dLowestInfantryOrBattleArmorMP = double.MaxValue;
            double dJumpMovement = 0;
            double dSlowestAerospace = double.MaxValue;
            double dArmorValue = 0;
            double dShortRangeDamage = 0;
            double dMediumRangeDamage = 0;
            double dLongRangeDamage = 0;
            double dExtremeRangeDamage = 0;
            double dIndirectDamage = 0;
            double dFlakDamage = 0;
            double dArtilleryDamage = 0;
            double dBombDamage = 0;

            List<string> CandidateMovementModes = new List<string>();
            int iRestrictionRank = int.MaxValue;
            foreach (Element curElement in Elements)
            {
                dSize += (double)curElement.Size; //Step 1C, IO327
                
                //Step 1E, IO327
                dArmorValue += (double)curElement.CurrentArmor + (double)curElement.CurrentStructure;
                if (curElement.CurrentStructure >= 3 ||
                   curElement.HasSpecialAbility("AMS", true) ||
                   curElement.HasSpecialAbility("CASE", true))
                    dArmorValue += 0.5;
                if (curElement.HasSpecialAbility("ENE", true) ||
                   curElement.HasSpecialAbility("CASEII", true) ||
                   curElement.HasSpecialAbility("CR", true) ||
                   curElement.HasSpecialAbility("RAMS", true))
                    dArmorValue += 1;

                //Used to determine Unit Type (Step 1B, IO326)
                if (!dicTypes.ContainsKey(curElement.UnitType.Code)) dicTypes.Add(curElement.UnitType.Code, 0);
                dicTypes[curElement.UnitType.Code]++;

                //Step 1D, IO327
                foreach (MovementMode curMode in curElement.MovementModes)
                {
                    bool bModeAlreadyInList = false;

                    //Used to determine Jump value
                    if (curMode.Code.Equals("j", StringComparison.CurrentCultureIgnoreCase))
                        dJumpMovement += curMode.Points;

                    if(IsGroundMovement(curMode.Code))
                    {
                        dTotalGroundMovement += curMode.Points;
                    }

                    if(IsAerospaceMovement(curMode.Code))
                    {
                        if (dSlowestAerospace > curMode.Points) dSlowestAerospace = curMode.Points;
                    }

                    int iRestriction = RestrictionRank(curMode.Code, curElement.UnitType.Code);
                    
                    if(iRestriction < iRestrictionRank)
                    {
                        iRestrictionRank = iRestriction;
                        CandidateMovementModes = new List<string>();
                        CandidateMovementModes.Add(curMode.Code);
                    }



                    foreach(MovementMode lstMode in lstMovementModes)
                    {
                        //If the element MovementMode code equals the unit MovementMode
                        //that we're currently examining...
                        if(lstMode.Code == curMode.Code)
                        {
                            //Note that this mode is already in the list (so we don't need to add it.)
                            bModeAlreadyInList = true;
                            //If this element has a lower movement point value than the unit as a whole,
                            //return the unit's movement points to match.
                            if (lstMode.Points > curMode.Points) lstMode.Points = curMode.Points;
                        }
                    }
                    //If we didn't already see this MovementMode Code in the unit MovementMode list...
                    if(!bModeAlreadyInList)
                    {
                        //Add a copy of this unit's MovementMode to the Unit's MovementMode List.
                        lstMovementModes.Add(curMode.Clone() as MovementMode);
                    }
                }

                //Step 1F
                foreach(Common.Element.Arc arc in curElement.Arcs)
                {
                    dShortRangeDamage += arc.Short;
                    dMediumRangeDamage += arc.Medium;
                    dLongRangeDamage += arc.Long;
                    dExtremeRangeDamage += arc.Extreme;
                }
            }

            //Note that we may have Movement Modes in the list at this point that only some of the
            //unit have.  We need that every Element can move at least the unit's MovementModes.
            MovementModes = new List<MovementMode>();
            //For each movement mode we think the unit has...
            foreach(MovementMode UnitMovementMode in lstMovementModes)
            {
                bool bMovementModeIsValid = true;
                //Cycle through each Element in the Unit.
                foreach(Element currentElement in Elements)
                {
                    bool bElementMeetsMovementRequirement = false;
                    foreach (MovementMode ElementMovementMode in currentElement.MovementModes)
                    {
                        //If the Element has the appropriate Movement Mode and at least as many points as the Unit,
                        //Mark the Element as meeting the Movement Requirement.
                        if(UnitMovementMode.Code == ElementMovementMode.Code && ElementMovementMode.Points >= UnitMovementMode.Points)
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

            int iAerospace = 0;
            int iGround = 0;
            
            //Find the Movment Type
            //Step 1D IO327
            List<string> lstMovementTypes = new List<string>();
            foreach(string sCode in dicTypes.Keys)
            {
                SBFType sbfType = SBFType.GetCanonicalTypeByCode(sCode);
                if (sbfType.AeroType) iAerospace += dicTypes[sCode];
                else iGround += dicTypes[sCode];
                string sInsertValue = sCode;
                if (sCode == "") sInsertValue = "BM";
                lstMovementTypes.Add(sInsertValue);
            }

            //Disallow units with both Aerospace
            //and Ground Components (Step 1B, IO328)
            if (iAerospace > 0 && iGround > 0) throw new Exception("Unit cannot contain both Aerospace and Ground Elements");

            //Compute MP Value (Step 1D, IO329)
            int MP = 0;
            if(dTotalGroundMovement>0)
            {
                double dMP = Math.Round(dTotalGroundMovement / (double)Elements.Count);
                dMP = Math.Min(dMP, dLowestInfantryOrBattleArmorMP);
                MP = (int)dMP;
            }
            else
            {
                MP = (int)dSlowestAerospace;
            }
            
            
            
            MovementModes.Add(new MovementMode(MP, GetPreferredMovementType(lstMovementTypes.ToArray()))); //Step 1D, IO329
            
            //TODO: Transport Movement 
            
            UnitType = SBFType.GetAggregateUnitType(dicTypes); //Step 1B, IO326
            Jump = (int)Math.Round((dJumpMovement / (double)Elements.Count) / 2D, 0); //Step 1D, IO329
            TMM = TargetMovementModifier(MP, UnitType.Code); //Step 1D, IO329
            Armor = (int)Math.Round(dArmorValue / 3D);
            Size = (int)Math.Round(dSize / (double)Elements.Count); //Step 1C, IO327


        }

        public SBFType UnitType { get; set; }
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
