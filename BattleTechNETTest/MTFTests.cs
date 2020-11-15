using BattleTechNET.Common;
using BattleTechNET.Data;
using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace BattleTechNETTest
{
    public class MTFTests
    {
        public static string AtlasTestFile = "./TestFiles/AtlasAS7-D.mtf";
        public static string GoliathTestFile = "./TestFiles/GoliathGOL-1H.mtf";

        private readonly ITestOutputHelper _outputHelper;

        public MTFTests(ITestOutputHelper testOutputHelper)
        {
            _outputHelper = testOutputHelper;
        }



        [Fact(DisplayName = "Atlas Computed Tonnage Check")]
        public void AtlasTonnageCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            _outputHelper.WriteLine(battleMechDesign.TonnageLedger);

            Assert.Equal(100, battleMechDesign.ComputedTonnage);
            
        }

        [Fact(DisplayName = "Goliath Computed Tonnage Check")]
        public void GoliathTonnageCheck()
        {
            string sFilePath = GoliathTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);
            _outputHelper.WriteLine(battleMechDesign.TonnageLedger);
            Assert.Equal(80, battleMechDesign.ComputedTonnage);
        }

        [Fact(DisplayName ="Read Atlas Data File")]
        public void ReadAtlasFile()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            Assert.Equal("Atlas", battleMechDesign.Model);
            Assert.Equal("AS7-D", battleMechDesign.Variant);
            Assert.Equal(100, battleMechDesign.Tonnage);
            Assert.Equal(300, battleMechDesign.Engine.EngineRating);
            Assert.Equal("Standard", battleMechDesign.Engine.EngineType);
        }

        [Fact(DisplayName = "Read Goliath Data File")]
        public void ReadGoliathFile()
        {
            string sFilePath = GoliathTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            Assert.Equal("Goliath", battleMechDesign.Model);
            Assert.Equal("GOL-1H", battleMechDesign.Variant);
            Assert.Equal(80, battleMechDesign.Tonnage);
            Assert.Equal(320, battleMechDesign.Engine.EngineRating);
            Assert.Equal("Standard", battleMechDesign.Engine.EngineType);
        }

        [Fact(DisplayName = "Battlemech Model Name Read Correctly")]
        public void BattleMechModelNameCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            Assert.Equal("Atlas", battleMechDesign.Model);
        }

        [Fact(DisplayName = "Battlemech Variant Name Read Correctly")]
        public void BattleMechVariantNameCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            Assert.Equal("AS7-D", battleMechDesign.Variant);
        }

        [Fact(DisplayName = "Battlemech Tonnage Read Correctly")]
        public void BattleMechTonnageCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            Assert.Equal(100, battleMechDesign.Tonnage);
        }

        [Fact(DisplayName = "Battlemech Engine Rating Read Correctly")]
        public void BattleMechEngineTonnageCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            Assert.Equal(300, battleMechDesign.Engine.EngineRating);
        }

        [Fact(DisplayName = "Battlemech Engine Type Read Correctly")]
        public void BattleMechEngineTypeCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            Assert.Equal("Standard", battleMechDesign.Engine.EngineType);
        }

        [Fact(DisplayName = "Battlemech CT Armor Read Correctly")]
        public void BattleMechCTArmorCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "CT");
            Assert.Equal(47, Facing.ArmorPoints);
        }

        [Fact(DisplayName = "Battlemech CTR Armor Read Correctly")]
        public void BattleMechCTRArmorCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "RTC");
            Assert.Equal(14, Facing.ArmorPoints);
        }

        [Fact(DisplayName = "Battlemech RT Armor Read Correctly")]
        public void BattleMechRTArmorCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "RT");
            Assert.Equal(32, Facing.ArmorPoints);
        }

        [Fact(DisplayName = "Battlemech RTR Armor Read Correctly")]
        public void BattleMechRTRArmorCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "RTR");
            Assert.Equal(10, Facing.ArmorPoints);
        }

        [Fact(DisplayName = "Battlemech LT Armor Read Correctly")]
        public void BattleMechLRArmorCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "LT");
            Assert.Equal(32, Facing.ArmorPoints);
        }

        [Fact(DisplayName = "Battlemech LTR Armor Read Correctly")]
        public void BattleMechLTRArmorCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "RTL");
            Assert.Equal(10, Facing.ArmorPoints);
        }

        [Fact(DisplayName = "Battlemech LA Armor Read Correctly")]
        public void BattleMechLAArmorCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "LA");
            Assert.Equal(34, Facing.ArmorPoints);
        }

        [Fact(DisplayName = "Battlemech RA Armor Read Correctly")]
        public void BattleMechRAArmorCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "RA");
            Assert.Equal(34, Facing.ArmorPoints);
        }

        [Fact(DisplayName = "Battlemech HD Armor Read Correctly")]
        public void BattleMechHDArmorCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "HD");
            Assert.Equal(9, Facing.ArmorPoints);
        }

        [Fact(DisplayName = "Battlemech LL Armor Read Correctly")]
        public void BattleMechLLArmorCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "LL");
            Assert.Equal(41, Facing.ArmorPoints);
        }

        [Fact(DisplayName = "Battlemech RL Armor Read Correctly")]
        public void BattleMechRLArmorCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "RL");
            Assert.Equal(41, Facing.ArmorPoints);
        }

        [Fact(DisplayName = "Battlemech HD Structure Read Correctly")]
        public void BattlemechHDISCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            StructureLocation structure = GetBattleMechStructureLocation(battleMechDesign, "HD");
            Assert.Equal(3,structure.MaxStructurePoints);
        }

        [Fact(DisplayName = "Battlemech LA Structure Read Correctly")]
        public void BattlemechLAISCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            StructureLocation structure = GetBattleMechStructureLocation(battleMechDesign, "LA");
            Assert.Equal(17, structure.MaxStructurePoints);
        }
            [Fact(DisplayName = "Battlemech RA Structure Read Correctly")]
            public void BattlemechRAISCheck()
            {
                string sFilePath = AtlasTestFile;
                BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

                StructureLocation structure = GetBattleMechStructureLocation(battleMechDesign, "RA");
                Assert.Equal(17, structure.MaxStructurePoints);
            }

        [Fact(DisplayName = "Battlemech RT Structure Read Correctly")]
        public void BattlemechRTISCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            StructureLocation structure = GetBattleMechStructureLocation(battleMechDesign, "RT");
            Assert.Equal(21, structure.MaxStructurePoints);
        }

        [Fact(DisplayName = "Battlemech LT Structure Read Correctly")]
        public void BattlemechLTISCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            StructureLocation structure = GetBattleMechStructureLocation(battleMechDesign, "LT");
            Assert.Equal(21, structure.MaxStructurePoints);
        }
        [Fact(DisplayName = "Battlemech CT Structure Read Correctly")]
        public void BattlemechCTISCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            StructureLocation structure = GetBattleMechStructureLocation(battleMechDesign, "CT");
            Assert.Equal(31, structure.MaxStructurePoints);
        }
        [Fact(DisplayName = "Battlemech LL Structure Read Correctly")]
        public void BattlemechLLISCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            StructureLocation structure = GetBattleMechStructureLocation(battleMechDesign, "LL");
            Assert.Equal(21, structure.MaxStructurePoints);
        }
        [Fact(DisplayName = "Battlemech RL Structure Read Correctly")]
        public void BattlemechRLISCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            StructureLocation structure = GetBattleMechStructureLocation(battleMechDesign, "RL");
            Assert.Equal(21, structure.MaxStructurePoints);
        }
        [Fact(DisplayName = "Battlemech FRL Structure Read Correctly")]
        public void BattlemechFRLISCheck()
        {
            string sFilePath = GoliathTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            StructureLocation structure = GetBattleMechStructureLocation(battleMechDesign, "FRL");
            Assert.Equal(17, structure.MaxStructurePoints);
        }
        [Fact(DisplayName = "Battlemech FLL Structure Read Correctly")]
        public void BattlemechFLLISCheck()
        {
            string sFilePath = GoliathTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            StructureLocation structure = GetBattleMechStructureLocation(battleMechDesign, "FLL");
            Assert.Equal(17, structure.MaxStructurePoints);
        }
        [Fact(DisplayName = "Battlemech RRL Structure Read Correctly")]
        public void BattlemechRRLISCheck()
        {
            string sFilePath = GoliathTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            StructureLocation structure = GetBattleMechStructureLocation(battleMechDesign, "RRL");
            Assert.Equal(17, structure.MaxStructurePoints);
        }
        [Fact(DisplayName = "Battlemech RLL Structure Read Correctly")]
        public void BattlemechRLLISCheck()
        {
            string sFilePath = GoliathTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            StructureLocation structure = GetBattleMechStructureLocation(battleMechDesign, "RLL");
            Assert.Equal(17, structure.MaxStructurePoints);
        }

        [Fact(DisplayName = "Battlemech Atlas Weapons Loaded ")]
        public void BattlemechAtlasWeaponsLoaded()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            bool bMLaserCT1 = false;
            bool bMLaserCT2 = false;
            bool bAC20RT = false;
            bool bLRM20LT = false;
            bool bSRM6LT = false;
            bool bMLaserRA1 = false;
            bool bMLaserLA1 = false;

            foreach(UnitComponent componentWeapon in battleMechDesign.Components)
            {
                if (BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.HitLocation.Name, "Center Torso") &&
                    BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.Component.Name, "Medium Laser") &&
                    bMLaserCT1 == true) bMLaserCT2 = true;
                if (BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.HitLocation.Name, "Center Torso") &&
                    BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.Component.Name, "Medium Laser") &&
                    bMLaserCT1 == false) bMLaserCT1 = true;
                if (BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.HitLocation.Name, "Right Torso") &&
                    BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.Component.Name, "AC/20")) bAC20RT = true;
                if (BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.HitLocation.Name, "Left Torso") &&
                    BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.Component.Name, "LRM20")) bLRM20LT = true;
                if (BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.HitLocation.Name, "Left Torso") &&
                    BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.Component.Name, "SRM6")) bSRM6LT = true;
                if (BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.HitLocation.Name, "Right Arm") &&
                    BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.Component.Name, "MLaser")) bMLaserRA1 = true;
                if (BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.HitLocation.Name, "Left Arm") &&
                    BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.Component.Name, "MLaser")) bMLaserLA1 = true;
            }


            
            Assert.True(bMLaserCT1);
            Assert.True(bMLaserCT2);
            Assert.True(bAC20RT);
            Assert.True(bLRM20LT);
            Assert.True(bSRM6LT);
            Assert.True(bMLaserRA1);
            Assert.True(bMLaserLA1);
        }




        public StructureLocation GetBattleMechStructureLocation(BattleMechDesign bmd, string sLocation)
        {
            foreach(BattleMechHitLocation bmhl in bmd.HitLocations)
            {
                if (bmhl.Name.Equals(sLocation)) return bmhl.Structure;
            }
            throw new Exception($"Location {sLocation} not found in Battlemech Design {bmd.Variant} {bmd.Model}");
        }

        public ArmorFacing GetBattleMechArmorFacing(BattleMechDesign bmd, string sLocation)
        {
            

            foreach (BattleMechHitLocation bmhl in bmd.HitLocations)
            {
                if(bmhl.ArmorFacings.ContainsKey(sLocation))
                {
                    return bmhl.ArmorFacings[sLocation]; 
                }
            }

            throw new Exception($"Location {sLocation} not found in Battlemech Design {bmd.Variant} {bmd.Model}");
        }


    }
}
