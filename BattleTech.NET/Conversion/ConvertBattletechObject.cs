using BattleTechNET.Common;
using BattleTechNET.Common;
using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Conversion
{
    public static class ConvertBattletechObject
    {
        /// <summary>
        /// Convert a Total Warfare BattleMech Design to an Alpha Strike
        /// element.
        /// </summary>
        /// <param name="battleMechDesign">Valid Total Warfare BattleMech Design</param>
        /// <returns>Valid Alpha Strike Element</returns>
        static public Element ToAlphaStrike(BattleMechDesign battleMechDesign)
        {
            Element retval = new Element();

            retval.Size = GetSize(battleMechDesign);
            retval.MovementModes = GetMovementMode(battleMechDesign);
            retval.MaxArmor = GetAlphaStrikeArmor(battleMechDesign);
            retval.CurrentArmor = retval.MaxArmor;
            retval.MaxStructure = BattleMechStructureConverter.GetStructure(battleMechDesign.Engine, (int)battleMechDesign.Tonnage);
            retval.CurrentStructure = retval.MaxStructure;
            
            //Apply ENE ability if appropriate
            if (PossessesENEAbility(battleMechDesign)) retval.SpecialAbilities.Add(SpecialAbilityFactory.CreateSpecialAbility("ENE"));
            
            //Compile Attack Values
            Dictionary<string, AttackValue> dicAbilities = new Dictionary<string, AttackValue>();
            AttackValue indirectFire = new AttackValue() { Name = "IF" };
            foreach(UnitComponent unitComponent in battleMechDesign.Components)
            {
                ComponentWeapon componentWeapon = unitComponent.Component as ComponentWeapon;
                if(componentWeapon != null)
                {
                    string sAlphaStrikeAbility = componentWeapon.AlphaStrikeAbility;
                    if (sAlphaStrikeAbility == null) sAlphaStrikeAbility = ""; //Empty string represent base attack
                    if (unitComponent.RearFacing) sAlphaStrikeAbility = "REAR";
                    if (!dicAbilities.ContainsKey(sAlphaStrikeAbility)) dicAbilities.Add(sAlphaStrikeAbility, new AttackValue { Name = sAlphaStrikeAbility });
                    dicAbilities[sAlphaStrikeAbility] = dicAbilities[sAlphaStrikeAbility] + new AttackValue(WeaponConverter.ConvertTotalWarfareWeapon(componentWeapon));
                    if(componentWeapon.IndirectFire) indirectFire = indirectFire + new AttackValue(WeaponConverter.ConvertTotalWarfareWeapon(componentWeapon));
                }
            }

            AttackValue baseAttackValue = new AttackValue();
            if (dicAbilities.ContainsKey("")) baseAttackValue = dicAbilities[""];

            foreach(string sKey in dicAbilities.Keys)
            {
                if(sKey!= "")
                {
                    if (dicAbilities[sKey].MediumRangeDamage >= 10)
                        retval.SpecialAbilities.Add(new SpecialAbilityVector(sKey, dicAbilities[sKey].ToFinalDamageValueIntArray()));
                    else
                        baseAttackValue = baseAttackValue + dicAbilities[sKey];
                }
            }

            retval.Arcs.Add(baseAttackValue.ToFinalDamageValueArc());

            

            if(indirectFire.ToFinalDamageValueIntArray()[2] > 0)
            {
                retval.SpecialAbilities.Add(new SpecialAbilityScalar("IF") { Value = indirectFire.ToFinalDamageValueIntArray()[2] });
            }

            return retval;
        }

        /// <summary>
        /// BattleMech Size table, SO356
        /// </summary>
        /// <param name="battleMechDesign">Valid Total Warfare BattleMech Design</param>
        /// <returns>Alpha Strike Size</returns>
        static private int GetSize(BattleMechDesign battleMechDesign)
        {
            if (battleMechDesign.Tonnage < 40) return 1;
            if (battleMechDesign.Tonnage < 60) return 2;
            if (battleMechDesign.Tonnage < 80) return 3;
            return 4;
        }

        /// <summary>
        /// Derive the MovementModes a BattleMech should have from the Total
        /// Warfare design.
        /// </summary>
        /// <param name="battleMechDesign"></param>
        /// <returns></returns>
        static private List<MovementMode> GetMovementMode(BattleMechDesign battleMechDesign)
        {
            List<MovementMode> retval = new List<MovementMode>();

            MovementMode walking = new MovementMode(battleMechDesign.WalkMP, "");
            retval.Add(walking);
            int JumpingMP = battleMechDesign.JumpMP;
            if (JumpingMP > 0 )
            {
                if (JumpingMP < walking.Points)
                    JumpingMP = (int)Math.Round((double)JumpingMP * 0.66D);
                MovementMode jumping = new MovementMode(battleMechDesign.JumpMP, "j");
                retval.Add(jumping);
            }

            //TODO: Handle MASC and Supercharger per SO357

            return retval;
        }

        /// <summary>
        /// Compute an element's Alpha Strike armor.
        /// </summary>
        /// <param name="design">A valid Total Warfare BattleMech</param>
        /// <returns>Alpha Strike Armor value</returns>
        static private int GetAlphaStrikeArmor(Design design)
        {
            int iTotalArmor = 0;

            foreach(HitLocation location in design.HitLocations)
            {
                ArmorHitLocation armorHitLocation = location as ArmorHitLocation;
                if(armorHitLocation!=null)
                {
                    foreach(ArmorFacing facing in armorHitLocation.ArmorFacings.Values)
                    {
                        iTotalArmor += facing.ArmorPoints;
                    }
                }
            }

            int retval = (int)Math.Round((double)iTotalArmor / 30D);
            return retval;
        }



        static private bool PossessesENEAbility(Design design)
        {
            //TODO: Technically, SO348 says this should be checking for
            //weapons that use ammunition, rather than the ammunition itself.
            //This would only be different if there's a mech that carries
            //an ammunition-based weapon but no ammo for it in it design.
            foreach(UnitComponent component in design.Components)
            {
                ComponentAmmunition munitions = component.Component as ComponentAmmunition;
                if (munitions != null)
                    return false;
            }
            return true;
        }
    }
}
