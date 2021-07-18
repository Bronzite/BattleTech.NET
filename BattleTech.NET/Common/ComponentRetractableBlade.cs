using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BattleTechNET.Common
{
    public class ComponentRetractableBlade:ComponentWeapon,IDesignConfigured
    {
        public ComponentRetractableBlade()
        {
            TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE;
            CriticalSpaceCombatVehicle = int.MaxValue;
            CriticalSpaceDropShips = int.MaxValue;
            CriticalSpaceFighters = int.MaxValue;
            CriticalSpaceMech = 1;
            CriticalSpaceProtomech = int.MaxValue;
            CriticalSpaceSmallCraft = int.MaxValue;
            CriticalSpaceSupportVehicle = int.MaxValue;
            AeroDamage = 0;
            Heat = 0;
            AeroHeat = 0;
            AeroRange = AerospaceWeaponRanges.SHORT;
            TechRating = "B";
            AeroRange = AerospaceWeaponRanges.NA;
            HeatIsPerShot = true;
            Name = "Retractable Blade";
        }

        public ComponentRetractableBlade(BattleMechDesign battleMechDesign):this()
        {
            Configure(battleMechDesign);
        }

        public static void ResolveComponents(Design design)
        {
            foreach (HitLocation location in design.HitLocations)
            {
                BattleMechHitLocation bmhl = location as BattleMechHitLocation;
                List<CriticalSlot> slots = new List<CriticalSlot>();

                ComponentRetractableBlade componentRetractableBlade = new ComponentRetractableBlade();
                componentRetractableBlade.Configure(design);
                if (design.IsCompatible(componentRetractableBlade))
                {


                    foreach (CriticalSlot criticalSlot in bmhl.CriticalSlots)
                    {
                        if (Utilities.IsSynonymFor(componentRetractableBlade, criticalSlot.Label))
                            slots.Add(criticalSlot);
                    }


                    if (slots.Count == componentRetractableBlade.CriticalSpaceMech)
                    {
                        UnitComponent uc = new UnitComponent(componentRetractableBlade, bmhl);
                        design.Components.Add(uc);
                    }
                }
            }

        }

        public void Configure(Design design)
        {
            BattleMechDesign battleMechDesign = design as BattleMechDesign;

            double dRetractableBladeBaseStat = Math.Ceiling(2D * battleMechDesign.Tonnage / 20D)/2D ;
            Tonnage = (double)dRetractableBladeBaseStat + 0.5D;
            CriticalSpaceMech = (int)Math.Ceiling(dRetractableBladeBaseStat) + 1;
            Damage = (int)Math.Ceiling(battleMechDesign.Tonnage / 10);
        }

        public override Component CreateInstance()
        {
            return new ComponentRetractableBlade();
        }

        public override object Clone()
        {
            ComponentRetractableBlade retval = base.Clone() as ComponentRetractableBlade;
            return retval;
        }

        public override double BV { get => (int)((double)(Damage) * 1.725); set => base.BV = value; }
    }
}

