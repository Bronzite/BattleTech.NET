using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.AlphaStrike
{
    public class SpecialAbilityScalar: SpecialAbilityVector
    {
        public SpecialAbilityScalar(string sCode) : base(sCode) { }

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
