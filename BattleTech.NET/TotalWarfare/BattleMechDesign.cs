using BattleTechNET.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.TotalWarfare
{
    public class BattleMechDesign:Design,IBattleValue
    {
        public Guid Id { get; set; }
        public Common.ComponentEngine Engine { get; set; }
        public StructureType StructureType { get; set; }
        public MyomerType MyomerType { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1}", this.Model, this.Variant);
        }

        public BattleValueLedger Ledger
        {
            get
            {
                BattleValueLedger ledger = new BattleValueLedger();
                ledger.RootNode.Name = $"{Model} {Variant} BV";
                BattleValueNode bvOffensive = new BattleValueNode() { Name = "Offensive BV" };
                bvOffensive.Parent = ledger.RootNode;
                BattleValueNode bvDefensive = new BattleValueNode() { Name = "Defensive BV" };
                bvDefensive.Parent = ledger.RootNode;
                BattleValueNode bvArmorFactor = new BattleValueNode() { Name = "Armor BV" };
                bvArmorFactor.Parent = bvDefensive;


                //Armor Factor and Structure Factor
                double dStructureFactor = 0;
                foreach (ArmorHitLocation armorHitLocation in HitLocations)
                {
                    foreach (ArmorFacing facing in armorHitLocation.ArmorFacings.Values)
                    {

                        BattleValueNode bvnArmor = new BattleValueNode() { Name = $"{armorHitLocation.Name} {facing.Name} Armor", Summand = (double)facing.ArmorPoints * facing.ArmorType.BattleValueModifier, Factor = 2.5D };
                        bvnArmor.Parent = bvArmorFactor;
                    }
                    dStructureFactor += 1.5D * (double)armorHitLocation.Structure.StructurePoints * Engine.BattleValueModifier * armorHitLocation.Structure.StructureType.BattleValueModifier;
                }
                BattleValueNode bvStructureFactor = new BattleValueNode() { Name = "Structure Value", Summand = dStructureFactor };
                bvStructureFactor.Parent = bvDefensive;

                //TODO: We need to calculate all the defensive equipment BV,
                //which means being able to identify which equipment is
                //defensive (TM302)

                BattleValueNode bvExplosiveAmmo = new BattleValueNode() { Name = "Explosive Ammunition" };
                bvExplosiveAmmo.Parent = bvDefensive;
                BattleValueNode bvDefensiveEquipment = new BattleValueNode() { Name = "Defensive Equipment" };
                bvDefensiveEquipment.Parent = bvDefensive;
                BattleValueNode bvWeapons = new BattleValueNode() { Name = "Weapons" };
                bvWeapons.Parent = bvOffensive;
                List<ComponentWeapon> lstWeapons = new List<ComponentWeapon>();
                List<ComponentAmmunition> lstAmmunition = new List<ComponentAmmunition>();
                ComponentGyro gyro = null;
                double dMaximumHeat = 0;
                foreach (UnitComponent curUnitComponent in Components)
                {
                    //Gyro Factor
                    ComponentGyro curGyro = curUnitComponent.Component as ComponentGyro;
                    if (curGyro != null) gyro = curGyro;

                    //Subtract Volatile Weapons (Gauss Rifles)
                    ComponentWeapon curWeapon = curUnitComponent.Component as ComponentWeapon;
                    if (curWeapon != null)
                    {
                        lstWeapons.Add(curWeapon);
                        if (curWeapon.VolatileDamage > 0)
                        {
                            double dExplosiveAmmoFactor = 0;
                            if (TechnologyBase == TECHNOLOGY_BASE.CLAN &&
                                (Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "CT") ||
                                Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "LL") ||
                                Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "RL") ||
                                Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "HD")))
                                dExplosiveAmmoFactor -= curWeapon.CriticalSpaceMech ?? 0;
                            if (TechnologyBase == TECHNOLOGY_BASE.INNERSPHERE &&
                                Engine.EngineType == "XL")
                                dExplosiveAmmoFactor -= curWeapon.CriticalSpaceMech ?? 0;
                            if (TechnologyBase == TECHNOLOGY_BASE.INNERSPHERE &&
                                (Engine.EngineType == "Standard" || Engine.EngineType == "Light") &&
                                (Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "CT") ||
                                Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "LL") ||
                                Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "RL") ||
                                Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "HD") ||
                                !Utilities.LocationHasCASE(curUnitComponent.HitLocation as BattleMechHitLocation)))
                                dExplosiveAmmoFactor -= curWeapon.CriticalSpaceMech ?? 0;
                            if (dExplosiveAmmoFactor != 0)
                            {
                                BattleValueNode bvExplosiveReduction = new BattleValueNode() { Name = $"{curUnitComponent.Component.Name} {curUnitComponent.HitLocation}", Summand = dExplosiveAmmoFactor };
                                bvExplosiveReduction.Parent = bvExplosiveAmmo;
                            }
                        }
                        int iHeat = curWeapon.Heat;
                        ComponentWeaponClustered clustered = curWeapon as ComponentWeaponClustered;
                        if (clustered != null)
                            if (clustered.HeatIsPerShot) iHeat *= clustered.SalvoSize;
                        if (curWeapon.Name.Contains("Streak")) iHeat /= 2; //TM303
                        if (curWeapon.Name.Contains("(OS)")) iHeat /= 4; //TM303
                        dMaximumHeat += (double)iHeat;
                        //dWeaponBV += curWeapon.BV;
                        if (curWeapon.BV > 0)
                        {
                            BattleValueNode bvWeapon = new BattleValueNode() { Name = $"{curUnitComponent.Component.Name} {curUnitComponent.HitLocation}", Summand = curWeapon.BV };
                            bvWeapon.Parent = bvWeapons;
                        }
                    }


                    //Subtract Ammunition
                    ComponentAmmunition curAmmo = curUnitComponent.Component as ComponentAmmunition;
                    if (curAmmo != null)
                    {
                        lstAmmunition.Add(curAmmo);
                        //iAmmoBV += curAmmo.BV;
                        if (curAmmo.Volatile)
                        {
                            double dExplosiveAmmoFactor = 0;
                            if ((Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "CT") ||
                                Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "LL") ||
                                Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "RL") ||
                                Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "HD")) && TechnologyBase == TECHNOLOGY_BASE.CLAN)
                            {
                                dExplosiveAmmoFactor -= 15;
                            }
                            if (Engine.EngineType == "XL" &&
                                TechnologyBase == TECHNOLOGY_BASE.INNERSPHERE)

                            {
                                dExplosiveAmmoFactor -= 15;
                            }
                            //TODO: I think this covers the Explosive Ammo elements
                            //on TM303.  It is strangely worded.
                            if ((Engine.EngineType == "Standard" || Engine.EngineType == "Light") &&
                                TechnologyBase == TECHNOLOGY_BASE.INNERSPHERE &&
                                (!Utilities.LocationHasCASE(curUnitComponent.HitLocation as BattleMechHitLocation) ||
                                (Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "CT") ||
                                Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "LL") ||
                                Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "RL") ||
                                Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "HD"))))
                            {
                                dExplosiveAmmoFactor -= 15;
                            }
                            if (dExplosiveAmmoFactor != 0)
                            {
                                BattleValueNode bvExplosiveReduction = new BattleValueNode() { Name = $"{curUnitComponent.Component.Name} {curUnitComponent.HitLocation}", Summand = dExplosiveAmmoFactor };
                                bvExplosiveReduction.Parent = bvExplosiveAmmo;
                            }


                        }
                    }
                    if (curUnitComponent.Component.DefensiveBV)
                    {
                        if (curUnitComponent.Component.BV != 0)
                        {
                            BattleValueNode defensiveEquipment = new BattleValueNode() { Name = $"{curUnitComponent.Component.Name} {curUnitComponent.HitLocation}", Summand = curUnitComponent.Component.BV };
                            defensiveEquipment.Parent = bvDefensiveEquipment;
                        }
                    }
                }
                if (gyro == null) throw new Exception("Cannot calculate BV for a 'Mech with no Gyro");

                BattleValueNode bvGyro = new BattleValueNode() { Name = $"{gyro.Name}", Summand = Tonnage, Factor = gyro.BattleValueModifier };
                bvGyro.Parent = bvDefensive;

                double dDefensiveFactor = 1D + ((double)Utilities.MaxmiumDefensiveModifier(this) / 10D);

                //double dDefensiveBV = (dGyro + dExplosiveAmmoFactor + dArmorFactor + dStructureFactor + dDefensiveEquipment) * dDefensiveFactor;
                bvDefensive.Factor = dDefensiveFactor;

                //Offensive BV (TM303)
                double dOffensiveBV = 0;
                double dMechHeatEfficiency = 6 + HeatDissipation - Math.Max(3, JumpMP);
                double dOffensiveWeaponBV = 0;
                double dOffensiveAmmoBV = 0;
                double dOffensiveOtherBV = 0;
                double dTotalHeat = 0;

                //TODO: ICE-powered Mechs should have a Movment Heat of zero.

                foreach (ComponentWeapon weapon in lstWeapons)
                {
                    dTotalHeat += weapon.BVHeatPoints;
                    dOffensiveWeaponBV += weapon.BV;
                }



                if (dTotalHeat > dMechHeatEfficiency)
                {

                    lstWeapons.Sort((a, b) =>
                    {
                        if (a.BV != b.BV)
                            return a.BV.CompareTo(b.BV);
                        else
                            return a.BVHeatPoints.CompareTo(b.BVHeatPoints);
                    });
                    double dSubtotalBV = 0;
                    double dSubtotalHeat = 0;
                    Queue<ComponentWeapon> queueReductionSet = new Queue<ComponentWeapon>(lstWeapons);
                    bool bAddAtHalfValue = false;
                    while (queueReductionSet.Count > 0)
                    {

                        ComponentWeapon NextWeapon = queueReductionSet.Dequeue();
                        dSubtotalHeat = NextWeapon.BVHeatPoints;
                        if (dSubtotalHeat > dMechHeatEfficiency || NextWeapon.BVHeatPoints == 0)
                        {
                            BattleValueNode bvWeapon = new BattleValueNode() { Name = $"{NextWeapon.Name}", Summand = NextWeapon.BV / 2 };
                            bvWeapon.Parent = bvWeapons;
                        }
                        else
                        {
                            BattleValueNode bvWeapon = new BattleValueNode() { Name = $"{NextWeapon.Name}", Summand = NextWeapon.BV };
                            bvWeapon.Parent = bvWeapons;
                        }

                    }
                }
                BattleValueNode bvAmmunition = new BattleValueNode() { Name = "Ammunition" };
                bvAmmunition.Parent = bvOffensive;
                foreach (ComponentAmmunition ammo in lstAmmunition)
                {
                    //TODO: Excessive Ammo rule on TM303.
                    //dOffensiveAmmoBV += ammo.BV;
                    BattleValueNode bvAmmo = new BattleValueNode() { Name = $"{ammo.Name}", Summand = ammo.BV };
                    bvAmmo.Parent = bvAmmunition;
                }
                bool bMASC = false;
                bool bTSM = false;

                BattleValueNode bvOffensiveEquipment = new BattleValueNode() { Name = "Offensive Equipment" };
                bvOffensiveEquipment.Parent = bvOffensive;
                //Offensive equipment that isn't weapons
                foreach (UnitComponent comp in Components)
                {
                    ComponentWeapon weap = comp.Component as ComponentWeapon;
                    ComponentAmmunition ammo = comp.Component as ComponentAmmunition;

                    if (weap == null)
                    {
                        if (ammo == null) if (!comp.Component.DefensiveBV)
                            {
                                //dOffensiveOtherBV += comp.Component.BV;
                                if (comp.Component.BV > 0)
                                {
                                    BattleValueNode bvOffensiveComponent = new BattleValueNode() { Name = $"{comp.Component.Name} {comp.HitLocation}", Summand = comp.Component.BV };
                                    bvOffensiveComponent.Parent = bvOffensiveEquipment;
                                }
                            }
                    }

                }
                BattleValueNode bvTonnage = new BattleValueNode() { Name = "Tonnage", Summand = Tonnage };
                bvTonnage.Parent = bvOffensive;
                if (MyomerType.Name.Contains("TSM")) bvTonnage.Factor = 1.5;

                //dOffensiveBV = dOffensiveWeaponBV + dOffensiveAmmoBV + dOffensiveOtherBV + Tonnage;

                int iSpeedFactorResult = RunMP + (int)Math.Round(((double)JumpMP / 2D) + 0.5);
                if (MyomerType.Name.Contains("MASC") || MyomerType.Name.Contains("TSM")) iSpeedFactorResult += 1;


                double[] SpeedFactorTable = { 0.44, 0.54, 0.65, 0.77, 0.88, 1, 1.12, 1.24, 1.37, 1.50, 1.63, 1.76, 1.89, 2.02, 2.16, 2.3, 2.44, 2.58, 2.72, 2.86, 3, 3.15, 3.29, 3.44, 3.59, 3.75 };

                //TODO: Adjust this speed factor for MASC/TSM
                //double SpeedFactor = 1D + Math.Pow(((double)RunMP + ((double)JumpMP / 2D) - 5D) / 10D, 1.2); //TM315

                double SpeedFactor = SpeedFactorTable[iSpeedFactorResult];

                bvOffensive.Factor = SpeedFactor;


                //iAccumulator = (int)Math.Round(dDefensiveBV + dOffensiveBV);

                return ledger;
            
            }
        }
        
        public override double BV
        {
            get
            {
                /*
                int iAccumulator = 0;
                List<ComponentWeapon> lstWeapons = new List<ComponentWeapon>();
                List<ComponentAmmunition> lstAmmunition = new List<ComponentAmmunition>();
                //Defensive Battle Rating
                double dArmorFactor = 0;
                double dStructureFactor = 0;
                double dExplosiveAmmoFactor = 0;
                double dDefensiveEquipment = 0;
                double dMaximumHeat = 0;
                double dWeaponBV = 0;
                int iAmmoBV = 0;
                //TM302:Defensive Battle Rating

                //Armor Factor and Structure Factor
                foreach(ArmorHitLocation armorHitLocation in HitLocations)
                {
                    foreach(ArmorFacing facing in armorHitLocation.ArmorFacings.Values)
                    {
                        dArmorFactor += (double)facing.ArmorPoints * facing.ArmorType.BattleValueModifier * 2.5D;
                    }
                    dStructureFactor += 1.5D * (double)armorHitLocation.Structure.StructurePoints * Engine.BattleValueModifier * armorHitLocation.Structure.StructureType.BattleValueModifier;
                }

                //TODO: We ned to calculate all the defensive equipment BV,
                //which means being able to identify which equipment is
                //defensive (TM302)

                ComponentGyro gyro = null;
                foreach (UnitComponent curUnitComponent in Components)
                {
                    //Gyro Factor
                    ComponentGyro curGyro = curUnitComponent.Component as ComponentGyro;
                    if (curGyro != null) gyro = curGyro;
                    
                    //Subtract Volatile Weapons (Gauss Rifles)
                    ComponentWeapon curWeapon = curUnitComponent.Component as ComponentWeapon;
                    if (curWeapon != null)
                    {
                        lstWeapons.Add(curWeapon);
                        if (curWeapon.VolatileDamage > 0)
                        {
                            if (TechnologyBase == TECHNOLOGY_BASE.CLAN &&
                                (Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "CT") ||
                                Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "LL") ||
                                Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "RL") ||
                                Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "HD")))
                                dExplosiveAmmoFactor -= curWeapon.CriticalSpaceMech ?? 0;
                            if (TechnologyBase == TECHNOLOGY_BASE.INNERSPHERE &&
                                Engine.EngineType == "XL")
                                dExplosiveAmmoFactor -= curWeapon.CriticalSpaceMech ?? 0;
                            if (TechnologyBase == TECHNOLOGY_BASE.INNERSPHERE &&
                                (Engine.EngineType == "Standard" || Engine.EngineType == "Light") &&
                                (Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "CT") ||
                                Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "LL") ||
                                Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "RL") ||
                                Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "HD") ||
                                !Utilities.LocationHasCASE(curUnitComponent.HitLocation as BattleMechHitLocation)))
                                dExplosiveAmmoFactor -= curWeapon.CriticalSpaceMech ?? 0;
                        }
                        int iHeat = curWeapon.Heat;
                        ComponentWeaponClustered clustered = curWeapon as ComponentWeaponClustered;
                        if (clustered != null)
                            if (clustered.HeatIsPerShot) iHeat *= clustered.SalvoSize;
                        if (curWeapon.Name.Contains("Streak")) iHeat /= 2; //TM303
                        if (curWeapon.Name.Contains("(OS)")) iHeat /= 4; //TM303
                        dMaximumHeat += (double)iHeat;
                        dWeaponBV += curWeapon.BV;
                    }
                    

                    //Subtract Ammunition
                    ComponentAmmunition curAmmo = curUnitComponent.Component as ComponentAmmunition;
                    if (curAmmo != null)
                    {
                        lstAmmunition.Add(curAmmo);
                        //iAmmoBV += curAmmo.BV;
                        if (curAmmo.Volatile)
                        {
                            if ((Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "CT") ||
                                Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "LL") ||
                                Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "RL") ||
                                Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "HD")) && TechnologyBase == TECHNOLOGY_BASE.CLAN)
                            {
                                dExplosiveAmmoFactor -= 15;
                            }
                            if (Engine.EngineType == "XL" &&
                                TechnologyBase == TECHNOLOGY_BASE.INNERSPHERE)

                            {
                                dExplosiveAmmoFactor -= 15;
                            }
                            //TODO: I think this covers the Explosive Ammo elements
                            //on TM303.  It is strangely worded.
                            if ((Engine.EngineType == "Standard" || Engine.EngineType == "Light") &&
                                TechnologyBase == TECHNOLOGY_BASE.INNERSPHERE &&
                                (!Utilities.LocationHasCASE(curUnitComponent.HitLocation as BattleMechHitLocation) ||
                                (Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "CT") ||
                                Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "LL") ||
                                Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "RL") ||
                                Utilities.IsSynonymFor(curUnitComponent.HitLocation.Name, "HD"))))
                            {
                                dExplosiveAmmoFactor -= 15;
                            }



                        }
                    }
                    if (curUnitComponent.Component.DefensiveBV) dDefensiveEquipment += curUnitComponent.Component.BV;
                }
                if (gyro == null) return 0;

                double dGyro = Tonnage * gyro.BattleValueModifier;


                double dDefensiveFactor = 1D + ((double)Utilities.MaxmiumDefensiveModifier(this) / 10D);

                double dDefensiveBV = (dGyro + dExplosiveAmmoFactor + dArmorFactor + dStructureFactor + dDefensiveEquipment) * dDefensiveFactor;

                //Offensive BV (TM303)
                double dOffensiveBV = 0;
                double dMechHeatEfficiency = 6 + HeatDissipation - Math.Max(3, JumpMP);
                double dOffensiveWeaponBV = 0;
                double dOffensiveAmmoBV = 0;
                double dOffensiveOtherBV = 0;
                double dTotalHeat = 0;
                
                //TODO: ICE-powered Mechs should have a Movment Heat of zero.

                foreach(ComponentWeapon weapon in lstWeapons)
                {
                    dTotalHeat += weapon.BVHeatPoints;
                    dOffensiveWeaponBV += weapon.BV;
                }



                if (dTotalHeat > dMechHeatEfficiency)
                {

                    lstWeapons.Sort((a, b) =>
                    {
                        if (a.BV != b.BV)
                            return a.BV.CompareTo(b.BV);
                        else
                            return a.BVHeatPoints.CompareTo(b.BVHeatPoints);
                    });
                    double dSubtotalBV = 0;
                    double dSubtotalHeat = 0;
                    Queue<ComponentWeapon> queueReductionSet = new Queue<ComponentWeapon>(lstWeapons);
                    bool bAddAtHalfValue = false;
                    while(queueReductionSet.Count > 0)
                    {

                        ComponentWeapon NextWeapon = queueReductionSet.Dequeue();
                        dSubtotalHeat = NextWeapon.BVHeatPoints;
                        if (dSubtotalHeat > dMechHeatEfficiency || NextWeapon.BVHeatPoints == 0)
                            dSubtotalBV = NextWeapon.BV/2;
                        else
                            dSubtotalBV = NextWeapon.BV;

                    }
                }

                foreach(ComponentAmmunition ammo in lstAmmunition)
                {
                    //TODO: Excessive Ammo rule on TM303.
                    dOffensiveAmmoBV += ammo.BV;
                }
                bool bMASC = false;
                bool bTSM = false;
                //Offensive equipment that isn't weapons
                foreach(UnitComponent comp in Components)
                {
                    ComponentWeapon weap = comp.Component as ComponentWeapon;
                    ComponentAmmunition ammo = comp.Component as ComponentAmmunition;
                    
                    if(weap == null)
                    {
                        if (ammo == null) if (!comp.Component.DefensiveBV) dOffensiveOtherBV += comp.Component.BV;
                    }

                }
                double dTonnageModifier = Tonnage;
                if (MyomerType.Name.Contains("TSM")) Tonnage *= 1.5;
                
                dOffensiveBV = dOffensiveWeaponBV + dOffensiveAmmoBV + dOffensiveOtherBV + Tonnage;

                int  iSpeedFactorResult = RunMP + (int)Math.Round(((double)JumpMP / 2D) + 0.5);
                if (MyomerType.Name.Contains("MASC") || MyomerType.Name.Contains("TSM")) iSpeedFactorResult += 1;
                
                
                double[] SpeedFactorTable = { 0.44,0.54,0.65,0.77,0.88,1,1.12,1.24,1.37,1.50,1.63,1.76,1.89,2.02,2.16,2.3,2.44,2.58,2.72,2.86,3,3.15,3.29,3.44,3.59,3.75};
                
                //TODO: Adjust this speed factor for MASC/TSM
                //double SpeedFactor = 1D + Math.Pow(((double)RunMP + ((double)JumpMP / 2D) - 5D) / 10D, 1.2); //TM315
                
                double SpeedFactor = SpeedFactorTable[iSpeedFactorResult];

                dOffensiveBV *= SpeedFactor;


                iAccumulator = (int)Math.Round(dDefensiveBV + dOffensiveBV);

                return iAccumulator;
                */

                return Ledger.RootNode.Value;
            }
        }

        public static int InternalStructureByLocation(string sLocation, int Tonnage)
        {
            int[,] iTable = new int[,]
            {
                {3,6,5,3,4},
                {3,8,6,4,6},
                {3,10,7,5,7},
                {3,11,8,6,8},
                {3,12,10,6,10},
                {3,14,11,7,11 },
                {3,16,12,8,12 },
                {3,18,13,9,13 },
                {3,20,14,10,14 },
                {3,21,15,10,15 },
                {3,22,15,11,15 },
                {3,23,16,12,16 },
                {3,25,17,13,17 },
                {3,27,18,14,18 },
                {3,29,19,15,19 },
                {3,30,20,16,20 },
                {3,31,21,17,21 }
            }; //TM47

            int iTonnage = Tonnage / 5 - 4;
            int iLocation = 0;
            if (sLocation.Equals("Head") || sLocation.Equals("HD")) iLocation = 0;
            if (sLocation.Equals("Left Arm") || 
                sLocation.Equals("LA") ||
                sLocation.Equals("Right Arm") ||
                sLocation.Equals("RA") 
                ) iLocation = 3;
            if (sLocation.Equals("Front Left Leg") ||
                sLocation.Equals("FLL") ||
                sLocation.Equals("Front Right Leg") ||
                sLocation.Equals("FRL") ||
                sLocation.Equals("Rear Left Leg") ||
                sLocation.Equals("RLL") ||
                sLocation.Equals("Rear Right Leg") ||
                sLocation.Equals("RRL") || 
                sLocation.Equals("Left Leg") ||
                sLocation.Equals("LL") ||
                sLocation.Equals("Right Leg") ||
                sLocation.Equals("RL")
                ) iLocation = 4;
            if (sLocation.Equals("Left Torso") ||
                sLocation.Equals("LT") ||
                sLocation.Equals("Right Torso") ||
                sLocation.Equals("RT")
                ) iLocation = 2;
            if (sLocation.Equals("Center Torso") ||
                sLocation.Equals("CT") 
                ) iLocation = 1;
            return iTable[iTonnage,iLocation];
        }

        /// <summary>
        /// Written to help me debug issues with tonnage.
        /// </summary>
        public string TonnageLedger
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Nominal Tonnage: {Tonnage.ToString()}");
                double EngineTonnage = Engine.Tonnage;
                double StructureTonnage = Math.Ceiling(2D * StructureType.TonnageMultipler * Tonnage) / 2D; //Round up to nearest half-ton
                double MyomerTonnage = Math.Round((MyomerType.MassFraction * Tonnage),MidpointRounding.AwayFromZero); //Round to nearest ton (TM Errata 4.0)
                sb.AppendLine($"{Engine.EngineType} {Engine.EngineRating} Engine Tonnage: {EngineTonnage.ToString()}");
                sb.AppendLine($"{StructureType.Name} Structure Tonnage: {StructureTonnage.ToString()}");
                sb.AppendLine($"{MyomerType.Name} Myomer Tonnage: {MyomerTonnage.ToString()}");
                double retval = base.ComputedTonnage;
                sb.AppendLine($"Base Computed Tonnage: {retval.ToString()}");
                retval += EngineTonnage;
                retval += StructureTonnage; 
                retval += MyomerTonnage;
                double ArmorTonnage = 0;
                string sArmorType = "";
                foreach (BattleMechHitLocation bmhl in HitLocations)
                {
                    foreach (ArmorFacing armorFacing in bmhl.ArmorFacings.Values)
                    {
                        retval += armorFacing.Tonnage;
                        ArmorTonnage += armorFacing.Tonnage;
                        sArmorType = armorFacing.ArmorType.Name;
                    }
                }
                retval += ArmorTonnage;
                ArmorTonnage = Math.Ceiling(2D * ArmorTonnage) / 2D; //Round to nearest half-ton
                
                sb.AppendLine($"{sArmorType} Armor Tonnage: {ArmorTonnage.ToString()}");
                foreach(UnitComponent comp in Components)
                {
                    if(comp.Component.Tonnage > 0)
                    sb.AppendLine($"{comp.Component.Name}: {comp.Component.Tonnage}");
                }
                return sb.ToString();
            }
        }

        public override double ComputedTonnage
        {
            get
            {
                double retval = base.ComputedTonnage;
                retval += Engine.Tonnage;
                retval += StructureType.TonnageMultipler * Tonnage;
                retval += Math.Round(MyomerType.MassFraction * Tonnage,MidpointRounding.AwayFromZero); //TM Errata v4.0
                double totalArmorTonnage = 0;
                foreach(BattleMechHitLocation bmhl in HitLocations )
                {
                    foreach(ArmorFacing armorFacing in bmhl.ArmorFacings.Values)
                    {
                       totalArmorTonnage += armorFacing.Tonnage;
                    }
                }
                retval += Math.Ceiling(2D * totalArmorTonnage) / 2D;
                return retval;
            }
        }

        public int WalkMP
        {
            get
            {
                int iBaseWalk = (int)Math.Floor((double)Engine.EngineRating / (double)Tonnage);
                return iBaseWalk;
            }
        }

        public int RunMP
        {
            get
            {
                int iBaseRun = (int)Math.Floor((double)WalkMP * 1.5D);
                return iBaseRun;
            }
        }

        public int JumpMP
        {
            get
            {
                int iBaseJumpMP = 0;
                bool bImproved = false;
                foreach(UnitComponent component in Components)
                {
                    ComponentJumpJet componentJumpJet = component.Component as ComponentJumpJet;
                    if(componentJumpJet != null)
                    {
                        if (componentJumpJet.Improved) bImproved = true;
                        iBaseJumpMP++;
                    }
                }
                if(bImproved)
                {
                    if (iBaseJumpMP > RunMP) iBaseJumpMP = RunMP;
                }
                else
                {
                    if (iBaseJumpMP > WalkMP) iBaseJumpMP = WalkMP;
                }

                return iBaseJumpMP;
            }

        }

        public int HeatDissipation
        {
            get
            {
                int retval = Engine.CriticalFreeHeatSinks;
                foreach (UnitComponent unitComponent in Components)
                {
                    ComponentHeatSink hs = unitComponent.Component as ComponentHeatSink;
                    if (hs != null)
                    {
                        retval += hs.HeatDissipation;
                    }
                }

                return retval;
            }
        }
    }
}
