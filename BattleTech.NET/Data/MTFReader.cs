using BattleTechNET.Common;
using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace BattleTechNET.Data
{
    /// <summary>
    /// Class for reading MegaMek files for design data.
    /// </summary>
    public static class MTFReader
    {
        public static Dictionary<string, int> CriticalHitSlotCount = new Dictionary<string, int>()
        {
            {"Front Left Leg",12 },
            {"Front Right Leg",12 },
            {"Rear Right Leg",12 },
            {"Rear Left Leg",12 },
            {"Left Leg",12 },
            {"Right Leg",12 },
            {"Left Torso",12 },
            {"Right Torso",12 },
            {"Center Torso",12 },
            {"Left Arm",12 },
            {"Right Arm",12 },
            {"Head",12 }
        };

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

                if(dVersion > 1.1)
                {
                    throw new Exception(string.Format("Current Implementation only supports MTF Version 1.0.  File is version {0}", sVersionFields[1]));
                }

                //Get Model and Variant
                if (sLines[1].Trim() != "") retval.Model = sLines[1]; else throw new Exception("File does not contain a model name");
                if (sLines[2].Trim() != "") retval.Variant = sLines[2];
                retval.HitLocations = new List<HitLocation>();
                retval.Components = new List<UnitComponent>();
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
                                    CriticalSlotCount = CriticalHitSlotCount["Head"],
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
                                    CriticalSlotCount = CriticalHitSlotCount["Left Arm"],
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
                                    CriticalSlotCount = CriticalHitSlotCount["Left Torso"],
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
                                    CriticalSlotCount = CriticalHitSlotCount["Right Arm"],
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
                                    CriticalSlotCount = CriticalHitSlotCount["Right Torso"],
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
                                    CriticalSlotCount = CriticalHitSlotCount["Center Torso"],
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
                                        { "LL", new ArmorFacing() { Name = "LL" } }
                                    },
                                    CriticalSlotCount = CriticalHitSlotCount["Left Leg"],
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
                                    CriticalSlotCount = CriticalHitSlotCount["Right Leg"],
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

                            if(sConfig.Equals("Quad",StringComparison.InvariantCultureIgnoreCase))
                            {
                                BattleMechHitLocation mhlHead = new BattleMechHitLocation()
                                {
                                    Name = "HD",
                                    ArmorFacings = new Dictionary<string, ArmorFacing>()
                                    {
                                        { "HD", new ArmorFacing() { Name = "HD" } }
                                    },
                                    CriticalSlotCount = CriticalHitSlotCount["Head"],
                                    Structure = new StructureLocation()
                                    {

                                        Name = "HD",
                                        StructureType = retval.StructureType,
                                        MaxStructurePoints = 3,
                                        StructurePoints = 3
                                    },
                                };
                                BattleMechHitLocation mhlFrontLeftLeg = new BattleMechHitLocation()
                                {
                                    Name = "FLL",
                                    ArmorFacings = new Dictionary<string, ArmorFacing>()
                                    {
                                        { "FLL", new ArmorFacing() { Name = "FLL" } }
                                    },
                                    CriticalSlotCount = CriticalHitSlotCount["Front Left Leg"],
                                    Structure = new StructureLocation()
                                    {

                                        Name = "FLL",
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
                                    CriticalSlotCount = CriticalHitSlotCount["Left Torso"],
                                    Structure = new StructureLocation()
                                    {

                                        Name = "LT",
                                        StructureType = retval.StructureType,
                                        MaxStructurePoints = 3,
                                        StructurePoints = 3
                                    },
                                };
                                BattleMechHitLocation mhlFrontRightLeg = new BattleMechHitLocation()
                                {
                                    Name = "FRL",
                                    ArmorFacings = new Dictionary<string, ArmorFacing>()
                                    {
                                        { "FRL", new ArmorFacing() { Name = "FRL" } }
                                    },
                                    CriticalSlotCount = CriticalHitSlotCount["Front Right Leg"],
                                    Structure = new StructureLocation()
                                    {

                                        Name = "FRL",
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
                                    CriticalSlotCount = CriticalHitSlotCount["Right Torso"],
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
                                    CriticalSlotCount = CriticalHitSlotCount["Center Torso"],
                                    Structure = new StructureLocation()
                                    {

                                        Name = "CT",
                                        StructureType = retval.StructureType,
                                        MaxStructurePoints = 3,
                                        StructurePoints = 3
                                    },
                                };
                                BattleMechHitLocation mhlRearLeftLeg = new BattleMechHitLocation()
                                {
                                    Name = "RLL",
                                    ArmorFacings = new Dictionary<string, ArmorFacing>()
                                    {
                                        { "RLL", new ArmorFacing() { Name = "RLL" } }
                                    },
                                    CriticalSlotCount = CriticalHitSlotCount["Rear Left Leg"],
                                    Structure = new StructureLocation()
                                    {

                                        Name = "RLL",
                                        StructureType = retval.StructureType,
                                        MaxStructurePoints = 3,
                                        StructurePoints = 3
                                    },
                                };
                                BattleMechHitLocation mhlRearRightLeg = new BattleMechHitLocation()
                                {
                                    Name = "RRL",
                                    ArmorFacings = new Dictionary<string, ArmorFacing>()
                                    {
                                        { "RRL", new ArmorFacing() { Name = "RRL" } }
                                    },
                                    CriticalSlotCount = CriticalHitSlotCount["Rear Right Leg"],
                                    Structure = new StructureLocation()
                                    {

                                        Name = "RRL",
                                        StructureType = retval.StructureType,
                                        MaxStructurePoints = 3,
                                        StructurePoints = 3
                                    },
                                };
                                retval.HitLocations.Add(mhlHead);
                                retval.HitLocations.Add(mhlFrontLeftLeg);
                                retval.HitLocations.Add(mhlLeftTorso);
                                retval.HitLocations.Add(mhlCenterTorso);
                                retval.HitLocations.Add(mhlRightTorso);
                                retval.HitLocations.Add(mhlFrontRightLeg);
                                retval.HitLocations.Add(mhlRearLeftLeg);
                                retval.HitLocations.Add(mhlRearRightLeg);
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
                                if((curStructureType.Name.Equals(kvp.Value,StringComparison.CurrentCultureIgnoreCase) ||
                                   Utilities.IsSynonymFor (curStructureType.Name,kvp.Value)) &&
                                   (curStructureType.TechnologyBase == retval.TechnologyBase || curStructureType.TechnologyBase == TECHNOLOGY_BASE.BOTH)
                                   )
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
                                if ((curMyomerType.Name.Equals(kvp.Value, StringComparison.CurrentCultureIgnoreCase) ||
                                    Utilities.IsSynonymFor(curMyomerType.Name, kvp.Value)) &&
                                    (curMyomerType.TechnologyBase == retval.TechnologyBase || 
                                    curMyomerType.TechnologyBase == TECHNOLOGY_BASE.BOTH)
                                    )
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
                        if(kvp.Key.Equals("Cockpit") && kvp.Value != "")
                        {
                            string sCockpitType = kvp.Value.Trim();
                            bool bIncludeCommandConsole = false;
                            if(sCockpitType == "Command Console")
                            {
                                //MTF Files handle Command Consoles in a weird way, so
                                //we need to do some ugly adjustments here.

                                sCockpitType = "Standard Cockpit";
                                bIncludeCommandConsole = true;
                            }
                            List<ComponentCockpit> cockpits = ComponentCockpit.GetCanonicalCockpits();
                            ComponentCockpit selectedCockpit = null;
                            
                            foreach(ComponentCockpit cockpit in cockpits)
                            {
                                if(cockpit.Name.Equals(sCockpitType) || Utilities.IsSynonymFor(sCockpitType, cockpit.Name))
                                {
                                    selectedCockpit = cockpit;
                                }
                            }

                            //TODO: We need to adjust this for Torso Cockpits
                            BattleMechHitLocation actualLocation = null;
                            foreach (BattleMechHitLocation bmhl in retval.HitLocations)
                            {
                                if(Utilities.IsSynonymFor("Head",bmhl.Name) && bmhl.Name == "HD")
                                {
                                    actualLocation = bmhl;
                                }
                            }

                            if (selectedCockpit == null) 
                                throw new Exception($"Unable to find cockpit {sCockpitType}");
                            else
                                retval.Components.Add(new UnitComponent() { Component = selectedCockpit, HitLocation = actualLocation});

                            if(bIncludeCommandConsole)
                            {
                                Component commandConsole = new Component();
                                commandConsole.Name = "Command Console";
                                commandConsole.TechnologyBase = TECHNOLOGY_BASE.BOTH;
                                commandConsole.Tonnage = 3;
                                retval.Components.Add(new UnitComponent() { Component = commandConsole, HitLocation = actualLocation });
                            }
                        }

                        foreach(string sKey in CriticalHitSlotCount.Keys)
                        {
                            if(kvp.Key.Trim() == $"{sKey}:")
                            {
                                BattleMechHitLocation selectedLocation = null;
                                foreach (BattleMechHitLocation bmhl in retval.HitLocations)
                                {
                                    if (Utilities.IsSynonymFor(bmhl.Name, sKey))
                                    {
                                        selectedLocation = bmhl;
                                    }
                                }
                                for (int j = 0; j<CriticalHitSlotCount[sKey];j++)
                                {

                                    CriticalSlot criticalSlot = new CriticalSlot() { Label = sLines[++i].Trim(), Location=selectedLocation,SlotNumber = j };
                                    if (criticalSlot.Label == "-Empty-") criticalSlot.RollAgain = true;
                                    selectedLocation.CriticalSlots.Add(criticalSlot);
                                    
                                }
                            }
                        }
                        if(kvp.Key.Equals("Weapons"))
                        {
                            int iWeaponsCount = int.Parse(kvp.Value);

                            for(int j=0;j<iWeaponsCount;j++)
                            {
                                string[] sTerms = sLines[++i].Trim().Split(',');
                                string sComponentName = sTerms[0].Trim();
                                string sHitLocation = sTerms[1].Trim();
                                int iNumberOfEntries = 1;
                                string[] sFirstTerm = sComponentName.Split(' ');
                                int EntryCount = 0;
                                if(int.TryParse(sFirstTerm[0],out EntryCount))
                                {
                                    iNumberOfEntries = EntryCount;
                                    sComponentName = sComponentName.Substring(sFirstTerm[0].Length + 1);
                                }
                                
                                Component c = null;
                                foreach(string sKey in ComponentLibrary.Weapons.Keys)
                                {
                                    if(Utilities.IsSynonymFor(sComponentName,sKey) || sComponentName.Equals(sKey))
                                    {
                                        c = ComponentLibrary.Weapons[sKey];
                                    }
                                }
                                HitLocation hitLocation = null;
                                foreach(BattleMechHitLocation bmhl in retval.HitLocations)
                                {
                                    if (Utilities.IsSynonymFor(bmhl.Name, sHitLocation) || bmhl.Name.Equals(sHitLocation))
                                        hitLocation = bmhl;
                                }
                                if (hitLocation == null) throw new Exception($"Could not find location {sHitLocation} for {sLines[i]}");
                                if (c == null) throw new Exception($"Could not find weapon {sComponentName} for {sLines[i]}");
                                for(int iRepeats = 0; iRepeats<iNumberOfEntries; iRepeats++)
                                    retval.Components.Add(new UnitComponent() { Component = c, HitLocation = hitLocation });
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
