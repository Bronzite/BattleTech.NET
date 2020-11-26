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
                if(clusterWeapon.Streak)
                    DamageRating = DamageRating * ComponentWeaponClustered.ClusterHitResult(clusterWeapon.SalvoSize, 12);
                else
                    DamageRating = DamageRating * ComponentWeaponClustered.ClusterHitResult(clusterWeapon.SalvoSize, 7);
            }
            //Ugly hack until we have multi-mode weapons set up
            //Per SO360
            if (componentWeapon.Name.StartsWith("Ultra ")) DamageRating*=1.5;

            if (componentWeapon.LongRange >= 24) retval.ExtremeRangeDamage += DamageRating;
            if (componentWeapon.LongRange >= 16) retval.LongRangeDamage += DamageRating;
            if (componentWeapon.LongRange >= 4) retval.MediumRangeDamage += DamageRating;
            retval.ShortRangeDamage += DamageRating;

            if(componentWeapon.Name.StartsWith("Hyper-Assault"))
            {
                retval.ShortRangeDamage = ComponentWeaponClustered.ClusterHitResult(clusterWeapon.SalvoSize, 9);
                retval.MediumRangeDamage = ComponentWeaponClustered.ClusterHitResult(clusterWeapon.SalvoSize, 7);
                retval.LongRangeDamage = ComponentWeaponClustered.ClusterHitResult(clusterWeapon.SalvoSize, 5);
            }

            if (componentWeapon.Name.StartsWith("Rocket Launcher"))
            {
                retval.ShortRangeDamage *= 0.1;
                retval.MediumRangeDamage *= 0.1;
                retval.LongRangeDamage *= 0.1;
            }


            if (componentWeapon.Name.StartsWith("MML"))
            {
                retval.ShortRangeDamage = 2* ComponentWeaponClustered.ClusterHitResult(clusterWeapon.SalvoSize, 7);
                retval.MediumRangeDamage = 1.5 * ComponentWeaponClustered.ClusterHitResult(clusterWeapon.SalvoSize, 7);
                retval.LongRangeDamage = 1 * ComponentWeaponClustered.ClusterHitResult(clusterWeapon.SalvoSize, 7);
            }
                //Variable-Damage Weapons
                //TODO: This doesn't handle cluster-based variable damage weapons,
                //but I don't think there are canonical examples of that.
                if (componentWeapon.ShortRangeDamage != componentWeapon.MediumRangeDamage || componentWeapon.MediumRangeDamage != componentWeapon.LongRangeDamage)
            {
                retval.ShortRangeDamage = componentWeapon.ShortRangeDamage;
                retval.MediumRangeDamage = componentWeapon.MediumRangeDamage;
                retval.LongRangeDamage = componentWeapon.LongRangeDamage;
                if(componentWeapon.LongRange < 16)
                {
                    retval.MediumRangeDamage = ((double)componentWeapon.MediumRangeDamage + (double)componentWeapon.LongRangeDamage) / 2D;
                    retval.LongRangeDamage = 0;
                }    
            }

            //Minimum Range Modifier on SO361
            int iMinimumRangeFraction = Math.Min(componentWeapon.MinimumRange,7);
            retval.ShortRangeDamage *= MinimumRangeFraction[iMinimumRangeFraction];



            //Modify for To-Hit Modifier on SO361
            int iEffectiveToHitModifier = componentWeapon.ToHitModifier;
            //Ugly hack until we have multi-mode weapons set up
            if (componentWeapon.Name.StartsWith("LB ")) iEffectiveToHitModifier = -1;
            double[] dToHitModifiers = new double[] { 1.2, 1.15, 1.1, 1.05, 1, 0.95, 0.90, 0.85, 0.8 };
            double dToHitModifier = dToHitModifiers[iEffectiveToHitModifier + 4];
            retval.ShortRangeDamage *= dToHitModifier;
            retval.MediumRangeDamage *= dToHitModifier;
            retval.LongRangeDamage *= dToHitModifier;
            retval.ExtremeRangeDamage *= dToHitModifier;


            retval.Heat = componentWeapon.Heat;

            retval.ShortRangeDamage = Math.Round(retval.ShortRangeDamage, 2);
            retval.MediumRangeDamage = Math.Round(retval.MediumRangeDamage, 2);
            retval.LongRangeDamage = Math.Round(retval.LongRangeDamage, 2);
            retval.ExtremeRangeDamage = Math.Round(retval.ExtremeRangeDamage, 2);

            return retval;
        }
    }
}
