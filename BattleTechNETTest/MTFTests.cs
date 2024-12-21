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
        public static string AresTestFile = "./TestFiles/AresARS-V1Aphrodite.mtf";

        private readonly ITestOutputHelper _outputHelper;

        public MTFTests(ITestOutputHelper testOutputHelper)
        {
            _outputHelper = testOutputHelper;
        }


        [Trait("Category","Full Mech Test")]
        [Fact(DisplayName = "Atlas Computed Tonnage Check")]
        public void AtlasTonnageCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            _outputHelper.WriteLine(battleMechDesign.TonnageLedger);

            Assert.Equal(100, battleMechDesign.ComputedTonnage);
            
        }
        [Trait("Category", "Full Mech Test")]
        [Fact(DisplayName = "Goliath Computed Tonnage Check")]
        public void GoliathTonnageCheck()
        {
            string sFilePath = GoliathTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);
            _outputHelper.WriteLine(battleMechDesign.TonnageLedger);
            Assert.Equal(80, battleMechDesign.ComputedTonnage);
        }
        [Trait("Category", "Full Mech Test")]
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
        [Trait("Category", "Full Mech Test")]
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

        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech Model Name Read Correctly")]
        public void BattleMechModelNameCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            Assert.Equal("Atlas", battleMechDesign.Model);
        }

        [Trait("Category", "Read Value Test")]
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

        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech Engine Rating Read Correctly")]
        public void BattleMechEngineTonnageCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            Assert.Equal(300, battleMechDesign.Engine.EngineRating);
        }

        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech Engine Type Read Correctly")]
        public void BattleMechEngineTypeCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            Assert.Equal("Standard", battleMechDesign.Engine.EngineType);
        }
        [Trait("Category", "Read Value Test")]

        [Fact(DisplayName = "Battlemech CT Armor Read Correctly")]
        public void BattleMechCTArmorCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "CT");
            Assert.Equal(47, Facing.ArmorPoints);
        }
        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech CTR Armor Read Correctly")]
        public void BattleMechCTRArmorCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "RTC");
            Assert.Equal(14, Facing.ArmorPoints);
        }
        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech RT Armor Read Correctly")]
        public void BattleMechRTArmorCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "RT");
            Assert.Equal(32, Facing.ArmorPoints);
        }
        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech RTR Armor Read Correctly")]
        public void BattleMechRTRArmorCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "RTR");
            Assert.Equal(10, Facing.ArmorPoints);
        }
        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech LT Armor Read Correctly")]
        public void BattleMechLRArmorCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "LT");
            Assert.Equal(32, Facing.ArmorPoints);
        }
        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech LTR Armor Read Correctly")]
        public void BattleMechLTRArmorCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "RTL");
            Assert.Equal(10, Facing.ArmorPoints);
        }
        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech LA Armor Read Correctly")]
        public void BattleMechLAArmorCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "LA");
            Assert.Equal(34, Facing.ArmorPoints);
        }
        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech RA Armor Read Correctly")]
        public void BattleMechRAArmorCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "RA");
            Assert.Equal(34, Facing.ArmorPoints);
        }
        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech HD Armor Read Correctly")]
        public void BattleMechHDArmorCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "HD");
            Assert.Equal(9, Facing.ArmorPoints);
        }
        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech LL Armor Read Correctly")]
        public void BattleMechLLArmorCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "LL");
            Assert.Equal(41, Facing.ArmorPoints);
        }
        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech RL Armor Read Correctly")]
        public void BattleMechRLArmorCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "RL");
            Assert.Equal(41, Facing.ArmorPoints);
        }
        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech HD Structure Read Correctly")]
        public void BattlemechHDISCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            StructureLocation structure = GetBattleMechStructureLocation(battleMechDesign, "HD");
            Assert.Equal(3,structure.MaxStructurePoints);
        }
        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech LA Structure Read Correctly")]
        public void BattlemechLAISCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            StructureLocation structure = GetBattleMechStructureLocation(battleMechDesign, "LA");
            Assert.Equal(17, structure.MaxStructurePoints);
        }
        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech RA Structure Read Correctly")]
            public void BattlemechRAISCheck()
            {
                string sFilePath = AtlasTestFile;
                BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

                StructureLocation structure = GetBattleMechStructureLocation(battleMechDesign, "RA");
                Assert.Equal(17, structure.MaxStructurePoints);
            }
        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech RT Structure Read Correctly")]
        public void BattlemechRTISCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            StructureLocation structure = GetBattleMechStructureLocation(battleMechDesign, "RT");
            Assert.Equal(21, structure.MaxStructurePoints);
        }
        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech LT Structure Read Correctly")]
        public void BattlemechLTISCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            StructureLocation structure = GetBattleMechStructureLocation(battleMechDesign, "LT");
            Assert.Equal(21, structure.MaxStructurePoints);
        }
        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech CT Structure Read Correctly")]
        public void BattlemechCTISCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            StructureLocation structure = GetBattleMechStructureLocation(battleMechDesign, "CT");
            Assert.Equal(31, structure.MaxStructurePoints);
        }
        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech LL Structure Read Correctly")]
        public void BattlemechLLISCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            StructureLocation structure = GetBattleMechStructureLocation(battleMechDesign, "LL");
            Assert.Equal(21, structure.MaxStructurePoints);
        }
        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech RL Structure Read Correctly")]
        public void BattlemechRLISCheck()
        {
            string sFilePath = AtlasTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            StructureLocation structure = GetBattleMechStructureLocation(battleMechDesign, "RL");
            Assert.Equal(21, structure.MaxStructurePoints);
        }
        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech FRL Structure Read Correctly")]
        public void BattlemechFRLISCheck()
        {
            string sFilePath = GoliathTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            StructureLocation structure = GetBattleMechStructureLocation(battleMechDesign, "FRL");
            Assert.Equal(17, structure.MaxStructurePoints);
        }
        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech FLL Structure Read Correctly")]
        public void BattlemechFLLISCheck()
        {
            string sFilePath = GoliathTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            StructureLocation structure = GetBattleMechStructureLocation(battleMechDesign, "FLL");
            Assert.Equal(17, structure.MaxStructurePoints);
        }
        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech RRL Structure Read Correctly")]
        public void BattlemechRRLISCheck()
        {
            string sFilePath = GoliathTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            StructureLocation structure = GetBattleMechStructureLocation(battleMechDesign, "RRL");
            Assert.Equal(17, structure.MaxStructurePoints);
        }
        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech RLL Structure Read Correctly")]
        public void BattlemechRLLISCheck()
        {
            string sFilePath = GoliathTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            StructureLocation structure = GetBattleMechStructureLocation(battleMechDesign, "RLL");
            Assert.Equal(17, structure.MaxStructurePoints);
        }
        [Trait("Category", "Read Value Test")]
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
                    BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.Component, "Medium Laser") &&
                    bMLaserCT1 == true) bMLaserCT2 = true;
                if (BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.HitLocation.Name, "Center Torso") &&
                    BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.Component, "Medium Laser") &&
                    bMLaserCT1 == false) bMLaserCT1 = true;
                if (BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.HitLocation.Name, "Right Torso") &&
                    BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.Component, "AC/20")) bAC20RT = true;
                if (BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.HitLocation.Name, "Left Torso") &&
                    BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.Component, "LRM20")) bLRM20LT = true;
                if (BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.HitLocation.Name, "Left Torso") &&
                    BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.Component, "SRM6")) bSRM6LT = true;
                if (BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.HitLocation.Name, "Right Arm") &&
                    BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.Component, "Medium Laser")) bMLaserRA1 = true;
                if (BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.HitLocation.Name, "Left Arm") &&
                    BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.Component, "Medium Laser")) bMLaserLA1 = true;
            }


            
            Assert.True(bMLaserCT1,"CT Medium Laser 1 Missing");
            Assert.True(bMLaserCT2, "CT Medium Laser 2 Missing");
            Assert.True(bAC20RT, "RT AC/20 Missing");
            Assert.True(bLRM20LT, "LT LRM20 Missing");
            Assert.True(bSRM6LT, "LT SRM6 Missing");
            Assert.True(bMLaserRA1, "RA Medium Laser Missing");
            Assert.True(bMLaserLA1, "LA Medium Laser Missing");
        }

        [Trait("Category", "Read Value Test")]
        [Fact(DisplayName = "Battlemech Ares Weapons Loaded ")]
        public void BattlemechAresWeaponsLoaded()
        {
            string sFilePath = AresTestFile;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            bool bRotaryAC5LA = false;
            bool bStreakLRM5RA1 = false;
            bool bStreakLRM5RA2 = false;
            bool bStreakLRM5RA3 = false;
            bool ERMLLT = false;
            bool ERSLLT = false;
            bool LRM55LT = false;
            bool SRM2LT = false;
            bool C3MasterLT = false;
            bool ERMLRT = false;
            bool ERSLRT = false;
            bool LRM5RT = false;
            bool SRM2RT = false;
            bool C3MasterRT = false;
            bool ERSLCT = false;
            bool SRM2CT = false;

            foreach (UnitComponent componentWeapon in battleMechDesign.Components)
            {
                if (BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.HitLocation.Name, "Right Arm") &&
                    BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.Component, "Streak LRM 5") &&
                    bStreakLRM5RA2 == true) bStreakLRM5RA3 = true;
                if (BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.HitLocation.Name, "Right Arm") &&
                    BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.Component, "Streak LRM 5") &&
                    bStreakLRM5RA1 == true) bStreakLRM5RA2 = true;
                if (BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.HitLocation.Name, "Right Arm") &&
                    BattleTechNET.Common.Utilities.IsSynonymFor(componentWeapon.Component, "Streak LRM 5")) bStreakLRM5RA3 = true;
                if(IsPresent(componentWeapon.Component.Name, "Rotary AC/5", componentWeapon.HitLocation.Name, "Left Arm")) bRotaryAC5LA = true;
                if (IsPresent(componentWeapon.Component.Name, "ER Medium Laser",componentWeapon.HitLocation.Name, "Left Torso")) ERMLLT = true;
                if (IsPresent(componentWeapon.Component.Name, "ER Small Laser", componentWeapon.HitLocation.Name, "Left Torso")) ERSLLT = true;
                if (IsPresent(componentWeapon.Component.Name, "LRM 5", componentWeapon.HitLocation.Name, "Left Torso")) LRM55LT = true;
                if (IsPresent(componentWeapon.Component.Name, "SRM 2", componentWeapon.HitLocation.Name, "Left Torso")) SRM2LT = true;
                if (IsPresent(componentWeapon.Component.Name, "C3 Master", componentWeapon.HitLocation.Name, "Left Torso")) C3MasterLT = true;
                if (IsPresent(componentWeapon.Component.Name, "ER Medium Laser", componentWeapon.HitLocation.Name, "Right Torso")) ERMLRT = true;
                if (IsPresent(componentWeapon.Component.Name, "ER Small Laser", componentWeapon.HitLocation.Name, "Right Torso")) ERSLRT = true;
                if (IsPresent(componentWeapon.Component.Name, "LRM 5", componentWeapon.HitLocation.Name, "Right Torso")) LRM5RT = true;
                if (IsPresent(componentWeapon.Component.Name, "SRM 2", componentWeapon.HitLocation.Name, "Right Torso")) SRM2RT = true;
                if (IsPresent(componentWeapon.Component.Name, "C3 Master", componentWeapon.HitLocation.Name, "Right Torso")) C3MasterRT = true;
                if (IsPresent(componentWeapon.Component.Name, "ER Small Laser", componentWeapon.HitLocation.Name, "Center Torso")) ERSLCT = true;
                if (IsPresent(componentWeapon.Component.Name, "SRM 2", componentWeapon.HitLocation.Name, "Center Torso")) SRM2CT = true;
            }
            Assert.True(bRotaryAC5LA);
            Assert.True( bStreakLRM5RA1 );
            Assert.True( bStreakLRM5RA2 );
            Assert.True( bStreakLRM5RA3 );
            Assert.True( ERMLLT );
            Assert.True( ERSLLT );
            Assert.True( LRM55LT );
            Assert.True( SRM2LT );
            Assert.True( C3MasterLT );
            Assert.True( ERMLRT );
            Assert.True( ERSLRT );
            Assert.True( LRM5RT );
            Assert.True( SRM2RT );
            Assert.True( C3MasterRT );
            Assert.True( ERSLCT );
            Assert.True( SRM2CT );

        }

        private bool IsPresent(string sCompName, string sCompNameCheck, string sLocationName, string sLocationNameCheck)
        {
            if (BattleTechNET.Common.Utilities.IsSynonymFor(sLocationName, sLocationNameCheck) &&
                    BattleTechNET.Common.Utilities.IsSynonymFor(sCompName, sCompNameCheck)) return true;
            return false;
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
