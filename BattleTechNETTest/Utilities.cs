using BattleTechNET.AlphaStrike;
using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;

namespace BattleTechNETTest
{
    public static class Utilities
    {

        static public List<KeyValuePair<string, string>> UndertonnageMechs = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("Atlas","C"),
            new KeyValuePair<string, string>("Victor","C")
        };

        static public bool IsUndertonnageDesign(Design design)
        {
            foreach(KeyValuePair<string,string> kvp in UndertonnageMechs)
            {
                if (kvp.Key == design.Model && kvp.Value == design.Variant)
                    return true;
            }
            return false;
        }


        static public Element GenerateASBattleMech(string sName, int iSize, int iWalk, int iJump, int iArmor, int iStructure, int iShort, int iMedium, int iLong)
        {
            Element retval = new Element();
            retval.Name = "Generic BattleMech";
            retval.Id = Guid.NewGuid();
            retval.UnitType = new UnitTypeBattleMech();
            if(iWalk > 0)
            retval.MovementModes.Add(new BattleTechNET.Common.MovementMode(iWalk, ""));
            if(iJump > 0)
            retval.MovementModes.Add(new BattleTechNET.Common.MovementMode(iJump, "j"));
            retval.MaxArmor = iArmor;
            retval.CurrentArmor = iArmor;
            retval.MaxStructure = iStructure;
            retval.CurrentStructure = iStructure;
            Element.Arc BasicArc = new Element.Arc("Basic", iShort, iMedium, iLong,null);
            retval.Arcs.Add(BasicArc);
            retval.Size = iSize;
            retval.OverheatValue = 0;
            return retval;

        }


    }
}
