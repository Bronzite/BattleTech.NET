using BattleTechNET.Data;
using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace BattleTechNETTest
{
    public class MassTesting
    {
        string sDirectory = @".\TestFiles\";
        

        private readonly ITestOutputHelper _outputHelper;

        public MassTesting(ITestOutputHelper testOutputHelper)
        {
            _outputHelper = testOutputHelper;
        }

        [Fact(DisplayName="Load MegaMek Files")]
        public void TestMegaMekFiles()
        {
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

        [Fact(DisplayName = "Mass Check MegaMek Files")]
        public void MassCheckMegaMekFiles()
        {
            string[] sFiles = Directory.GetFiles(sDirectory, "*.mtf");
            int iLoadCount = 0;
            
            foreach (string sFile in sFiles)
            {
                try
                {
                    BattleMechDesign bmd = MTFReader.ReadBattleMechDesignFile(sFile);
                    double dComputedTonnage = bmd.ComputedTonnage;
                    if (bmd.Tonnage < dComputedTonnage || bmd.Tonnage - dComputedTonnage > 0.5  )
                    {
                        _outputHelper.WriteLine($"{bmd.Variant} {bmd.Model} rated at {bmd.Tonnage}, computed as {bmd.ComputedTonnage}");
                        _outputHelper.WriteLine(bmd.TonnageLedger);
                    }
                    else
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
