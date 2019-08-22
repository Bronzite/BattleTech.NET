using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BattleTechNET.Data
{
    /// <summary>
    /// Class for reading MegaMek files for design data.
    /// </summary>
    public static class MTFReader
    {
        public static BattleMechDesign ReadBattleMechDesignFile(string sFilename)
        {
            return ReadBattleMechDesignFile(File.OpenRead(sFilename));
        }
        public static BattleMechDesign ReadBattleMechDesignFile(Stream inStream)
        {
            BattleMechDesign retval = new BattleMechDesign();
            try
            {

                List<string> lstFileLines = new List<string>();
                StreamReader streamReader = new StreamReader(inStream);
                while(!streamReader.EndOfStream)
                {
                    string sLine = streamReader.ReadLine();
                    lstFileLines.Add(sLine);
                }

                //Read entire MTF file into array of lines.
                string[] sLines = lstFileLines.ToArray();


                if (sLines.Length < 5) throw new Exception("File is too short -- not a BattleMech Design.");

                //Check Version Number
                string[] sVersionFields = sLines[0].Split(':');
                if (sVersionFields.Length != 2) throw new Exception(string.Format("Invalid Version Line: {0}", sLines[0]));

                double dVersion = 0;
                if (!double.TryParse(sVersionFields[1], out dVersion))
                {
                    throw new Exception(string.Format("Version number not parseable: {0}", sVersionFields[1]));
                }

                if(dVersion != 1)
                {
                    throw new Exception(string.Format("Current Implementation only supports MTF Version 1.0.  File is version {0}", sVersionFields[1]));
                }

                if (sLines[1].Trim() != "") retval.Model = sLines[1]; else throw new Exception("File does not contain a model name");
                if (sLines[2].Trim() != "") retval.Model = sLines[2];
                string sConfig = "";
                for (int i = 3;i < sLines.Length;i ++)
                {
                    if(sLines[i] != "")
                    {
                        KeyValuePair<string, string> kvp = GetKVP(sLines[i]);
                        if(kvp.Key == "Config")
                        {
                            sConfig = kvp.Value;
                        }
                        if(kvp.Key == "Mass")
                        {
                            int iMass = 0;
                            if(!int.TryParse(kvp.Value, out iMass))
                            {
                                throw new Exception(string.Format("Unable to parse mass: {0}", kvp.Value));
                            }
                            retval.Tonnage = iMass;
                        }
                        if(kvp.Key == "Engine")
                        {

                        }
                    }
                }

            }
            catch(Exception ex)
            {
                throw new Exception("Exception reading Battlemech Design",ex);
            }

            return retval;
        }

        private static KeyValuePair<string,string> GetKVP (string sMTFLine)
        {
            int iColonLocation = sMTFLine.IndexOf(':');
            if (iColonLocation > -1 &&  //String actually contains a colon
                iColonLocation < sMTFLine.Length - 1) //colon isn't last character
            {
                string sKey = sMTFLine.Substring(0, iColonLocation);
                string sValue = sMTFLine.Substring(iColonLocation + 1);
                return new KeyValuePair<string, string>(sKey, sValue);
            }
            if (iColonLocation == sMTFLine.Length - 1)
                return new KeyValuePair<string, string>(sMTFLine.Substring(0, iColonLocation),"");
            return new KeyValuePair<string, string>(sMTFLine, "");
        }
    }
}
