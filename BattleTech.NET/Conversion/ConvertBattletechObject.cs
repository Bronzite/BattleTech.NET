using BattleTechNET.Common;
using BattleTechNET.StrategicBattleForce;
using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BattleTechNET.Conversion
{
    public static class ConvertBattletechObject
    {
        static public BattleTechNET.StrategicBattleForce.Unit ToSBFUnit(IEnumerable<Element> ieElements)
        {
            BattleTechNET.StrategicBattleForce.Unit unit = new StrategicBattleForce.Unit();

            unit.Elements = new List<Element>(ieElements);
            unit.CalculateStats();
            return unit;
        }

        static public Element ToAlphaStrike(BattleMechDesign battleMechDesign) { return ToAlphaStrike(battleMechDesign, null); }
        /// <summary>
        /// Convert a Total Warfare BattleMech Design to an Alpha Strike
        /// element.
        /// </summary>
        /// <param name="battleMechDesign">Valid Total Warfare BattleMech Design</param>
        /// <returns>Valid Alpha Strike Element</returns>
        static public Element ToAlphaStrike(BattleMechDesign battleMechDesign,StringWriter log)
        {
            Element retval = new Element();
            if (log != null) log.WriteLine($"Converting {battleMechDesign.Model} {battleMechDesign.Variant}");
            retval.Size = GetSize(battleMechDesign);
            if (log != null) log.WriteLine($"Size {retval.Size}");
            retval.MovementModes = GetMovementMode(battleMechDesign);
            if (log!=null)
            {
                foreach(MovementMode mode in retval.MovementModes)
                {
                    log.WriteLine($"Has Movement mode {mode.Code} {mode.Points}");
                }
            }
            retval.MaxArmor = GetAlphaStrikeArmor(battleMechDesign);
            if (log != null) log.WriteLine($"Armor {retval.MaxArmor}");
            retval.CurrentArmor = retval.MaxArmor;
            retval.MaxStructure = BattleMechStructureConverter.GetStructure(battleMechDesign.Engine, (int)battleMechDesign.Tonnage);
            if (log != null) log.WriteLine($"Structure {retval.MaxStructure}");
            retval.CurrentStructure = retval.MaxStructure;
            retval.UnitType = new UnitTypeBattleMech();

            //Apply ENE ability if appropriate
            if (PossessesENEAbility(battleMechDesign))
            {
                retval.SpecialAbilities.Add(SpecialAbilityFactory.CreateSpecialAbility("ENE"));
                if (log != null) log.WriteLine($"Unit possesses ENE");
            }

                //Compile Attack Values
                Dictionary<string, AttackValue> dicAbilities = new Dictionary<string, AttackValue>();
            AttackValue indirectFire = new AttackValue() { Name = "IF" };
            ComponentTargetingComputer compTC = null;
            foreach (UnitComponent unitComponent in battleMechDesign.Components)
                if (compTC == null)
                {
                    compTC = unitComponent.Component as ComponentTargetingComputer;
                    if (compTC != null && log != null) log.WriteLine($"Unit has targeting computer.");
                }

            double dHeatShort = 0;
            double dHeatMedium = 0;
            double dHeatLong = 0;
            double dHeatExtreme = 0;
            double dHeatMovement = 2;
            if (battleMechDesign.JumpMP > 0)
                dHeatMovement += Math.Max(battleMechDesign.JumpMP, 3);
            foreach (UnitComponent unitComponent in battleMechDesign.Components)
            {
                ComponentWeapon componentWeapon = unitComponent.Component as ComponentWeapon;

                if (componentWeapon != null)
                {
                    string sAlphaStrikeAbility = componentWeapon.AlphaStrikeAbility;
                    if (sAlphaStrikeAbility == null) sAlphaStrikeAbility = ""; //Empty string represent base attack

                    if (unitComponent.RearFacing) sAlphaStrikeAbility = "REAR";
                    AttackValue av = new AttackValue(WeaponConverter.ConvertTotalWarfareWeapon(componentWeapon, compTC));
                    if (!dicAbilities.ContainsKey(sAlphaStrikeAbility)) dicAbilities.Add(sAlphaStrikeAbility, new AttackValue { Name = sAlphaStrikeAbility });
                    if (!dicAbilities.ContainsKey("")) dicAbilities.Add("", new AttackValue { Name = "" });
                    
                    
                    dicAbilities[sAlphaStrikeAbility] = dicAbilities[sAlphaStrikeAbility] + av;
                    if (sAlphaStrikeAbility != "") dicAbilities[""] = dicAbilities[""] + av;
                    if(componentWeapon.IndirectFire) indirectFire = indirectFire + av;
                    if (componentWeapon.HeatIsPerShot == false) //TODO: Handle heat from rear-facing weapons correctly
                    {
                        if(av.ShortRangeDamage > 0) dHeatShort += componentWeapon.Heat;
                        if (av.MediumRangeDamage > 0) dHeatMedium += componentWeapon.Heat;
                        if (av.LongRangeDamage > 0) dHeatLong += componentWeapon.Heat;
                        if (av.ExtremeRangeDamage > 0) dHeatExtreme += componentWeapon.Heat;

                    }
                    else
                    {
                        double dHeatAmount = componentWeapon.Heat * 1; //TODO: Compute per-shot hit correctly.
                        if (av.ShortRangeDamage > 0) dHeatShort += dHeatAmount;
                        if (av.MediumRangeDamage > 0) dHeatMedium += dHeatAmount;
                        if (av.LongRangeDamage > 0) dHeatLong += dHeatAmount;
                        if (av.ExtremeRangeDamage > 0) dHeatExtreme += dHeatAmount;
                    }    
                        

                    if (log != null) log.WriteLine($"Weapon {componentWeapon.Name} contributed {av.ToString()}");
                }
            }

            
            

            AttackValue baseAttackValue = new AttackValue();
            if (dicAbilities.ContainsKey("")) baseAttackValue = dicAbilities[""];

            foreach(string sKey in dicAbilities.Keys)
            {
                
                dicAbilities[sKey].AdjustBasedOnHeat(battleMechDesign.HeatDissipation, dHeatShort,dHeatMedium,dHeatLong,dHeatExtreme);
                
                if (sKey!= "")
                {
                    if (dicAbilities[sKey].MediumRangeDamage >= 10)
                        retval.SpecialAbilities.Add(new SpecialAbilityVector(sKey, dicAbilities[sKey].ToFinalDamageValueIntArray()));
                    else
                        baseAttackValue = baseAttackValue + dicAbilities[sKey];
                }

                if (log != null) log.WriteLine($"Ability {sKey} values {dicAbilities[sKey].ToString()}");
            }
            
            if (log != null) log.WriteLine($"Total Base Attack Values {baseAttackValue}");

            retval.Arcs.Add(baseAttackValue.ToFinalDamageValueArc());
            if (log != null) log.WriteLine($"Final attack values {baseAttackValue.ToFinalDamageValueArc()}");
            

            if(indirectFire.ToFinalDamageValueIntArray()[2] > 0)
            {
                retval.SpecialAbilities.Add(new SpecialAbilityScalar("IF") { Value = indirectFire.ToFinalDamageValueIntArray()[2] });
            }

            if(log!=null)
            {
                foreach(SpecialAbility sa in retval.SpecialAbilities )
                {
                    log.WriteLine($"Special Ability {sa.ToString()}");
                }
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

            MovementMode walking = new MovementMode(battleMechDesign.WalkMP, "bm");
            retval.Add(walking);
            int JumpingMP = battleMechDesign.JumpMP;
            if (JumpingMP > 0 )
            {
                if (JumpingMP < walking.Points)
                    JumpingMP = (int)Math.Round((double)JumpingMP * 0.66D);
                MovementMode jumping = new MovementMode(JumpingMP, "j");
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
