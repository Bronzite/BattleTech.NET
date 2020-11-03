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
                sb.AppendLine($"{Engine.EngineType} {Engine.EngineRating} Engine Tonnage: {Engine.Tonnage.ToString()}");
                sb.AppendLine($"{StructureType.Name} Structure Tonnage: {(StructureType.TonnageMultipler * Tonnage).ToString()}");
                sb.AppendLine($"{MyomerType.Name} Myomer Tonnage: {(MyomerType.MassFraction * Tonnage).ToString()}");
                double retval = base.ComputedTonnage;
                retval += Engine.Tonnage;
                retval += StructureType.TonnageMultipler * Tonnage;
                retval += MyomerType.MassFraction * Tonnage;
                double ArmorFacing = 0;
                string sArmorType = "";
                foreach (BattleMechHitLocation bmhl in HitLocations)
                {
                    foreach (ArmorFacing armorFacing in bmhl.ArmorFacings.Values)
                    {
                        retval += armorFacing.Tonnage;
                        ArmorFacing += armorFacing.Tonnage;
                        sArmorType = armorFacing.ArmorType.Name;
                    }
                }

                sb.AppendLine($"{sArmorType} Armor Tonnage: {ArmorFacing.ToString()}");
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
                retval += MyomerType.MassFraction * Tonnage;
                
                foreach(BattleMechHitLocation bmhl in HitLocations )
                {
                    foreach(ArmorFacing armorFacing in bmhl.ArmorFacings.Values)
                    {
                        retval += armorFacing.Tonnage;
                    }
                }
                return retval;
            }
        }
    }
}
