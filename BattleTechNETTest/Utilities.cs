﻿using BattleTechNET.Common;
using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.IO;

namespace BattleTechNETTest
{
    public static class Utilities
    {
        public static string DataDirectory = "";

        static public List<KeyValuePair<string, string>> UndertonnageMechs = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("Atlas","C"),
            new KeyValuePair<string, string>("Atlas","AS7-D(C)"),
            new KeyValuePair<string, string>("Victor","C"),
            new KeyValuePair<string, string>("Victor","VTR-9B (Shoji)"),
            new KeyValuePair<string,string>("Sun Spider","Manul")
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
        
        //Recursive file get
        static public string[] GetFiles(string sDirectory, string sPattern)
        {
            List<string> retval = new List<string>();
            string[] sDirectories = Directory.GetDirectories(sDirectory);
            foreach (string sSubdirectory in sDirectories)
            {
                retval.AddRange(GetFiles(sSubdirectory, sPattern));
            }
            retval.AddRange(Directory.GetFiles(sDirectory, sPattern));
            return retval.ToArray();
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
