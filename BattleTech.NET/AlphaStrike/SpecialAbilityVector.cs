using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.AlphaStrike
{
    public class SpecialAbilityVector:SpecialAbility
    {
        public SpecialAbilityVector(string sCode) : base(sCode) { }
        public SpecialAbilityVector(string sCode, IEnumerable<int> ieInts):base(sCode)
        {
            List<int> lstInts = new List<int>(ieInts);
            mValues = lstInts.ToArray();
        }

        private int[] mValues { get; set; }
        public int[] Values { get { return mValues; } set { mValues = value; } }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Code);

            int iHighestNumber = 0;
            for(int i=0;i<mValues.Length;i++)
            {
                if (mValues[i] > 0) iHighestNumber = i;
            }

            for(int i=0;i<iHighestNumber+1;i++)
            {
                sb.Append(mValues[i].ToString());
                if (i < iHighestNumber) sb.Append("/");
            }
            
            return sb.ToString().Trim();
        }

    }
}
