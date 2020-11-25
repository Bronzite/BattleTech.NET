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
        public int[] Values { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Code);
            sb.Append(" ");
            for(int i=0;i<mValues.Length;i++)
            {
                sb.Append(i.ToString());
                if (i < mValues.Length - 1) sb.Append("/");
            }
            return sb.ToString().Trim();
        }

    }
}
