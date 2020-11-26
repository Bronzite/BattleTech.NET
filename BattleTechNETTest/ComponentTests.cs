using BattleTechNET.Common;
using BattleTechNET.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BattleTechNETTest
{
    public class ComponentTests
    {

        /// <summary>
        /// Catch-all test to make sure we have ratings 10-400 for every
        /// engine that the ComponentEngine returns.
        /// </summary>
        [Fact(DisplayName = "Test Engine Tonnages")]
        [Trait("Category", "Engines")]
        public void TestEngineTonnage()
        {
            List<string> lstEngineTypes = new List<string>(ComponentEngine.GetEngineTypes());
            foreach (string s in lstEngineTypes)
            {
                TestEngineHasAllTonnages(s);
            }
        }

        [Trait("Category", "Engines")] [Fact(DisplayName = "ICE Engine Tonnage Test")] public void TestICEEngineTonnage () { TestEngineHasAllTonnages("ICE"); }
        [Trait("Category", "Engines")] [Fact(DisplayName = "Cell Engine Tonnage Test")] public void TestCellEngineTonnage() { TestEngineHasAllTonnages("Cell"); }
        [Trait("Category", "Engines")] [Fact(DisplayName = "Fission Engine Tonnage Test")] public void TestFissionEngineTonnage() { TestEngineHasAllTonnages("Fission"); }
        [Trait("Category", "Engines")] [Fact(DisplayName = "Compact Engine Tonnage Test")] public void TestCompactEngineTonnage() { TestEngineHasAllTonnages("Compact"); }
        [Trait("Category", "Engines")] [Fact(DisplayName = "Standard Engine Tonnage Test")] public void TestStandardEngineTonnage() { TestEngineHasAllTonnages("Standard"); }
        [Trait("Category", "Engines")] [Fact(DisplayName = "Light Engine Tonnage Test")] public void TestLightEngineTonnage() { TestEngineHasAllTonnages("Light"); }
        [Trait("Category", "Engines")] [Fact(DisplayName = "XL Engine Tonnage Test")] public void TestXLEngineTonnage() { TestEngineHasAllTonnages("XL"); }
        [Trait("Category", "Engines")] [Fact(DisplayName = "ICE Engine Progressive Tonnage Test")] public void TestICEProgressiveEngineTonnage() { TestEngineTonnagesAreProgressive("ICE"); }
        [Trait("Category", "Engines")] [Fact(DisplayName = "Cell Engine Progressive Tonnage Test")] public void TestCellProgressiveEngineTonnage() { TestEngineTonnagesAreProgressive("Cell"); }
        [Trait("Category", "Engines")] [Fact(DisplayName = "Fission Engine Progressive Tonnage Test")] public void TestFissionProgressiveEngineTonnage() { TestEngineTonnagesAreProgressive("Fission"); }
        [Trait("Category", "Engines")] [Fact(DisplayName = "Compact Engine Progressive Tonnage Test")] public void TestCompactProgressiveEngineTonnage() { TestEngineTonnagesAreProgressive("Compact"); }
        [Trait("Category", "Engines")] [Fact(DisplayName = "Standard Engine Progressive Tonnage Test")] public void TestStandardProgressiveEngineTonnage() { TestEngineTonnagesAreProgressive("Standard"); }
        [Trait("Category", "Engines")] [Fact(DisplayName = "Light Engine Progressive Tonnage Test")] public void TestLightProgressiveEngineTonnage() { TestEngineTonnagesAreProgressive("Light"); }
        [Trait("Category", "Engines")] [Fact(DisplayName = "XL Engine Progressive Tonnage Test")] public void TestXLProgressiveEngineTonnage() { TestEngineTonnagesAreProgressive("XL"); }




        private void TestEngineHasAllTonnages(string sName)
        {
            for (int i = 10; i <= 400; i += 5)
            {
                ComponentEngine componentEngine = new ComponentEngine(i, sName);
            }
        }


        private void TestEngineTonnagesAreProgressive(string sName)
        {
            double dLastTonnage = 0;
            for (int i = 10; i <= 400; i += 5)
            {
                ComponentEngine componentEngine = new ComponentEngine(i, sName);
                Assert.True(componentEngine.Tonnage >= dLastTonnage);
                dLastTonnage = componentEngine.Tonnage;
            }
        }



        /// <summary>
        /// Confirm that each engine size has a increasing tonnage from Rating 
        /// 5 to Rating 400.
        /// </summary>
        [Trait("Category","Engines")]
        [Fact(DisplayName = "Test Engine Size Verification")]
        public void TestEngineSizeAttributes()
        {
            List<string> lstEngineTypes = new List<string>(ComponentEngine.GetEngineTypes());
            foreach(string s in lstEngineTypes)
            {
                TestEngineTonnagesAreProgressive(s);
            }
        }

        [Trait("Category","Cloning")]
        [Fact(DisplayName = "Test Cloning of Clustered Weapons")]
        public void ClusteredWeaponCloningTest()
        {
            ComponentWeaponClustered component = ComponentLibrary.Weapons["SRM 2"] as ComponentWeaponClustered;

            Component postClone = component.Clone() as Component;
            ComponentWeapon postComponentWeapon = postClone as ComponentWeapon;
            ComponentWeaponClustered postClusteredWeapon = postClone as ComponentWeaponClustered;

            Assert.Equal(component.Name, postClone.Name);
            Assert.Equal(component.ShortRange, postComponentWeapon.ShortRange);
            Assert.Equal(component.SalvoSize, postClusteredWeapon.SalvoSize);


        }
    }
}
