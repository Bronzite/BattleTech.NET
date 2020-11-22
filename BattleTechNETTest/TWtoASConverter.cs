using BattleTechNET.AlphaStrike;
using BattleTechNET.Common;
using BattleTechNET.Conversion;
using BattleTechNET.Data;
using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace BattleTechNETTest
{
    public class TWtoASConverter
    {
        public static string AtlasTestFile = "./TestFiles/AtlasAS7-D.mtf";
        public static string GoliathTestFile = "./TestFiles/GoliathGOL-1H.mtf";

        private readonly ITestOutputHelper _outputHelper;

        public TWtoASConverter(ITestOutputHelper testOutputHelper)
        {
            _outputHelper = testOutputHelper;
        }

        [Trait("Category","Total Warfare to Alpha Strike Conversion")]
        [Fact(DisplayName ="AS7-D Conversion")]
        public void ConvertAS7D()
        {
            BattleMechDesign atlasDesign = MTFReader.ReadBattleMechDesignFile(AtlasTestFile);

            Element element = ConvertBattletechObject.ToAlphaStrike(atlasDesign);
        }

        [Trait("Category", "Total Warfare to Alpha Strike Conversion")]
        [Fact(DisplayName = "AS7-D Armor Amount Check")]
        public void CheckAS7DArmor()
        {
            BattleMechDesign designAtlas = MTFReader.ReadBattleMechDesignFile(AtlasTestFile);

            Element element = ConvertBattletechObject.ToAlphaStrike(designAtlas);

            Assert.Equal(10, element.MaxArmor);
        }

        [Trait("Category", "Total Warfare to Alpha Strike Structure")]
        [Fact(DisplayName = "AS7-D Structure Amount Check")]
        public void CheckAS7DStructure()
        {
            BattleMechDesign designAtlas = MTFReader.ReadBattleMechDesignFile(AtlasTestFile);

            Element element = ConvertBattletechObject.ToAlphaStrike(designAtlas);

            Assert.Equal(8, element.MaxStructure);
        }

        [Trait("Category", "Total Warfare to Alpha Strike Structure")]
        [Fact(DisplayName = "AS7-D Walk MP Check")]
        public void CheckAS7DMovement()
        {
            BattleMechDesign designAtlas = MTFReader.ReadBattleMechDesignFile(AtlasTestFile);

            Element element = ConvertBattletechObject.ToAlphaStrike(designAtlas);
            MovementMode m = element.GetMovementMode("");
            
            Assert.Equal(3, m.Points);
        }

        [Trait("Category", "Total Warfare to Alpha Strike Conversion")]
        [Fact(DisplayName = "GOL-1H Conversion")]
        public void ConvertGOL1H()
        {
            BattleMechDesign designGoliath = MTFReader.ReadBattleMechDesignFile(GoliathTestFile);

            Element element = ConvertBattletechObject.ToAlphaStrike(designGoliath);
        }

        [Trait("Category", "Total Warfare to Alpha Strike Conversion")]
        [Fact(DisplayName = "GOL-1H Armor Amount Check")]
        public void CheckGOL1HArmor()
        {
            BattleMechDesign designGoliath = MTFReader.ReadBattleMechDesignFile(GoliathTestFile);

            Element element = ConvertBattletechObject.ToAlphaStrike(designGoliath);

            Assert.Equal(8, element.MaxArmor);
        }

        [Trait("Category", "Total Warfare to Alpha Strike Structure")]
        [Fact(DisplayName = "GOL-1H Structure Amount Check")]
        public void CheckGOL1HStructure()
        {
            BattleMechDesign designGoliath = MTFReader.ReadBattleMechDesignFile(GoliathTestFile);

            Element element = ConvertBattletechObject.ToAlphaStrike(designGoliath);

            Assert.Equal(6, element.MaxStructure);
        }

        [Trait("Category", "Total Warfare to Alpha Strike Structure")]
        [Fact(DisplayName = "GOL-1H Walk MP Check")]
        public void CheckGOL1HMovement()
        {
            BattleMechDesign designGoliath = MTFReader.ReadBattleMechDesignFile(GoliathTestFile);

            Element element = ConvertBattletechObject.ToAlphaStrike(designGoliath);
            MovementMode m = element.GetMovementMode("");

            Assert.Equal(4, m.Points);
        }
    }
}
