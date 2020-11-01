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

                //Get Model and Variant
                if (sLines[1].Trim() != "") retval.Model = sLines[1]; else throw new Exception("File does not contain a model name");
                if (sLines[2].Trim() != "") retval.Variant = sLines[2];
                retval.HitLocations = new List<HitLocation>();

                string sConfig = "";
                for (int i = 3;i < sLines.Length;i ++)
                {
                    if(sLines[i] != "")
                    {
                        KeyValuePair<string, string> kvp = GetKVP(sLines[i]);
                        if(kvp.Key == "Config")
                        {
                            sConfig = kvp.Value;
                            if(sConfig.Equals("Biped",StringComparison.InvariantCultureIgnoreCase))
                            {
                                BattleMechHitLocation mhlHead = new BattleMechHitLocation()
                                {
                                    Name = "HD",
                                    ArmorFacings = new Dictionary<string, ArmorFacing>()
                                    {
                                        { "HD", new ArmorFacing() { Name = "HD" } }
                                    },
                                    CriticalSlotCount = 6,
                                    Structure = new StructureLocation()
                                    {
                                        
                                            Name = "HD",
                                            StructureType = retval.StructureType,
                                            MaxStructurePoints = 3,
                                            StructurePoints = 3
                                    },
                                };
                                BattleMechHitLocation mhlLeftArm =  new BattleMechHitLocation()
                                {
                                    Name = "LA",
                                    ArmorFacings = new Dictionary<string, ArmorFacing>()
                                    {
                                        { "LA", new ArmorFacing() { Name = "LA" } }
                                    },
                                    CriticalSlotCount = 6,
                                    Structure = new StructureLocation()
                                    {

                                        Name = "LA",
                                        StructureType = retval.StructureType,
                                        MaxStructurePoints = 3,
                                        StructurePoints = 3
                                    },
                                };
                                BattleMechHitLocation mhlLeftTorso = new BattleMechHitLocation()
                                {
                                    Name = "LT",
                                    ArmorFacings = new Dictionary<string, ArmorFacing>()
                                    {
                                        { "LT", new ArmorFacing() { Name = "LT" } },
                                        { "RTL", new ArmorFacing() { Name = "RTL" } },
                                    },
                                    CriticalSlotCount = 6,
                                    Structure = new StructureLocation()
                                    {

                                        Name = "LT",
                                        StructureType = retval.StructureType,
                                        MaxStructurePoints = 3,
                                        StructurePoints = 3
                                    },
                                };
                                BattleMechHitLocation mhlRightArm = new BattleMechHitLocation()
                                {
                                    Name = "RA",
                                    ArmorFacings = new Dictionary<string, ArmorFacing>()
                                    {
                                        { "RA", new ArmorFacing() { Name = "RA" } }
                                    },
                                    CriticalSlotCount = 6,
                                    Structure = new StructureLocation()
                                    {

                                        Name = "RA",
                                        StructureType = retval.StructureType,
                                        MaxStructurePoints = 3,
                                        StructurePoints = 3
                                    },
                                };
                                BattleMechHitLocation mhlRightTorso = new BattleMechHitLocation()
                                {
                                    Name = "RT",
                                    ArmorFacings = new Dictionary<string, ArmorFacing>()
                                    {
                                        { "RT", new ArmorFacing() { Name = "RT" } },
                                        { "RTR", new ArmorFacing() { Name = "RTR" } },
                                    },
                                    CriticalSlotCount = 6,
                                    Structure = new StructureLocation()
                                    {

                                        Name = "RT",
                                        StructureType = retval.StructureType,
                                        MaxStructurePoints = 3,
                                        StructurePoints = 3
                                    },
                                };
                                BattleMechHitLocation mhlCenterTorso = new BattleMechHitLocation()
                                {
                                    Name = "CT",
                                    ArmorFacings = new Dictionary<string, ArmorFacing>()
                                    {
                                        { "CT", new ArmorFacing() { Name = "CT" } },
                                        { "RTC", new ArmorFacing() { Name = "RTC" } },
                                    },
                                    CriticalSlotCount = 6,
                                    Structure = new StructureLocation()
                                    {

                                        Name = "CT",
                                        StructureType = retval.StructureType,
                                        MaxStructurePoints = 3,
                                        StructurePoints = 3
                                    },
                                };
                                BattleMechHitLocation mhlLeftLeg = new BattleMechHitLocation()
                                {
                                    Name = "LL",
                                    ArmorFacings = new Dictionary<string, ArmorFacing>()
                                    {
                                        { "LL", new ArmorFacing() { Name = "" } }
                                    },
                                    CriticalSlotCount = 6,
                                    Structure = new StructureLocation()
                                    {

                                        Name = "LL",
                                        StructureType = retval.StructureType,
                                        MaxStructurePoints = 3,
                                        StructurePoints = 3
                                    },
                                };
                                BattleMechHitLocation mhlRightLeg = new BattleMechHitLocation()
                                {
                                    Name = "RL",
                                    ArmorFacings = new Dictionary<string, ArmorFacing>()
                                    {
                                        { "RL", new ArmorFacing() { Name = "RL" } }
                                    },
                                    CriticalSlotCount = 6,
                                    Structure = new StructureLocation()
                                    {

                                        Name = "RL",
                                        StructureType = retval.StructureType,
                                        MaxStructurePoints = 3,
                                        StructurePoints = 3
                                    },
                                };
                                retval.HitLocations.Add(mhlHead);
                                retval.HitLocations.Add(mhlLeftArm);
                                retval.HitLocations.Add(mhlLeftTorso);
                                retval.HitLocations.Add(mhlCenterTorso);
                                retval.HitLocations.Add(mhlRightTorso);
                                retval.HitLocations.Add(mhlRightArm);
                                retval.HitLocations.Add(mhlLeftLeg);
                                retval.HitLocations.Add(mhlRightLeg);
                            }
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
                            int iSpaceIndex = kvp.Value.IndexOf(' ');
                            if(iSpaceIndex==-1)
                            {
                                throw new Exception(string.Format("Invalid Engine Type: {0}", kvp.Value));
                            }
                            string sRating = kvp.Value.Substring(0, iSpaceIndex);
                            string sType = kvp.Value.Substring(iSpaceIndex).Trim();
                            int iRating = 0;
                            if(!int.TryParse(sRating,out iRating))
                            {
                                throw new Exception(string.Format("Unable to parse engine rating: {0}", sRating));
                            }
                            //Remove the work Engine from Engine Type
                            sType = sType.Replace("Engine", "").Trim();
                            //Convert just Fusion to Standard to match TechManual terminology.
                            if (sType.Equals("Fusion", StringComparison.CurrentCultureIgnoreCase)) sType = "Standard";
                            retval.Engine = new Common.ComponentEngine(iRating, sType);
                        }
                        if(kvp.Key == "Structure")
                        {
                            foreach(StructureType curStructureType in StructureType.GetCanonicalStructureTypes())
                            {
                                if(curStructureType.Name.Equals(kvp.Value,StringComparison.CurrentCultureIgnoreCase))
                                {
                                    retval.StructureType = curStructureType;
                                }
                            }
                            foreach(BattleMechHitLocation bmhl in retval.HitLocations)
                            {
                                int iStructureAmount = BattleMechDesign.InternalStructureByLocation(bmhl.Name, (int)retval.Tonnage);
                                bmhl.Structure.MaxStructurePoints = iStructureAmount;
                                bmhl.Structure.StructurePoints = iStructureAmount;
                            }
                            if (retval.StructureType == null) throw new Exception(string.Format("Cannot find structure type: {0}", kvp.Value));
                        }

                        if (kvp.Key == "Myomer")
                        {
                            foreach (MyomerType curMyomerType in MyomerType.GetCanonicalMyomerTypes())
                            {
                                if (curMyomerType.Name.Equals(kvp.Value, StringComparison.CurrentCultureIgnoreCase))
                                {
                                    retval.MyomerType = curMyomerType;
                                }
                            }
                            if (retval.MyomerType == null) throw new Exception(string.Format("Cannot find Myomer type: {0}", kvp.Value));
                        }

                        if (kvp.Key == "Armor")
                        {
                            foreach (ArmorType curArmorType in ArmorType.CanonicalArmorTypes())
                            {
                                if (curArmorType.Name.Equals(kvp.Value, StringComparison.CurrentCultureIgnoreCase))
                                {
                                    foreach(BattleMechHitLocation hitLocation in retval.HitLocations)
                                    {
                                        foreach(ArmorFacing armorFacing in hitLocation.ArmorFacings.Values)
                                        {
                                            armorFacing.ArmorType = curArmorType;
                                        }
                                    }
                                }
                            }
                            if (retval.MyomerType == null) throw new Exception(string.Format("Cannot find Myomer type: {0}", kvp.Value));
                        }
                        if (kvp.Key.Contains(" Armor"))
                        {
                            int iArmorAmount = int.Parse(kvp.Value);
                            string sArmorLocationKey = kvp.Key.Replace(" Armor", "").Trim();
                            foreach(BattleMechHitLocation bmhl in retval.HitLocations)
                            {
                                if (bmhl.ArmorFacings.ContainsKey(sArmorLocationKey))
                                {
                                    bmhl.ArmorFacings[sArmorLocationKey].ArmorPoints = iArmorAmount;
                                }
                            }

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
