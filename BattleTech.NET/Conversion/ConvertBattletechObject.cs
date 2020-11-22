using BattleTechNET.AlphaStrike;
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

    }
}
