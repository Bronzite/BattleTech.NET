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
        [Fact(DisplayName ="Read Atlas Data File")]
        public void ReadAtlasFile()
        {
            string sFilePath = "./TestFiles/AtlasAS7-D.mtf";
            BattleMechDesign battleMechDesign = MTFReader.ReadBattleMechDesignFile(sFilePath);

            Assert.Equal("Atlas", battleMechDesign.Model);
            Assert.Equal("AS7-D", battleMechDesign.Variant);
            Assert.Equal(100, battleMechDesign.Tonnage);
            


        }

    }
}
