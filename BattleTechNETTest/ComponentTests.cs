using BattleTechNET.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BattleTechNETTest
{
    public class ComponentTests
    {
        [Fact(DisplayName = "Test Engine Tonnages")]
        public void TestEngineTonnage()
        {
            List<string> lstEngineTypes = new List<string>(ComponentEngine.GetEngineTypes());
            foreach (string s in lstEngineTypes)
            {
                double iLastTonnage = 0;
                for (int i = 5; i < 401; i += 5)
                {
                    ComponentEngine componentEngine = new ComponentEngine(i, s);
                    iLastTonnage = componentEngine.Tonnage;
                }
            }
        }


        /// <summary>
        /// Confirm that each engine size has a increasing tonnage from Rating 
        /// 5 to Rating 400.
        /// </summary>
        [Fact(DisplayName = "Test Engine Size Verification")]
        public void TestEngineSizeAttributes()
        {
            List<string> lstEngineTypes = new List<string>(ComponentEngine.GetEngineTypes());
            foreach(string s in lstEngineTypes)
            {
                double dLastTonnage = 0;
                for (int i = 5; i < 401; i += 5)
                {
                    ComponentEngine componentEngine = new ComponentEngine(i,s);
                    Assert.True(componentEngine.Tonnage >= dLastTonnage);
                    dLastTonnage = componentEngine.Tonnage;
                }
            }
        }

    }
}
