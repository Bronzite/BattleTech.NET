using BattleTechNET.AlphaStrike;
using BattleTechNET.Common;
using BattleTechNET.Conversion;
using BattleTechNET.Data;
using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Xunit;
using Xunit.Abstractions;

namespace BattleTechNETTest
{
    public class TWtoASConverter
    {
        public static string AtlasTestFile = $".{Path.DirectorySeparatorChar}TestFiles{Path.DirectorySeparatorChar}AtlasAS7-D.mtf";
        public static string GoliathTestFile = $".{Path.DirectorySeparatorChar}TestFiles{Path.DirectorySeparatorChar}GoliathGOL-1H.mtf";

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

        [Trait("Category", "Total Warfare to Alpha Strike Conversion")]
        [Fact(DisplayName = "AS7-D Structure Amount Check")]
        public void CheckAS7DStructure()
        {
            BattleMechDesign designAtlas = MTFReader.ReadBattleMechDesignFile(AtlasTestFile);

            Element element = ConvertBattletechObject.ToAlphaStrike(designAtlas);

            Assert.Equal(8, element.MaxStructure);
        }

        [Trait("Category", "Total Warfare to Alpha Strike Conversion")]
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

        [Trait("Category", "Total Warfare to Alpha Strike Conversion")]
        [Fact(DisplayName = "GOL-1H Structure Amount Check")]
        public void CheckGOL1HStructure()
        {
            BattleMechDesign designGoliath = MTFReader.ReadBattleMechDesignFile(GoliathTestFile);

            Element element = ConvertBattletechObject.ToAlphaStrike(designGoliath);

            Assert.Equal(6, element.MaxStructure);
        }

        [Trait("Category", "Total Warfare to Alpha Strike Conversion")]
        [Fact(DisplayName = "GOL-1H Walk MP Check")]
        public void CheckGOL1HMovement()
        {
            BattleMechDesign designGoliath = MTFReader.ReadBattleMechDesignFile(GoliathTestFile);

            Element element = ConvertBattletechObject.ToAlphaStrike(designGoliath);
            MovementMode m = element.GetMovementMode("");

            Assert.Equal(4, m.Points);
        }

        [Trait("Category", "Total Warfare to Alpha Strike Conversion")]
        [Fact(DisplayName = "AS7-D AC Ability")]
        public void CheckAS7DACAbility()
        {
            BattleMechDesign designAtlas = MTFReader.ReadBattleMechDesignFile(AtlasTestFile);

            Element element = ConvertBattletechObject.ToAlphaStrike(designAtlas);
            SpecialAbility abilityAC = null;
            foreach (SpecialAbility ability in element.SpecialAbilities)
                if (ability.Code.Equals("AC")) abilityAC = ability;

            Assert.NotNull(abilityAC);

            Assert.Equal("AC2/2",abilityAC.ToString());
        }

        [Trait("Category", "Total Warfare to Alpha Strike Conversion")]
        [Fact(DisplayName = "AS7-D IF Ability")]
        public void CheckAS7DIFAbility()
        {
            BattleMechDesign designAtlas = MTFReader.ReadBattleMechDesignFile(AtlasTestFile);

            Element element = ConvertBattletechObject.ToAlphaStrike(designAtlas);
            SpecialAbility abilityAC = null;
            foreach (SpecialAbility ability in element.SpecialAbilities)
                if (ability.Code.Equals("IF")) abilityAC = ability;

            Assert.NotNull(abilityAC);

            Assert.Equal("IF1", abilityAC.ToString());
        }
        [Trait("Category", "Total Warfare to Alpha Strike Conversion")]
        [Fact(DisplayName = "AS7-D LRM Ability")]
        public void CheckAS7DLRMAbility()
        {
            BattleMechDesign designAtlas = MTFReader.ReadBattleMechDesignFile(AtlasTestFile);

            Element element = ConvertBattletechObject.ToAlphaStrike(designAtlas);
            SpecialAbility abilityLRM = null;
            foreach (SpecialAbility ability in element.SpecialAbilities)
                if (ability.Code.Equals("LRM")) abilityLRM = ability;

            Assert.NotNull(abilityLRM);

            Assert.Equal("LRM1/1/1", abilityLRM.ToString());
        }
        
        [Trait("Category", "Total Warfare to Alpha Strike Conversion")]
        [Fact(DisplayName = "AS7-D REAR Ability")]
        public void CheckAS7DREARAbility()
        {
            BattleMechDesign designAtlas = MTFReader.ReadBattleMechDesignFile(AtlasTestFile);

            Element element = ConvertBattletechObject.ToAlphaStrike(designAtlas);
            SpecialAbility abilityAC = null;
            foreach (SpecialAbility ability in element.SpecialAbilities)
                if (ability.Code.Equals("REAR")) abilityAC = ability;

            Assert.NotNull(abilityAC);

            Assert.Equal("REAR1/1", abilityAC.ToString());
        }

