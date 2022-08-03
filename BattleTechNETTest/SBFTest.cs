using BattleTechNET.Conversion;
using BattleTechNET.StrategicBattleForce;
using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace BattleTechNETTest
{
    public class SBFTest:DataTest
    {

        private readonly ITestOutputHelper _outputHelper;

        public SBFTest(ITestOutputHelper testOutputHelper)
        {
            _outputHelper = testOutputHelper;
        }

        [Fact]
        public BattleTechNET.StrategicBattleForce.Unit CreateCommandLance()
        {
            string sSourceDir = $"{Utilities.DataDirectory}{Path.DirectorySeparatorChar}megamek-master{Path.DirectorySeparatorChar}megamek{Path.DirectorySeparatorChar}data{Path.DirectorySeparatorChar}mechfiles{Path.DirectorySeparatorChar}mechs";
            BattleTechNET.StrategicBattleForce.Unit retval = new BattleTechNET.StrategicBattleForce.Unit();
            BattleMechDesign bmdRaksasha = Utilities.GetBattleMech(sSourceDir, "Rakshasa MDG-1A");
            BattleMechDesign bmdRifleman = Utilities.GetBattleMech(sSourceDir, "Rifleman RFL-6D");
            BattleMechDesign bmdThunderbolt = Utilities.GetBattleMech(sSourceDir, "Thunderbolt TDR-9NAIS");
            BattleMechDesign bmdWarhammer = Utilities.GetBattleMech(sSourceDir, "Warhammer WHM-9D");

            retval.Elements = new List<BattleTechNET.Common.Element>();
            StringWriter strWrite = new StringWriter();
            retval.Elements.Add(ConvertBattletechObject.ToAlphaStrike(bmdRaksasha,strWrite));
            retval.Elements.Add(ConvertBattletechObject.ToAlphaStrike(bmdRifleman, strWrite));
            retval.Elements.Add(ConvertBattletechObject.ToAlphaStrike(bmdThunderbolt, strWrite));
            retval.Elements.Add(ConvertBattletechObject.ToAlphaStrike(bmdWarhammer, strWrite));
            _outputHelper.WriteLine(strWrite.ToString());

            retval.CalculateStats();
            Assert.Equal("BM", retval.UnitType.Code);
            Assert.Equal(3, retval.Size);
            Assert.Equal(5, retval.MovementModes[0].Points);
            Assert.Equal(0, retval.Jump);
            //TODO: T.Move
            Assert.Equal(2, retval.TMM);
            Assert.Equal(14, retval.Armor);
            Assert.Equal(6, retval.ShortRange);
            Assert.Equal(6, retval.MediumRange);
            Assert.Equal(3, retval.LongRange);
            Assert.Equal(4, retval.Skill);
            Assert.Equal(52, retval.PointValue);
            Assert.Equal(true, retval.AnyElementHasAbility("IF2"));
            Assert.Equal(true, retval.AnyElementHasAbility("MHQ1"));


            return retval;

        }
    }
}
