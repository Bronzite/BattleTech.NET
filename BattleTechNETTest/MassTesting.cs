using BattleTechNET.Data;
using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
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
        //Recursive file get
        private string[] GetFiles(string sDirectory,string sPattern)
        {
            List<string> retval = new List<string>();
            string[] sDirectories = Directory.GetDirectories(sDirectory);
            foreach(string sSubdirectory in sDirectories)
            {
                retval.AddRange(GetFiles(sSubdirectory, sPattern));
            }
            retval.AddRange(Directory.GetFiles(sDirectory, sPattern));
            return retval.ToArray();
        }
        [Fact(DisplayName="Load MegaMek Files")]
        public void TestMegaMekFiles()
        {
            string[] sFiles = GetFiles(sDirectory,"*.mtf");

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
            string[] sFiles = GetFiles(sDirectory, "*.mtf");
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
