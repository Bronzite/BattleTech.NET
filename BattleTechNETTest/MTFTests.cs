using BattleTechNET.Data;
using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BattleTechNETTest
{
    public class MTFTests
    {
        public static string TestFilePath = "./TestFiles/AtlasAS7-D.mtf";

        [Fact(DisplayName ="Read Atlas Data File")]
        public void ReadAtlasFile()
        {
            string sFilePath = TestFilePath;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            Assert.Equal("Atlas", battleMechDesign.Model);
            Assert.Equal("AS7-D", battleMechDesign.Variant);
            Assert.Equal(100, battleMechDesign.Tonnage);
            Assert.Equal(300, battleMechDesign.Engine.EngineRating);
            Assert.Equal("Standard", battleMechDesign.Engine.EngineType);
        }

        [Fact(DisplayName = "Battlemech Model Name Read Correctly")]
        public void BattleMechModelNameCheck()
        {
            string sFilePath = TestFilePath;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            Assert.Equal("Atlas", battleMechDesign.Model);
        }

        [Fact(DisplayName = "Battlemech Variant Name Read Correctly")]
        public void BattleMechVariantNameCheck()
        {
            string sFilePath = TestFilePath;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            Assert.Equal("AS7-D", battleMechDesign.Variant);
        }

        [Fact(DisplayName = "Battlemech Tonnage Read Correctly")]
        public void BattleMechTonnageCheck()
        {
            string sFilePath = TestFilePath;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            Assert.Equal(100, battleMechDesign.Tonnage);
        }

        [Fact(DisplayName = "Battlemech Engine Rating Read Correctly")]
        public void BattleMechEngineTonnageCheck()
        {
            string sFilePath = TestFilePath;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            Assert.Equal(300, battleMechDesign.Engine.EngineRating);
        }

        [Fact(DisplayName = "Battlemech Engine Type Read Correctly")]
        public void BattleMechEngineTypeCheck()
        {
            string sFilePath = TestFilePath;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            Assert.Equal("Standard", battleMechDesign.Engine.EngineType);
        }

        [Fact(DisplayName = "Battlemech CT Armor Read Correctly")]
        public void BattleMechCTArmorCheck()
        {
            string sFilePath = TestFilePath;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "CT");
            Assert.Equal(47, Facing.ArmorPoints);
        }

        [Fact(DisplayName = "Battlemech CTR Armor Read Correctly")]
        public void BattleMechCTRArmorCheck()
        {
            string sFilePath = TestFilePath;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "RTC");
            Assert.Equal(14, Facing.ArmorPoints);
        }

        [Fact(DisplayName = "Battlemech RT Armor Read Correctly")]
        public void BattleMechRTArmorCheck()
        {
            string sFilePath = TestFilePath;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "RT");
            Assert.Equal(32, Facing.ArmorPoints);
        }

        [Fact(DisplayName = "Battlemech RTR Armor Read Correctly")]
        public void BattleMechRTRArmorCheck()
        {
            string sFilePath = TestFilePath;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "RTR");
            Assert.Equal(10, Facing.ArmorPoints);
        }

        [Fact(DisplayName = "Battlemech LT Armor Read Correctly")]
        public void BattleMechLRArmorCheck()
        {
            string sFilePath = TestFilePath;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "LT");
            Assert.Equal(32, Facing.ArmorPoints);
        }

        [Fact(DisplayName = "Battlemech LTR Armor Read Correctly")]
        public void BattleMechLTRArmorCheck()
        {
            string sFilePath = TestFilePath;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "RTL");
            Assert.Equal(10, Facing.ArmorPoints);
        }

        [Fact(DisplayName = "Battlemech LA Armor Read Correctly")]
        public void BattleMechLAArmorCheck()
        {
            string sFilePath = TestFilePath;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "LA");
            Assert.Equal(34, Facing.ArmorPoints);
        }

        [Fact(DisplayName = "Battlemech RA Armor Read Correctly")]
        public void BattleMechRAArmorCheck()
        {
            string sFilePath = TestFilePath;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "RA");
            Assert.Equal(34, Facing.ArmorPoints);
        }

        [Fact(DisplayName = "Battlemech HD Armor Read Correctly")]
        public void BattleMechHDArmorCheck()
        {
            string sFilePath = TestFilePath;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "HD");
            Assert.Equal(9, Facing.ArmorPoints);
        }

        [Fact(DisplayName = "Battlemech LL Armor Read Correctly")]
        public void BattleMechLLArmorCheck()
        {
            string sFilePath = TestFilePath;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "LL");
            Assert.Equal(41, Facing.ArmorPoints);
        }

        [Fact(DisplayName = "Battlemech RL Armor Read Correctly")]
        public void BattleMechRLArmorCheck()
        {
            string sFilePath = TestFilePath;
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            ArmorFacing Facing = GetBattleMechArmorFacing(battleMechDesign, "RL");
            Assert.Equal(41, Facing.ArmorPoints);
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
