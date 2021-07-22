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
    public class BVTests
    {
        private readonly ITestOutputHelper _outputHelper;

        public BVTests(ITestOutputHelper testOutputHelper)
        {
            _outputHelper = testOutputHelper;
        }

        [Trait("Battle Value", "BV Test")]
        [Theory(DisplayName = "BV BattleMech Theory")]
        [MemberData(nameof(GetBVTestCases))]
        public void BattletechValueConfirmation(BattleMechDesign battlemechDesign, BVDataPoint dataPoint)
        {
            int battlemechDesignBV = (int)battlemechDesign.BV;
            int datapointBV = (int)dataPoint.bV;

            if(battlemechDesignBV != datapointBV)
            {
                _outputHelper.WriteLine(battlemechDesign.Ledger.RootNode.GetTree(0));
            }

            Assert.Equal(datapointBV, battlemechDesignBV);

        }

        public static IEnumerable<object[]> GetBVTestCases()
        {
            List<object[]> retval = new List<object[]>();
            //Load Variants
            string sDirectory = $".{Path.DirectorySeparatorChar}TestFiles{Path.DirectorySeparatorChar}MassTesting{Path.DirectorySeparatorChar}";
            if (Directory.Exists(sDirectory))
            {
                string[] mtfFiles = Utilities.GetFiles(sDirectory, "*.mtf");
                Dictionary<string, BattleTechNET.TotalWarfare.BattleMechDesign> designs = new Dictionary<string, BattleTechNET.TotalWarfare.BattleMechDesign>();
                foreach (string mtfFile in mtfFiles)
                {
                    try
                    {
                        BattleMechDesign design = MTFReader.ReadBattleMechDesignFile(File.OpenRead(mtfFile));


                        designs.Add($"{design.Model} {design.Variant}", design);
                    }
                    catch (Exception ex)
                    {

                    }
                }


                //Load Test Data Points
                string sTestCaseFileName = $".{System.IO.Path.DirectorySeparatorChar}TestFiles{System.IO.Path.DirectorySeparatorChar}BVTestCases.json";
                string sJSONFile = System.IO.File.ReadAllText(sTestCaseFileName);
                BVTestSet testSet = JsonSerializer.Deserialize<BVTestSet>(sJSONFile);
                

                foreach (BVDataPoint dataPoint in testSet.testCases)
                {
                    if (designs.ContainsKey(dataPoint.ToString()))
                        retval.Add(new object[] { designs[dataPoint.ToString()], dataPoint });
                    else
                        throw new Exception($"Could not find variant {dataPoint.ToString()}");
                }

            }
            return retval;
        }


        public class BVTestSet
        {
            public List<BVDataPoint> testCases { get; set; }
        }

        public class BVDataPoint
        {
            public string variant { get; set; }
            public string model { get; set; }
            public int bV { get; set;}
            public override string ToString()
            {
                return $"{model} {variant}";
            }
        }
    }
}
