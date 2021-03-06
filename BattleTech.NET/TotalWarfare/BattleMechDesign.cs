﻿using BattleTechNET.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.TotalWarfare
{
    public class BattleMechDesign:Design
    {
        public Guid Id { get; set; }
        public Common.ComponentEngine Engine { get; set; }
        public StructureType StructureType { get; set; }
        public MyomerType MyomerType { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1}", this.Model, this.Variant);
        }
        public override double BV
        {
            get
            {
                int iAccumulator = 0;

                //Defensive Battle Rating
                double dArmorFactor = 0;
                
                foreach(ArmorHitLocation armorHitLocation in HitLocations)
                {
                    foreach(ArmorFacing facing in armorHitLocation.ArmorFacings.Values)
                    {
                        dArmorFactor += (double)facing.ArmorPoints * facing.ArmorType.BattleValueModifier * 2.5D;
                    }
                }



                return iAccumulator;
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
    }
}
