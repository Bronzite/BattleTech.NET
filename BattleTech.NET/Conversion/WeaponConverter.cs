using BattleTechNET.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Conversion
{
    public class WeaponConverter
    {
        public AlphaStrikeWeapon ConvertTotalWarfareWeapon(ComponentWeapon componentWeapon)
        {
            AlphaStrikeWeapon retval = new AlphaStrikeWeapon();
            retval.Name = componentWeapon.Name;
            if (componentWeapon.AlphaStrikeAbility != "" && componentWeapon.AlphaStrikeAbility != null) retval.SpecialAbilityCode = componentWeapon.AlphaStrikeAbility;
            //TODO:Write this function per SO360.

            return retval;
        }
    }
}
