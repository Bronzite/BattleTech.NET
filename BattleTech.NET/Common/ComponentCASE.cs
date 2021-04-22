using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    class ComponentCASE:Component,IDesignConfigured
    {
        public static List<ComponentCASE> GetCanonicalCASE()
        {
            List<ComponentCASE> retval = new List<ComponentCASE>();

            retval.Add(new ComponentCASE()
                .AddAlias("ISCASE")
                .AddAlias("CLCASE") as ComponentCASE);
            retval.Add(new ComponentCASE() { Name = "CASE II",Tonnage=1,TechnologyBase= TECHNOLOGY_BASE.INNERSPHERE,TechRating="E" }
                .AddAlias("ISCASEII")
                .AddAlias("ISCASE II")
                as ComponentCASE);
            retval.Add(new ComponentCASE() { Name = "CASE II", Tonnage = 0.5, TechnologyBase = TECHNOLOGY_BASE.CLAN, TechRating = "F" }
                .AddAlias("CLCASEII")
                .AddAlias("CLCASE II")
                as ComponentCASE);
            return retval;
        }

        public ComponentCASE()
        {
            Name = "CASE";
            TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE;
            Tonnage = 0.5;
            CriticalSpaceMech = 1;
            BaseCost = 50000; //TM292

        }
        public ComponentCASE(Design design):this()
        {
            Configure(design);

        }

        public static void ResolveComponent(Design design)
        {
            List<ComponentCASE> caseComponents = ComponentCASE.GetCanonicalCASE();
            foreach (HitLocation location in design.HitLocations)
            {
                BattleMechHitLocation bmhl = location as BattleMechHitLocation;
                Dictionary<ComponentCASE, List<CriticalSlot>> dicComponents = new Dictionary<ComponentCASE, List<CriticalSlot>>();
                foreach (ComponentCASE component in caseComponents)
                {
                    dicComponents.Add(component, new List<CriticalSlot>());
                }

                foreach (CriticalSlot criticalSlot in bmhl.CriticalSlots)
                {
                    foreach (ComponentCASE sKey in dicComponents.Keys)
                        if (Utilities.IsSynonymFor(sKey, criticalSlot.Label))
                            dicComponents[sKey].Add(criticalSlot);
                }

                foreach (ComponentCASE component in dicComponents.Keys)
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

        public void Configure(Design design)
        {
            //TODO: CASE's critical space varies wildly on the basis of the
            //the design type, especially ground vehicles vs aircraft.  See
            //TM210 for details.
            this.TechnologyBase = design.TechnologyBase;
        }

        public override Component CreateInstance()
        {
            return new ComponentCASE();
        }

        public override object Clone()
        {
            ComponentCASE retval = base.Clone() as ComponentCASE;
            return retval;
        }
    }
}

