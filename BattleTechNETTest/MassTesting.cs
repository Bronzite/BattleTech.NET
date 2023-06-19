using BattleTechNET.Common;
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
    public class MassTesting:DataTest
    {
        string sDirectory = $".{Path.DirectorySeparatorChar}TestFiles{Path.DirectorySeparatorChar}";
        

        private readonly ITestOutputHelper _outputHelper;

        public MassTesting(ITestOutputHelper testOutputHelper):base()
        {
            _outputHelper = testOutputHelper;
        }


        [Trait("Category", "MTF Reader")]
        [Fact(DisplayName="Load MegaMek Files")]
        public void TestMegaMekFiles()
        {
            string[] sFiles = Utilities.GetFiles($"{Utilities.DataDirectory}{Path.DirectorySeparatorChar}megamek-master{Path.DirectorySeparatorChar}megamek{Path.DirectorySeparatorChar}data{Path.DirectorySeparatorChar}mechfiles{Path.DirectorySeparatorChar}mechs","*.mtf");

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
                    string sText = "";
                    while(ex != null)
                    {
                        sText += ex.Message;
                        sText += "/";
                        ex = ex.InnerException;
                    }
                    sText += Path.GetFileNameWithoutExtension(sFile);
                    _outputHelper.WriteLine(sText);
                }
            }

            Assert.Equal(sFiles.Length, iLoadCount);
        }

        [Trait("Category", "MTF Reader")]
        [Fact(DisplayName = "Count Loadable MTF Files")]
        public void TestCount()
        {
            string[] sFiles = Utilities.GetFiles($"{Utilities.DataDirectory}{Path.DirectorySeparatorChar}megamek-master{Path.DirectorySeparatorChar}megamek{Path.DirectorySeparatorChar}data{Path.DirectorySeparatorChar}mechfiles{Path.DirectorySeparatorChar}mechs", "*.mtf");

            int iLoadCount = 0;
            int iFileCount = 0;
            foreach (string sFile in sFiles)
            {
                try
                {
                    iFileCount++;
                    BattleMechDesign bmd = MTFReader.ReadBattleMechDesignFile(sFile);

                    iLoadCount++;
                }
                catch (DesignUnsupportedTypeException ex)
                {
					//_outputHelper.WriteLine($"{sFile}: {ex.Message}");
                }
                catch (Exception ex)
                {
                    _outputHelper.WriteLine($"{sFile}: {ex.Message}");
                }
            }

            Assert.Equal(sFiles.Length, iLoadCount);
        }

        [Trait("Category", "MTF Reader")]
        [Fact(DisplayName = "Mass Check MegaMek Files")]
        public void MassCheckMegaMekFiles()
        {
            string[] sFiles = Utilities.GetFiles($"{Utilities.DataDirectory}{Path.DirectorySeparatorChar}megamek-master{Path.DirectorySeparatorChar}megamek{Path.DirectorySeparatorChar}data{Path.DirectorySeparatorChar}mechfiles{Path.DirectorySeparatorChar}mechs", "*.mtf");
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
                catch (DesignUnsupportedTypeException ex)
                {

                }
                catch (Exception ex)
                {
                    throw new Exception($"Error loading {sFile}", ex);
                }
            }
            _outputHelper.WriteLine($"Checked {sFiles.Length} MTF files.");
            Assert.Equal(sFiles.Length, iLoadCount);
        }

        [Trait("Category", "MTF Reader")]
        [Fact(DisplayName = "Clan Mass Check MegaMek Files")]
        public void MassCheckClanMegaMekFiles()
        {
            string[] sFiles = Utilities.GetFiles($"{Utilities.DataDirectory}{Path.DirectorySeparatorChar}megamek-master{Path.DirectorySeparatorChar}megamek{Path.DirectorySeparatorChar}data{Path.DirectorySeparatorChar}mechfiles{Path.DirectorySeparatorChar}mechs", "*.mtf");
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
                            _outputHelper.WriteLine($"Located at {sFile}");
                            if (bmd.Tonnage < dComputedTonnage) _outputHelper.WriteLine("Computed tonnage exceeds nominal tonnage.");
                            if (bmd.Tonnage - dComputedTonnage > 0.5) _outputHelper.WriteLine("Computed tonnage more than 0.5 tons below nominal tonnage.");
                            _outputHelper.WriteLine(bmd.TonnageLedger);
                        }
                        else
                            iLoadCount++;
                        iClanMechCount++;
                    }
                }
                catch (DesignUnsupportedTypeException ex)
                {
				}
                catch (Exception ex)
                {
                    throw new Exception($"Error loading {sFile}", ex);
                }
            }
            _outputHelper.WriteLine($"Checked {sFiles.Length} MTF files.");
            Assert.Equal(iClanMechCount, iLoadCount);
        }
        
        [Trait("Category", "MTF Reader")]
        [Fact(DisplayName = "Inner Sphere Mass Check MegaMek Files")]
        public void MassCheckISMegaMekFiles()
        {
            string[] sFiles = Utilities.GetFiles($"{Utilities.DataDirectory}{Path.DirectorySeparatorChar}megamek-master{Path.DirectorySeparatorChar}megamek{Path.DirectorySeparatorChar}data{Path.DirectorySeparatorChar}mechfiles{Path.DirectorySeparatorChar}mechs", "*.mtf");
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
                            _outputHelper.WriteLine($"Located at {sFile}");
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

        [Trait("Category", "MTF Reader")]
        [Fact(DisplayName = "Mixed Techbase Mass Check MegaMek Files")]
        public void MassCheckMixedTechbaseMegaMekFiles()
        {
            string[] sFiles = Utilities.GetFiles($"{Utilities.DataDirectory}{Path.DirectorySeparatorChar}megamek-master{Path.DirectorySeparatorChar}megamek{Path.DirectorySeparatorChar}data{Path.DirectorySeparatorChar}mechfiles{Path.DirectorySeparatorChar}mechs", "*.mtf");
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
                            _outputHelper.WriteLine($"Located at {sFile}");
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
