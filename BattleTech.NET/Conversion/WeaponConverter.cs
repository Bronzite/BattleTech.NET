using BattleTechNET.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Conversion
{
    public class WeaponConverter
    {
        //Minimum Range Damage Adjustment Table, SO361
        private static double[] MinimumRangeFraction = new double[7] { 1, 0.92, 0.83, 0.75, 0.66, 0.58, 0.50 }; 

        public static AlphaStrikeWeapon ConvertTotalWarfareWeapon(ComponentWeapon componentWeapon)
        {
            AlphaStrikeWeapon retval = new AlphaStrikeWeapon();
            retval.Name = componentWeapon.Name;
            if (componentWeapon.AlphaStrikeAbility != "" && componentWeapon.AlphaStrikeAbility != null) retval.SpecialAbilityCode = componentWeapon.AlphaStrikeAbility;
            //TODO:Write this function per SO360.
            double DamageRating = (double)componentWeapon.Damage;
            //Cluster Weapons on SO360
            ComponentWeaponClustered clusterWeapon = componentWeapon as ComponentWeaponClustered;
            if (clusterWeapon != null)
            {
                DamageRating = DamageRating * ComponentWeaponClustered.ClusterHitResult(clusterWeapon.SalvoSize, 7);
            }

            if (componentWeapon.LongRange >= 24) retval.ExtremeRangeDamage += DamageRating;
            if (componentWeapon.LongRange >= 16) retval.LongRangeDamage += DamageRating;
            if (componentWeapon.LongRange >= 4) retval.MediumRangeDamage += DamageRating;
            retval.ShortRangeDamage += DamageRating;

            //Minimum Range Modifier on SO361
            int iMinimumRangeFraction = Math.Min(componentWeapon.MinimumRange,7);
            retval.ShortRangeDamage *= MinimumRangeFraction[iMinimumRangeFraction];

            


            retval.Heat = componentWeapon.Heat;

            retval.ShortRangeDamage = Math.Round(retval.ShortRangeDamage, 2);
            retval.MediumRangeDamage = Math.Round(retval.MediumRangeDamage, 2);
            retval.LongRangeDamage = Math.Round(retval.LongRangeDamage, 2);
            retval.ExtremeRangeDamage = Math.Round(retval.ExtremeRangeDamage, 2);

            return retval;
        }
    }
}
