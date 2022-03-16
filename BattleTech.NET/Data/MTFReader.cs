using BattleTechNET.Common;
using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
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
            {"Head",12 } //MTFs have 12 slots in the head.
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
                bool bGyroscope = false;
                bool bCockpit = false;
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

                if(dVersion > 1.2)
                {
                    //TODO: We need to add Ejection support for v1.2
                    //TODO: We need to add support for v1.3
                    throw new Exception(string.Format("Current Implementation only supports MTF Version 1.0.  File is version {0}", sVersionFields[1]));
                }

                //Get Model and Variant
                if (sLines[1].Trim() != "") retval.Model = sLines[1]; else throw new Exception("File does not contain a model name");
                if (sLines[2].Trim() != "") retval.Variant = sLines[2];
                retval.HitLocations = new List<HitLocation>();
                retval.Components = new List<UnitComponent>();
                bool bTextMode = false;
                int iLoadedHitLocations = 0;
                string sConfig = "";
                for (int i = 3;i < sLines.Length;i ++)
                {
                    if(sLines[i] != "" && !bTextMode)
                    {
                        
                        KeyValuePair<string, string> kvp = GetKVP(sLines[i]);
                        //if (kvp.Key.Equals("Overview", StringComparison.CurrentCultureIgnoreCase)) bTextMode = true;
                        if (kvp.Key.Equals("Config",StringComparison.CurrentCultureIgnoreCase))
                        {
                            sConfig = kvp.Value;
                            if(sConfig.Contains("Tripod"))
                            {
                                //TODO: Support Tripods
                                throw new Exception("Tripods not supported");
                            }
                            if (sConfig.Contains("LAM"))
                            {
                                //TODO: Support LAMs
                                throw new Exception("LAMs not supported");
                            }
                            if (sConfig.Contains("QuadVee"))
                            {
                                //TODO: Support QuadVees
                                throw new Exception("QuadVees not supported");
                            }
                            if (sConfig.Equals("Biped",StringComparison.InvariantCultureIgnoreCase) ||
                                sConfig.Equals("Biped OmniMech", StringComparison.InvariantCultureIgnoreCase))
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

                            if(sConfig.Equals("Quad",StringComparison.InvariantCultureIgnoreCase)||
                                sConfig.Equals("Quad OmniMech", StringComparison.InvariantCultureIgnoreCase))
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
                                }.AddAlias("Left Arm") as BattleMechHitLocation;
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
                                }.AddAlias("Right Arm") as BattleMechHitLocation;
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
                                }.AddAlias("Left Leg") as BattleMechHitLocation; ;
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
                                }.AddAlias("Right Leg") as BattleMechHitLocation; ;
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
                        if (kvp.Key.Equals("TechBase", StringComparison.CurrentCultureIgnoreCase))
                        {
                            bool bValidTechBase = false;
                            if(Utilities.IsSynonymFor(kvp.Value,"Inner Sphere"))
                            {
                                retval.TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE;
                                bValidTechBase = true;
                            }
                            if (Utilities.IsSynonymFor(kvp.Value, "Clan"))
                            {
                                retval.TechnologyBase = TECHNOLOGY_BASE.CLAN;
                                bValidTechBase = true;
                            }
                            if (Utilities.IsSynonymFor(kvp.Value, "Mixed (IS Chassis)"))
                            {
                                retval.TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE;
                                retval.MixedTechBase = true;
                                bValidTechBase = true;
                            }
                            if (Utilities.IsSynonymFor(kvp.Value, "Mixed (Clan Chassis)"))
                            {
                                retval.TechnologyBase = TECHNOLOGY_BASE.CLAN;
                                retval.MixedTechBase = true;
                                bValidTechBase = true;
                            }
                            if (!bValidTechBase) throw new Exception($"Could not identify Tech Base {kvp.Value}");

                        }
                        if (kvp.Key.Equals("Mass", StringComparison.CurrentCultureIgnoreCase))
                        {
                            int iMass = 0;
                            if(!int.TryParse(kvp.Value, out iMass))
                            {
                                throw new Exception(string.Format("Unable to parse mass: {0}", kvp.Value));
                            }
                            retval.Tonnage = iMass;
                        }
                        if(kvp.Key.Equals("Gyro",StringComparison.CurrentCultureIgnoreCase) && kvp.Value.Trim() != "")
                        {
                            ComponentGyro gyro = new ComponentGyro(retval.Engine.EngineRating, kvp.Value);
                            HitLocation hit = retval.GetHitLocationByName("CT");

                            retval.Components.Add( new UnitComponent(gyro,hit));
                            bGyroscope = true;
                        }
                        if(kvp.Key.Equals("Engine",StringComparison.CurrentCultureIgnoreCase))
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
                            //Remove the word Engine from Engine Type
                            sType = sType.Replace("Engine", "").Trim();
                            //Remove (Inner Sphere) from Engine Type
                            sType = sType.Replace("(Inner Sphere)", "").Trim();
                            //Remove Large from Engine Type
                            sType = sType.Replace("Large", "").Trim();
                            //Normalize the Engine Type
                            foreach (string sEngineType in ComponentEngine.GetEngineTypes())
                            {
                                if (Utilities.IsSynonymFor(sEngineType, sType)) sType = sEngineType;
                            }
                            retval.Engine = new Common.ComponentEngine(iRating, sType);
                            
                            

                        }
                        if (kvp.Key.Equals("Structure", StringComparison.CurrentCultureIgnoreCase))
                        {
                            foreach(StructureType curStructureType in StructureType.GetCanonicalStructureTypes())
                            {
                                if((curStructureType.Name.Equals(kvp.Value,StringComparison.CurrentCultureIgnoreCase) ||
                                   Utilities.IsSynonymFor (curStructureType,kvp.Value)) &&
                                   retval.IsCompatible(curStructureType)
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
                                bmhl.Structure.StructureType = retval.StructureType;
                            }
                            if (retval.StructureType == null) throw new Exception(string.Format("Cannot find structure type: {0}", kvp.Value));
                        }
                        if (kvp.Key.Equals("Myomer", StringComparison.CurrentCultureIgnoreCase))
                        {
                            //Note: MTF Files frequently list Standard Myomer, 
                            //but subsequently have MASC critical hit locations
                            //so we also need to do a post-read pass to change
                            //the file if necessary.
                            foreach (MyomerType curMyomerType in MyomerType.GetCanonicalMyomerTypes())
                            {
                                if ((curMyomerType.Name.Equals(kvp.Value, StringComparison.CurrentCultureIgnoreCase) ||
                                    Utilities.IsSynonymFor(curMyomerType, kvp.Value)) &&
                                    retval.IsCompatible(curMyomerType)
                                    )
                                {
                                    retval.MyomerType = curMyomerType;
                                }
                            }
                            if (retval.MyomerType == null) throw new Exception(string.Format("Cannot find Myomer type: {0}", kvp.Value));
                        }
                        if (kvp.Key.Equals("Armor", StringComparison.CurrentCultureIgnoreCase))
                        {
                            foreach (ArmorType curArmorType in ArmorType.CanonicalArmorTypes())
                            {
                                if (Utilities.IsSynonymFor(curArmorType,kvp.Value) && 
                                    retval.IsCompatible(curArmorType)
                                    )
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
                        if (kvp.Key.Contains(" Armor") || kvp.Key.Contains(" armor"))
                        {
                            int iArmorAmount = 0;
                            if (!int.TryParse(kvp.Value, out iArmorAmount))
                                throw new Exception($"Unable to get value from {kvp.Key}:{kvp.Value} at line {i+1}.");
                            string sArmorLocationKey = kvp.Key.Replace(" Armor", "").Replace(" armor","").Trim();
                            foreach(BattleMechHitLocation bmhl in retval.HitLocations)
                            {
                                if (bmhl.ArmorFacings.ContainsKey(sArmorLocationKey))
                                {
                                    bmhl.ArmorFacings[sArmorLocationKey].ArmorPoints = iArmorAmount;
                                }
                            }

                        }
                        if(kvp.Key.Equals("Cockpit",StringComparison.CurrentCultureIgnoreCase) && kvp.Value != "")
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
                                if(Utilities.IsSynonymFor(cockpit,sCockpitType))
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
                            bCockpit = true;
                        }
                        if(kvp.Key.Equals("Jump MP", StringComparison.CurrentCultureIgnoreCase))
                        {
                            //Is this needed?  Do we care?
                            int iJumpMP = int.Parse(kvp.Value);
                        }
                        if(kvp.Key.Equals("mul id",StringComparison.CurrentCultureIgnoreCase))
                        {
                            //This is the Master Unit List ID Number
                            //We don't do anything with it.
                            //But it does throw off our Config expectations
                            continue;
                        }
                        //This is where we load the slot for critical hit locations.
                        foreach(string sKey in CriticalHitSlotCount.Keys)
                        {
                            if (Utilities.IsSynonymFor(kvp.Key.Trim(), sKey.Replace(":", "")))
                            {
                                BattleMechHitLocation selectedLocation = null;
                                foreach (BattleMechHitLocation bmhl in retval.HitLocations)
                                {
                                    if (Utilities.IsSynonymFor(bmhl, sKey)|| Utilities.IsSynonymFor(bmhl.Name, sKey))
                                    {
                                        selectedLocation = bmhl;
                                    }
                                }
                                iLoadedHitLocations++;
                                for (int j = 0; j<CriticalHitSlotCount[sKey];j++)
                                {
                                    i++;

                                    if (i == sLines.Length)
                                        j = CriticalHitSlotCount[sKey];
                                    else if (sLines[i].Trim() == "" )
                                        j = CriticalHitSlotCount[sKey];
                                    else
                                    {
                                        CriticalSlot criticalSlot = new CriticalSlot() { Label = sLines[i].Replace("(omnipod)","").Replace("(OMNIPOD)","").Trim(), Location = selectedLocation, SlotNumber = j ,Omnipod = sLines[i].Contains("(omnipod)")};
                                        if (Utilities.IsSynonymFor(criticalSlot.Label, "-Empty-")) criticalSlot.RollAgain = true;
                                        foreach(ComponentAmmunition componentAmmunition in ComponentLibrary.Ammunitions)
                                        {
                                            if(Utilities.IsSynonymFor(componentAmmunition, criticalSlot.Label) &&
                                                retval.IsCompatible(componentAmmunition))
                                            {
                                                criticalSlot.AffectedComponent = new UnitComponent(componentAmmunition.Clone() as Component, selectedLocation);
                                                retval.Components.Add(criticalSlot.AffectedComponent);
                                            }
                                        }
                                        if (criticalSlot.Label.Contains("Ammo") && criticalSlot.AffectedComponent == null)
                                        {
                                            System.Diagnostics.Debug.WriteLine($"{criticalSlot.Label}");
                                        }
                                        /*
                                        if (Utilities.IsSynonymFor(criticalSlot.Label, "CASE"))
                                        {
                                            ComponentCASE caseComponent = new ComponentCASE(retval);
                                            criticalSlot.AffectedComponent = new UnitComponent(caseComponent, selectedLocation);
                                            retval.Components.Add(criticalSlot.AffectedComponent);
                                        }*/
                                        if (selectedLocation == null) Console.WriteLine("Test");
                                        selectedLocation.AddCriticalSlot(criticalSlot);
                                    }
                                }

                            }
                            if (iLoadedHitLocations == retval.HitLocations.Count) bTextMode = true;
                            
                        }
                        if (kvp.Key.Equals("Heat Sinks",StringComparison.CurrentCultureIgnoreCase))
                        {
                            string[] sFields = kvp.Value.Split(' ');
                            int iHeatSinkCount = int.Parse(sFields[0]);
                            string sHeatSinkSize = sFields[1];
                            ComponentHeatSink componentHeatSinkTemplate = new ComponentHeatSink();
                            bool bSingle = true;
                            
                            if(sHeatSinkSize == "Double")
                            {
                                bSingle = false;
                            }
                            HitLocation hl = retval.GetHitLocationByName("CT");
                            int iIntegralHeatSinks = (int)Math.Truncate((double)retval.Engine.EngineRating / 25D);
                            for(int j=0;j<iHeatSinkCount;j++)
                            {
                                
                                    //Integral Heatsink
                                    retval.Components.Add(new UnitComponent() { Component = new ComponentHeatSink(retval.TechnologyBase, bSingle, j<iIntegralHeatSinks ,j<10),HitLocation=hl });
                               
                            }
                            
                        }
                        if (kvp.Key.Equals("Weapons",StringComparison.CurrentCultureIgnoreCase))
                        {
                            //This is just unreliable.  (Caesar CES-4R has wrong value,
                            //FS9-B has too high a value.)
                            int iWeaponsCount = int.Parse(kvp.Value);
                            bool bCountWeapons = true;
                            while(bCountWeapons)
                            {
                                if (sLines[++i].Trim() == "")
                                    //Added because the 3050U FS9-B lies about
                                    //its weapon count.
                                    bCountWeapons = false;
                                else
                                {
                                    string[] sTerms = sLines[i].Trim().Split(',');
                                    string sComponentName = sTerms[0].Trim();
                                    string sHitLocation = sTerms[1].Trim();
                                    bool bRearMounted = false;
                                    if (sHitLocation.Contains("(R)"))
                                    {
                                        bRearMounted = true;
                                        sHitLocation = sHitLocation.Replace("(R)", "").Trim();
                                    }
                                    int iNumberOfEntries = 1;
                                    string[] sFirstTerm = sComponentName.Split(' ');
                                    int EntryCount = 0;
                                    if (int.TryParse(sFirstTerm[0], out EntryCount))
                                    {
                                        iNumberOfEntries = EntryCount;
                                        sComponentName = sComponentName.Substring(sFirstTerm[0].Length + 1);
                                    }

                                    Component c = null;
                                    if (sComponentName.EndsWith("(R)")) sComponentName = sComponentName.Replace("(R)", "").Trim(); ;
                                    //List<ComponentWeapon> candidateWeapons = new List<ComponentWeapon>();
                                    foreach (ComponentWeapon weaponComponent in ComponentLibrary.Weapons.Values)
                                    {
                                        if (Utilities.IsSynonymFor(weaponComponent, sComponentName))
                                        {
                                            if (retval.IsCompatible(weaponComponent))
                                                c = weaponComponent.Clone() as ComponentWeapon;
                                        }
                                    }

                                    BattleMechHitLocation hitLocation = null;
                                    foreach (BattleMechHitLocation bmhl in retval.HitLocations)
                                    {
                                        if (Utilities.IsSynonymFor(bmhl.Name, sHitLocation) || bmhl.Name.Equals(sHitLocation))
                                            hitLocation = bmhl;
                                    }
                                    if (hitLocation == null) throw new Exception($"Could not find location {sHitLocation} for {sLines[i]}");

                                    

                                    if (c == null)
                                    {
                                        // Is this an ECW system?  MTF files 
                                        // sometimes list ECM as a weapon, but we 
                                        // read them in later in the MTF load.
                                        bool bIsECM = false;
                                        foreach (ComponentElectronicWarfare componentElectronicWarfare in ComponentElectronicWarfare.CanonicalECMs)
                                        {
                                            if (Utilities.IsSynonymFor(componentElectronicWarfare,sComponentName))
                                            {
                                                bIsECM = true;
                                            }
                                        }

                                        // If it isn't an ECW system we need to
                                        // throw an exception, because we don't
                                        // know what this weapon is supposed to
                                        // be
                                        if (!bIsECM)
                                            throw new Exception($"Could not find weapon {sComponentName} for {sLines[i]}");
                                    }
                                    else
                                    {
                                        c = (Component)c.Clone();
                                        int iCriticalSlots = c.CriticalSpaceMech??0;
                                        
                                        //TODO: There's a side case here where
                                        //we have Rear Mounted Weapons with the
                                        //same component name as front-facing
                                        //components in the same location.
                                        UnitComponent comp = new UnitComponent() { Component = c, HitLocation = hitLocation, RearFacing = bRearMounted };
                                        
                                        IDesignConfigured designConfigured = c as IDesignConfigured;
                                        if (designConfigured != null) designConfigured.Configure(retval);
                                        for (int iRepeats = 0; iRepeats < iNumberOfEntries; iRepeats++)
                                            retval.Components.Add(comp);
                                    }
                                }
                            }

                        }

                    }
                    
                }

                if(!bGyroscope)
                {
                    ComponentGyro gyro = new ComponentGyro(retval.Engine.EngineRating, "Standard Gyro");
                    HitLocation hit = retval.GetHitLocationByName("CT");

                    retval.Components.Add(new UnitComponent(gyro, hit));
                    bGyroscope = true;
                }

                if (!bCockpit)
                {
                    List<ComponentCockpit> cockpits = ComponentCockpit.GetCanonicalCockpits();
                    ComponentCockpit selectedCockpit = null;
                    string sCockpitType = "Standard Cockpit";
                    foreach (ComponentCockpit cockpit in cockpits)
                    {
                        if (cockpit.Name.Equals(sCockpitType) || Utilities.IsSynonymFor(sCockpitType, cockpit.Name))
                        {
                            selectedCockpit = cockpit;
                        }
                    }

                    HitLocation hit = retval.GetHitLocationByName("HD");

                    retval.Components.Add(new UnitComponent(selectedCockpit, hit));
                    bCockpit = true;
                }

                //Install Jump Jets 
                ComponentJumpJet.ResolveComponent(retval);

                //Install any Electronic Warfare components
                ComponentElectronicWarfare.ResolveComponent(retval);

                //Install any FCS systems
                ComponentFireControlSystem.ResolveComponent(retval);

                //Install any Targeting Computer
                ComponentTargetingComputer.ResolveComponent(retval);

                //Install any Communications Equipment
                ComponentCommunicationsEquipment.ResolveComponent(retval);

                //Install any Vibroblades
                ComponentVibroblade.ResolveComponent(retval);

                //Install Mace
                ComponentMace.ResolveComponent(retval);

                //Install Spikes
                ComponentSpike.ResolveComponent(retval);

                ComponentCoolantPod.ResolveComponents(retval);
                ComponentSupercharger.ResolveComponents(retval);
                ComponentPPCCapacitor.ResolveComponents(retval);
                ComponentCASE.ResolveComponent(retval);
                ComponentRetractableBlade.ResolveComponents(retval);

                //The collapsible command center needs to have all of its
                //critical hit slots in the same Torso.
                BattleMechHitLocation leftTorso = retval.GetHitLocationByName("LT") as BattleMechHitLocation;
                BattleMechHitLocation rightTorso = retval.GetHitLocationByName("RT") as BattleMechHitLocation;
                
                int iLeftCCM = 0;
                foreach(CriticalSlot slot in leftTorso.CriticalSlots)
                {
                    if(Utilities.IsSynonymFor(slot.Label, "ISCollapsibleCommandModule"))
                    {
                        iLeftCCM++;
                    }
                }
                int iRightCCM = 0;
                foreach (CriticalSlot slot in rightTorso.CriticalSlots)
                {
                    if (Utilities.IsSynonymFor(slot.Label, "ISCollapsibleCommandModule"))
                    {
                        iRightCCM++;
                    }
                }
                if (iLeftCCM > 0 && iLeftCCM < 12) throw new Exception($"CCM Module exception: Only {iLeftCCM}/12 entries in Left Torso.");
                if (iRightCCM > 0 && iRightCCM < 12) throw new Exception($"CCM Module exception: Only {iRightCCM}/12 entries in Right Torso.");
                if (iLeftCCM == 12)
                {
                    Component CollapsibleCommandModule = new Component()
                    {
                        Name = "Collapsible Command Module",
                        BaseCost = 500000,
                        TechnologyBase = retval.TechnologyBase,
                        Tonnage = 16
                    };
                    UnitComponent uc = new UnitComponent(CollapsibleCommandModule, leftTorso);
                    foreach (CriticalSlot slot in leftTorso.CriticalSlots) slot.AffectedComponent = uc;
                    retval.Components.Add(uc);
                }
                if (iRightCCM == 12)
                {
                    Component CollapsibleCommandModule = new Component()
                    {
                        Name = "Collapsible Command Module",
                        BaseCost = 500000,
                        TechnologyBase = retval.TechnologyBase,
                        Tonnage = 16
                    };
                    UnitComponent uc = new UnitComponent(CollapsibleCommandModule, rightTorso);
                    foreach (CriticalSlot slot in rightTorso.CriticalSlots) slot.AffectedComponent = uc;
                    retval.Components.Add(uc);
                }

                


                //There's an issue with Hatchets because they don't always 
                //appear on the Weapons list in MTF files.  We need to check if
                //there's one on either arm.
                if (sConfig == "Biped")
                {
                    BattleMechHitLocation leftArm = retval.GetHitLocationByName("LA") as BattleMechHitLocation;
                    BattleMechHitLocation rightArm = retval.GetHitLocationByName("RA") as BattleMechHitLocation;
                    if (leftArm == null) throw new Exception("No Left Arm");
                    if (rightArm == null) throw new Exception("No Right Arm");
                    if (leftArm.CriticalSlots == null) throw new Exception("No Left Arm Critical Hit Slots");
                    if (rightArm.CriticalSlots == null) throw new Exception("No Right Arm Critical Hit Slots");
                    bool bLeftArmHatchet = false, bRightArmHatchet = false, bLeftArmSword = false, bRightArmSword = false;
                    foreach (CriticalSlot curCriticalSlot in leftArm.CriticalSlots)
                    {
                        if (curCriticalSlot.Label.Equals("Hatchet"))
                            bLeftArmHatchet = true;
                        if (curCriticalSlot.Label.Equals("Sword"))
                            bLeftArmSword = true;
                    }
                    foreach (CriticalSlot curCriticalSlot in rightArm.CriticalSlots)
                    {
                        if (curCriticalSlot.Label.Equals("Hatchet"))
                            bRightArmHatchet = true;
                        if (curCriticalSlot.Label.Equals("Sword"))
                            bRightArmSword = true;
                    }

                    bool bExistingLeftArmSword = false;
                    bool bExistingRightArmSword = false;
                    bool bExistingRightArmHatchet = false;
                    bool bExistingLeftArmHatchet = false;
                    
                    foreach (UnitComponent curComponent in retval.Components)
                    {
                        if(Utilities.IsSynonymFor(curComponent.HitLocation.Name,"LA"))
                        {
                            if (Utilities.IsSynonymFor(curComponent.Component, "Sword"))
                                bExistingLeftArmSword = true;
                            if (Utilities.IsSynonymFor(curComponent.Component, "Hatchet"))
                                bExistingLeftArmHatchet = true;
                        }
                        if (Utilities.IsSynonymFor(curComponent.HitLocation.Name, "RA"))
                        {
                            if (Utilities.IsSynonymFor(curComponent.Component, "Sword"))
                                bExistingRightArmSword = true;
                            if (Utilities.IsSynonymFor(curComponent.Component, "Hatchet"))
                                bExistingRightArmHatchet = true;
                        }
                    }

                    if (bLeftArmHatchet && !bExistingLeftArmHatchet)
                    {
                        ComponentHatchet hatchet = new ComponentHatchet(retval);
                        retval.Components.Add(new UnitComponent(hatchet, leftArm));
                    }

                    if (bRightArmHatchet && !bExistingRightArmHatchet)
                    {
                        ComponentHatchet hatchet = new ComponentHatchet(retval);
                        retval.Components.Add(new UnitComponent(hatchet, rightArm));
                    }
                    if (bLeftArmSword && !bExistingLeftArmSword)
                    {
                        ComponentSword sword = new ComponentSword(retval);
                        retval.Components.Add(new UnitComponent(sword, leftArm));
                    }

                    if (bRightArmSword && !bExistingRightArmSword)
                    {
                        ComponentSword sword = new ComponentSword(retval);
                        retval.Components.Add(new UnitComponent(sword, rightArm));
                    }

                }

                //A number of MTF files will list the Myomer as Standard for
                //MASC-equipped BattleMechs.  We need to search for MASC crit
                //slots to see if this is a MASC-equipped Mech.
                foreach(BattleMechHitLocation bmhl in retval.HitLocations)
                {
                    if(bmhl.CriticalSlots != null)
                    foreach(CriticalSlot criticalSlot in bmhl.CriticalSlots)
                        {
                            foreach (MyomerType myomerType in MyomerType.GetCanonicalMyomerTypes())
                            {
                                if (Utilities.IsSynonymFor(criticalSlot.Label, myomerType.Name) && 
                                    retval.IsCompatible(myomerType))
                                    {
                                    retval.MyomerType = myomerType;
                                    }

                            }
                        }
                }



                foreach (UnitComponent unitComponent in retval.Components)
                {
                    ComponentWeapon weapon = unitComponent.Component as ComponentWeapon;
                    if (weapon != null)
                    {
                        int iCriticalSlots = weapon.CriticalSpaceMech??0;
                        BattleMechHitLocation bmhl = unitComponent.HitLocation as BattleMechHitLocation;
                        foreach (CriticalSlot slot in bmhl.CriticalSlots)
                        {
                            if (iCriticalSlots > 0)
                                if (slot.AffectedComponent == null)
                                {
                                    string sLabel = slot.Label;
                                    if (sLabel.Contains("(R)")) { sLabel = sLabel.Replace("(R)", "").Trim(); unitComponent.RearFacing = true; }
                                    if (Utilities.IsSynonymFor(weapon, sLabel))
                                    {
                                        iCriticalSlots--;
                                        slot.AffectedComponent = unitComponent;

                                    }
                                }
                        }
                    }
                }
                //A-Pods and B-Pods don't show up on the weapons list is most
                //MTF files that contain them.
                foreach (BattleMechHitLocation bmhl in retval.HitLocations)
                {
                    if (bmhl.CriticalSlots != null)
                        foreach (CriticalSlot criticalSlot in bmhl.CriticalSlots)
                        {
                            string sSlotName = criticalSlot.Label.Replace("(omnipod)", "").Replace("(OMNIPOD)", "").Trim();
                            foreach (Component weapon in ComponentLibrary.Weapons.Values)
                            {
                                ComponentAntiPersonnelPod antiPersonnelPod = weapon as ComponentAntiPersonnelPod;
                                
                                if (antiPersonnelPod != null)
                                {
                                    if (Utilities.IsSynonymFor(antiPersonnelPod, sSlotName) )
                                        if
                                        (retval.IsCompatible(antiPersonnelPod))
                                    {
                                        UnitComponent unitComponent = new UnitComponent(antiPersonnelPod.Clone() as Component, bmhl);
                                        retval.Components.Add(unitComponent);
                                    }
                                }
                            }   
                        }
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Exception reading Battlemech Design",ex);
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
