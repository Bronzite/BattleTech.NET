using BattleTechNET.Data;
using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace BattleTechNETTest
{
    public class MassTesting
    {

        [Fact(DisplayName="Test MegaMek Files")]
        public void TestMegaMekFiles()
        {
            string sDirectory = @".\TestFiles\";
            string[] sFiles = Directory.GetFiles(sDirectory);

            int iLoadCount = 0;

            foreach (string sFile in sFiles)
            {
                try
                {
                    BattleMechDesign bmd = MTFReader.ReadBattleMechDesignFile(sFile);
                    iLoadCount++;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error loading {sFile}", ex);
                }
            }

            Assert.Equal(iLoadCount, sFiles.Length);
        }


    }
}
