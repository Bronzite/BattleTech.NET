using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    public class ComponentSupercharger:Component,IDesignConfigured
    {
        public ComponentSupercharger()
        {
            Tonnage = 1;
            CriticalSpaceMech = 1;
            CriticalSpaceFighters = 1;
            CriticalSpaceSupportVehicle = 1;
            TechnologyBase = TECHNOLOGY_BASE.BOTH;
            TechRating = "C";
            BaseCost = 50000; //TO407
            Name = "Supercharger";
            AddAlias("IS Super Charger");
            
        }

        public static void ResolveComponents(Design design)
        {
            foreach (HitLocation location in design.HitLocations)
            {
                BattleMechHitLocation bmhl = location as BattleMechHitLocation;
                List<CriticalSlot> slots = new List<CriticalSlot>();

                ComponentSupercharger componentSupercharger = new ComponentSupercharger();
                componentSupercharger.Configure(design);

                if (design.IsCompatible(componentSupercharger))
                {


                    foreach (CriticalSlot criticalSlot in bmhl.CriticalSlots)
                    {
                        if (Utilities.IsSynonymFor(componentSupercharger, criticalSlot.Label))
                            slots.Add(criticalSlot);
                    }


                    if (slots.Count == (int)(Math.Ceiling(componentSupercharger.Tonnage)))
                    {
                        UnitComponent uc = new UnitComponent(componentSupercharger, bmhl);
                        design.Components.Add(uc);
                    }
                }
            }

        }

        

        public override Component CreateInstance()
        {
            return new ComponentSupercharger();
        }

        public override object Clone()
        {
            Component retval = base.Clone() as ComponentSupercharger;
            return base.Clone();
        }

        public void Configure(Design design)
        {
            foreach(UnitComponent c in design.Components)
            {
                ComponentEngine engine = c.Component as ComponentEngine;
                if(engine!=null)
                {
                    Tonnage = engine.Tonnage / 10;
                    BaseCost = engine.EngineRating / 10;
                }
            }
        }
    }
}
