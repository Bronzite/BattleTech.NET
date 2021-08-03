using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    public class ComponentMace : ComponentWeapon, IDesignConfigured
    {
        public ComponentMace()
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
            ToHitModifier = 1;
            Name = "Mace";
        }

        public ComponentMace(BattleMechDesign battleMechDesign) : this()
        {
            Configure(battleMechDesign);
        }

        public void Configure(Design design)
        {
            BattleMechDesign battleMechDesign = design as BattleMechDesign;

            int iMaceBaseState = (int)Math.Ceiling(battleMechDesign.Tonnage / 10);
            Tonnage = (double)iMaceBaseState;
            CriticalSpaceMech = iMaceBaseState;
            Damage = (int)Math.Ceiling(battleMechDesign.Tonnage / 4);
        }

        public static void ResolveComponent(Design design)
        {
            List<Component> components = new List<Component>()
            {
                new ComponentMace(design as BattleMechDesign)
            };
            foreach (HitLocation location in design.HitLocations)
            {
                BattleMechHitLocation bmhl = location as BattleMechHitLocation;
                Dictionary<Component, List<CriticalSlot>> dicComponents = new Dictionary<Component, List<CriticalSlot>>();
                foreach (Component component in components)
                {
                    dicComponents.Add(component, new List<CriticalSlot>());
                }

                foreach (CriticalSlot criticalSlot in bmhl.CriticalSlots)
                {
                    foreach (Component sKey in dicComponents.Keys)
                        if (Utilities.IsSynonymFor(sKey, criticalSlot.Label))
                            dicComponents[sKey].Add(criticalSlot);
                }

                foreach (Component component in dicComponents.Keys)
                {
                    if (dicComponents[component].Count == component.CriticalSpaceMech)
                    {
                        //Add component to design
                        UnitComponent uc = new UnitComponent(component.Clone() as Component, location);
                        foreach (CriticalSlot criticalSlot in dicComponents[component])
                        {
                            criticalSlot.AffectedComponent = uc;
                        }
                        design.Components.Add(uc);
                    }
                }
            }
        }

        public override Component CreateInstance()
        {
            return new ComponentMace();
        }

        public override object Clone()
        {
            ComponentMace retval = base.Clone() as ComponentMace;
            return retval;
        }

        public override double BV { get => (int)(Damage * 1); set => base.BV = value; }
    }
}
