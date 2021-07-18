using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.TotalWarfare
{
    public static class CombatRules
    {
        public static int TargetMovementModifier(double HexMovement) { return TargetMovementModifier((int)HexMovement); }
        public static int TargetMovementModifier(int HexMovement)
        {
            int retval = 0;
            if (HexMovement > 2) retval++;
            if (HexMovement > 4) retval++;
            if (HexMovement > 6) retval++;
            if (HexMovement > 9) retval++;
            if (HexMovement > 17) retval++;
            if (HexMovement > 24) retval++;
            return retval;
        }

    }
}
