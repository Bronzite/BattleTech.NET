using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    public class SpecialAbilityScalar: SpecialAbilityVector
    {
        public SpecialAbilityScalar(string sCode) : base(sCode) { }
        public SpecialAbilityScalar(string sCode, int iValue) : base(sCode) { Value = iValue; }

        public int Value { 
            get
            {
                if (Values == null) return 0;
                return Values[0];
            }
            set
            {
                if (Values == null)
                    Values = new int[1];
                Values[0] = value;

            } 
        }
    }
}
