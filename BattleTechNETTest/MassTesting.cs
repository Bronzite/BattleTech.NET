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

            Assert.Equal(sFiles.Length, iLoadCount);
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
                    if (bmd.Tonnage < dComputedTonnage || (bmd.Tonnage - dComputedTonnage > 0.5 && !Utilities.IsUndertonnageDesign(bmd))  )
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
            _outputHelper.WriteLine($"Checked {sFiles.Length} MTF files.");
            Assert.Equal(sFiles.Length, iLoadCount);
        }

        [Fact(DisplayName = "Clan Mass Check MegaMek Files")]
        public void MassCheckClanMegaMekFiles()
        {
            string[] sFiles = GetFiles(sDirectory, "*.mtf");
            int iLoadCount = 0;
            int iClanMechCount = 0;
            if (sFiles == null) return;
            foreach (string sFile in sFiles)
            {
                try
                {
                    BattleMechDesign bmd = MTFReader.ReadBattleMechDesignFile(sFile);
                    if (bmd.TechnologyBase == BattleTechNET.Common.TECHNOLOGY_BASE.CLAN)
                    {
                        double dComputedTonnage = bmd.ComputedTonnage;
                        if (bmd.Tonnage < dComputedTonnage || (bmd.Tonnage - dComputedTonnage > 0.5 && !Utilities.IsUndertonnageDesign(bmd)))
                        {
                            _outputHelper.WriteLine($"{bmd.Variant} {bmd.Model} rated at {bmd.Tonnage}, computed as {bmd.ComputedTonnage}");
                            if (bmd.Tonnage < dComputedTonnage) _outputHelper.WriteLine("Computed tonnage exceeds nominal tonnage.");
                            if (bmd.Tonnage - dComputedTonnage > 0.5) _outputHelper.WriteLine("Computed tonnage more than 0.5 tons below nominal tonnage.");
                            _outputHelper.WriteLine(bmd.TonnageLedger);
                        }
                        else
                            iLoadCount++;
                        iClanMechCount++;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error loading {sFile}", ex);
                }
            }
            _outputHelper.WriteLine($"Checked {sFiles.Length} MTF files.");
            Assert.Equal(iClanMechCount, iLoadCount);
        }

        [Fact(DisplayName = "Inner Sphere Mass Check MegaMek Files")]
        public void MassCheckISMegaMekFiles()
        {
            string[] sFiles = GetFiles(sDirectory, "*.mtf");
            int iLoadCount = 0;
            int iInnerSphereMechCount = 0;
            if (sFiles == null) return;
            foreach (string sFile in sFiles)
            {
                try
                {
                    BattleMechDesign bmd = MTFReader.ReadBattleMechDesignFile(sFile);
                    if (bmd.TechnologyBase == BattleTechNET.Common.TECHNOLOGY_BASE.INNERSPHERE)
                    {
                        double dComputedTonnage = bmd.ComputedTonnage;
                        if (bmd.Tonnage < dComputedTonnage || (bmd.Tonnage - dComputedTonnage > 0.5 && !Utilities.IsUndertonnageDesign(bmd)))
                        {
                            _outputHelper.WriteLine($"{bmd.Variant} {bmd.Model} rated at {bmd.Tonnage}, computed as {bmd.ComputedTonnage}");
                            if (bmd.Tonnage < dComputedTonnage) _outputHelper.WriteLine("Computed tonnage exceeds nominal tonnage.");
                            if (bmd.Tonnage - dComputedTonnage > 0.5) _outputHelper.WriteLine("Computed tonnage more than 0.5 tons below nominal tonnage.");
                            _outputHelper.WriteLine(bmd.TonnageLedger);
                        }
                        else
                            iLoadCount++;
                        iInnerSphereMechCount++;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error loading {sFile}", ex);
                }
            }
            _outputHelper.WriteLine($"Checked {sFiles.Length} MTF files.");
            Assert.Equal(iInnerSphereMechCount, iLoadCount);
        }

        [Fact(DisplayName = "Mixed Techbase Mass Check MegaMek Files")]
        public void MassCheckMixedTechbaseMegaMekFiles()
        {
            string[] sFiles = GetFiles(sDirectory, "*.mtf");
            int iLoadCount = 0;
            int iMixedTechBaseMechCount = 0;
            if (sFiles == null) return;
            foreach (string sFile in sFiles)
            {
                try
                {
                    BattleMechDesign bmd = MTFReader.ReadBattleMechDesignFile(sFile);
                    if (bmd.TechnologyBase == BattleTechNET.Common.TECHNOLOGY_BASE.BOTH)
                    {
                        double dComputedTonnage = bmd.ComputedTonnage;
                        if (bmd.Tonnage < dComputedTonnage || (bmd.Tonnage - dComputedTonnage > 0.5 && !Utilities.IsUndertonnageDesign(bmd)))
                        {
                            _outputHelper.WriteLine($"{bmd.Variant} {bmd.Model} rated at {bmd.Tonnage}, computed as {bmd.ComputedTonnage}");
                            if (bmd.Tonnage < dComputedTonnage) _outputHelper.WriteLine("Computed tonnage exceeds nominal tonnage.");
                            if (bmd.Tonnage - dComputedTonnage > 0.5) _outputHelper.WriteLine("Computed tonnage more than 0.5 tons below nominal tonnage.");
                            _outputHelper.WriteLine(bmd.TonnageLedger);
                        }
                        else
                            iLoadCount++;
                        iMixedTechBaseMechCount++;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error loading {sFile}", ex);
                }
            }
            _outputHelper.WriteLine($"Checked {sFiles.Length} MTF files.");
            Assert.Equal(iMixedTechBaseMechCount, iLoadCount);
        }
    }
}
