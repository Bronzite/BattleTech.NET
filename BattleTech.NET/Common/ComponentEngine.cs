using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.Common
{
    public class ComponentEngine:Component
    {
        private static Dictionary<string, double[]> mEngineTonnageDictionary = null;
        private static Dictionary<string, double[]> EngineTonnages
        {
            get
            {
                if (mEngineTonnageDictionary == null)
                {
                    mEngineTonnageDictionary = new Dictionary<string, double[]>();
                    //TM49
                    mEngineTonnageDictionary.Add(
                        "ICE", 
                        new double[] { 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 6, 6, 6, 7, 7, 8, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 12, 14, 14, 15, 15, 16, 17, 17, 18, 19, 20, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 31, 32, 33, 35, 36, 38, 39, 41, 43, 45, 47, 49, 51, 54, 57, 59, 63, 66, 69, 73, 77, 82, 87, 92, 98, 105 } 
                        );

                    mEngineTonnageDictionary.Add(
                        "Cell"
                        , new double[] { 1, 1, 1, 1, 1.5, 1.5, 1.5, 1.5, 2, 2, 2, 2.5, 2.5, 2.5, 3, 3, 4, 4, 4, 4.5, 4.5, 5, 5, 5, 5.5, 5.5, 6, 6, 7, 7, 7.5, 7.5, 7.5, 8.5, 8.5, 9, 9, 10, 10.5, 10.5, 11, 11.5, 12, 12, 13, 13.5, 14, 14.5, 15, 16, 16.5, 17, 17.5, 19, 19.5, 20, 21, 22, 23, 23.5, 25, 26, 27, 28.5, 29.5, 31, 32.5, 34.5, 35.5, 38, 40, 41.5, 44, 46.5, 49.5, 52.5, 55.5, 59, 63 }
                        );
                    mEngineTonnageDictionary.Add(
                        "Fission", 
                        new double[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5.5, 5.5, 5.5, 6.5, 6.5, 7, 7, 7, 8, 8, 9, 9, 10, 10, 10.5, 10.5, 10.5, 12.5, 12.5, 13.5, 13.5, 14, 15, 15, 16, 17, 17.5, 17.5, 18.5, 19.5, 20.5, 21, 22, 23, 24, 24.5, 25.5, 27.5, 28, 29, 31, 31.5, 33.5, 34.5, 36, 38, 39.5, 41.5, 43, 45, 47.5, 50, 52, 55.5, 58, 60.5, 64, 67.5, 72, 76.5, 80.5, 86, 92 }
                        );
                    mEngineTonnageDictionary.Add(
                        "Compact", 
                        new double[] { 1, 1, 1, 1, 1.5, 1.5, 1.5, 1.5, 2.5, 2.5, 2.5, 3, 3, 3, 4, 4, 4.5, 4.5, 4.5, 5.5, 5.5, 6.0, 6.0, 6.0, 7.0, 7.0, 7.5, 7.5, 8.5, 8.5, 9, 9, 9, 10.5, 10.5, 11.5, 11.5, 12, 13, 13, 13.5, 14.5, 15, 15, 16, 16.5, 17.5, 18, 19, 19.5, 20.5, 21, 22, 23, 24, 24.5, 25.5, 27.5, 28, 29, 31, 31.5, 33.5, 34.5, 36, 38, 39.5, 41.5, 43, 45, 47.5, 50, 52, 55.5, 58.0, 60.5, 64, 67.5, 72, 76.5, 80.5, 86, 92 }
                        );
                    
                    mEngineTonnageDictionary.Add(
                        "Standard", 
                        new double[] {0.5,0.5,0.5,0.5,1,1,1,1,1.5,1.5,1.5,2,2,2,2.5,2.5,3,3,3,3.5,3.5,4,4,4,4.5,4.5,5,5,5.5,5.5,6,6,6,7,7,7.5,7.5,8,8.5,8.5,9,9.5,10,10,10.5,11,11.5,12,12.5,13,13.5,14,14.5,15.5,16,16.5,17.5,18,19,19.5,20.5,21.5,22.5,23.5,24.5,25.5,27,28.5,29.5,31.5,33,34.5,36.5,38.5,41,43.5,46,49,52.5}
                        );
                    mEngineTonnageDictionary.Add(
                        "Light", 
                        new double[] { 0.5, 0.5, 0.5, 0.5, 1, 1, 1, 1, 1.5, 1.5, 1.5, 1.5, 1.5, 1.5, 2, 2, 2.5, 2.5, 2.5, 3, 3, 3, 3, 3, 3.5, 3.5, 4, 4, 4.5, 4.5, 4.5, 4.5, 4.5, 5.5, 5.5, 6, 6, 6, 6.5, 6.5, 7, 7.5, 7.5, 7.5, 8, 8.5, 9, 9, 9.5, 10, 10.5, 10.5, 11, 12, 12, 12.5, 13.5, 13.5, 14.5, 15, 15.5, 16.5, 17, 18, 18.5, 19.5, 20.5, 21.5, 22.5, 24, 25, 26, 27.5, 29, 31, 33, 34.5, 37, 39.5 }
                        );
                    mEngineTonnageDictionary.Add(
                        "XL", 
                        new double[] { 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 1, 1, 1, 1, 1, 1, 1.5, 1.5, 1.5, 1.5, 1.5, 2, 2, 2, 2, 2, 2.5, 2.5, 2.5, 2.5, 3, 3, 3, 3, 3, 3.5, 3.5, 4, 4, 4, 4.5, 4.5, 4.5, 5, 5, 5, 5.5, 5.5, 6, 6, 6.5, 6.5, 7, 7, 7.5, 8, 8, 8.5, 9, 9, 9.5, 10, 10.5, 11, 11.5, 12, 12.5, 13, 13.5, 14.5, 15, 16, 16.5, 17.5, 18.5, 19.5, 20.5, 22, 23, 24.5, 26.5 }
                        );

                }

                return mEngineTonnageDictionary;
            }

        
        }
        public ComponentEngine(int iEngineRating, string sEngineType) : this(iEngineRating, sEngineType, 1) { }
        public ComponentEngine(int iEngineRating, string sEngineType,double dBattleValueModifier) { EngineRating = iEngineRating; EngineType = sEngineType; BattleValueModifier = dBattleValueModifier; }

        private int mEngineRating = 100;

        public int EngineRating {
            get
            {
                return mEngineRating;
            }
            set
            {
                mEngineRating = value;
                Tonnage = ComponentEngine.EngineTonnages[mEngineType][((mEngineRating - 10) / 5)];
            }
        }

        private string mEngineType = "Standard";
        public string EngineType { get { return mEngineType; } set
            {
                mEngineType = value;
                Tonnage = ComponentEngine.EngineTonnages[mEngineType][((mEngineRating - 10) / 5)];
            }

        }

        public static IEnumerable<string> GetEngineTypes()
        {
            List<string> retval = new List<string>(EngineTonnages.Keys);

            

            return retval;

        }

        public override Component CreateInstance()
        {
            return new ComponentEngine(EngineRating, EngineType);
        }
        public double BattleValueModifier { get; set; }
        public override object Clone()
        {
            ComponentEngine retval = base.Clone() as ComponentEngine;
            return retval;
        }
        
        /// <summary>
        /// The number of Heat Sinks that don't require critical slots, and
        /// are considered integral to this engine. (TM53)
        /// </summary>
        public int CriticalFreeHeatSinks
        {
            get
            {
                double criticalFreeHeatSinks = Math.Truncate((double)EngineRating / 25D);
                return (int)criticalFreeHeatSinks;
            }
        }

    }
}