        [Trait("Category", "Total Warfare to Alpha Strike Conversion")]
        [Fact(DisplayName = "GOL-1H IF Ability")]
        public void CheckGOL1HIFAbility()
        {
            BattleMechDesign designGoliath = MTFReader.ReadBattleMechDesignFile(GoliathTestFile);

            Element element = ConvertBattletechObject.ToAlphaStrike(designGoliath);
            SpecialAbility abilityAC = null;
            foreach (SpecialAbility ability in element.SpecialAbilities)
                if (ability.Code.Equals("IF")) abilityAC = ability;

            Assert.NotNull(abilityAC);

            Assert.Equal("IF1", abilityAC.ToString());
        }
        [Trait("Category", "Total Warfare to Alpha Strike Conversion")]
        [Fact(DisplayName = "GOL-1H LRM Ability")]
        public void CheckGOL1HLRMAbility()
        {
            BattleMechDesign designGoliath = MTFReader.ReadBattleMechDesignFile(GoliathTestFile);

            Element element = ConvertBattletechObject.ToAlphaStrike(designGoliath);
            SpecialAbility abilityAC = null;
            foreach (SpecialAbility ability in element.SpecialAbilities)
                if (ability.Code.Equals("LRM")) abilityAC = ability;

            Assert.NotNull(abilityAC);

            Assert.Equal("LRM1/1/1", abilityAC.ToString());
        }

        [Trait("Category", "Total Warfare to Alpha Strike Conversion")]
        [Theory(DisplayName="Total Warfare Weapon Damage Value Conversion Theory")]
        [MemberData(nameof(GetWeaponConversionTestCases))]
        public void CheckWeaponDamageValues(ComponentWeapon weapon, double expectedShortRangeValue, double expectedMediumRangeValue, double expectedLongRangeValue, double expectedExtremeRangeValue)
        {
            AlphaStrikeWeapon asw = WeaponConverter.ConvertTotalWarfareWeapon(weapon);
            Assert.Equal(expectedShortRangeValue, asw.ShortRangeDamage);
            Assert.Equal(expectedMediumRangeValue, asw.MediumRangeDamage);
            Assert.Equal(expectedLongRangeValue, asw.LongRangeDamage);
            Assert.Equal(expectedExtremeRangeValue, asw.ExtremeRangeDamage);

        }

        public static IEnumerable<object[]> GetWeaponConversionTestCases()
        {
            string sTestCaseFileName = $".{System.IO.Path.DirectorySeparatorChar}TestFiles{System.IO.Path.DirectorySeparatorChar}TWtoASWeaponConversionTestCases.json";
            string sJSONFile = System.IO.File.ReadAllText(sTestCaseFileName);
            CheckWeaponDamageValuesTestSet testSet = JsonSerializer.Deserialize<CheckWeaponDamageValuesTestSet>(sJSONFile);
            List<object[]> retval = new List<object[]>();
            foreach(CheckWeaponDamageValuesTestSet.CheckWeaponDamageValuesTestCase testCase in testSet.testCases)
            {
                foreach (ComponentWeapon weapon in ComponentLibrary.Weapons.Values)
                {
                    if (BattleTechNET.Common.Utilities.IsSynonymFor(weapon, testCase.weaponName))
                    {
                        if ((testCase.techBase.Equals("Inner Sphere") && weapon.TechnologyBase == TECHNOLOGY_BASE.INNERSPHERE)
                            || weapon.TechnologyBase == TECHNOLOGY_BASE.BOTH)
                        {
                            object[] objs = new object[5] { weapon, testCase.expectedShortRangeValue, testCase.expectedMediumRangeValue, testCase.expectedLongRangeValue, testCase.expectedExtremeRangeValue };
                            retval.Add(objs);
                        }
                    }
                }
            }

            return retval;
        }
    }

    public class CheckWeaponDamageValuesTestSet
    {
        public ICollection<CheckWeaponDamageValuesTestCase> testCases { get; set; } 
        

        public class CheckWeaponDamageValuesTestCase
        {
            public string weaponName { get; set; }
            public double heat { get; set; }
            public string techBase { get; set; }
            public double expectedShortRangeValue { get;set; }
            public double expectedMediumRangeValue { get; set; }
            public double expectedLongRangeValue { get; set; }
            public double expectedExtremeRangeValue { get; set; }
        }
    }
}
