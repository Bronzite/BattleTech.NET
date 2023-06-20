using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.Common
{
    class ComponentJumpJet:Component
    {
        public ComponentJumpJet() { }
        public ComponentJumpJet(int iMechTonnage, bool bImproved) 
        {
            Name = "Jump Jet";
            if(iMechTonnage >= 10 && iMechTonnage < 60) { Tonnage = 0.5; CriticalSpaceMech = 1; }
            if (iMechTonnage >= 60 && iMechTonnage < 90) { Tonnage = 1; CriticalSpaceMech = 1; }
            if (iMechTonnage >= 90) { Tonnage = 2; CriticalSpaceMech = 1; }

            if(bImproved)
            {
                Name = "Improved Jump Jet";
                Tonnage *= 2;
                CriticalSpaceMech *= 2;
            }

        }
        public bool Improved { get; set; }


        public static void ResolveComponent(Design design)
        {
            //TM212: 

            foreach (HitLocation location in design.HitLocations)
            {
                BattleMechHitLocation bmhl = location as BattleMechHitLocation;
                List<CriticalSlot> slots = new List<CriticalSlot>();

                List<ComponentJumpJet> jumpJets = ComponentJumpJet.GetCanonicalJumpJets();


                foreach (CriticalSlot criticalSlot in bmhl.CriticalSlots)
                {
                    foreach (ComponentJumpJet componentJumpJet in jumpJets)
                    {
                        if (Utilities.IsSynonymFor(componentJumpJet, criticalSlot.Label))
                            slots.Add(criticalSlot);
                    }
                }
                
                
                int iComponentSlots = slots.Count;
                for(int i =0;i<slots.Count; i++)
                {
                    if (slots.Count > 0)
                    {
                        foreach(ComponentJumpJet componentJumpJet in jumpJets)
                        {
                            if(Utilities.IsSynonymFor(componentJumpJet,slots[i].Label))
                            {
                                if(iComponentSlots >= componentJumpJet.CriticalSpaceMech.Value)
                                {
                                    iComponentSlots -= componentJumpJet.CriticalSpaceMech.Value;

                                    ComponentJumpJet jumpjet = componentJumpJet.Clone() as ComponentJumpJet;
                                    jumpjet.Configure(design);


                                    UnitComponent uc = new UnitComponent(jumpjet, bmhl);
                                    design.Components.Add(uc);

                                }
                            }
                        }


                        
                    }
                }



            }
        }

        public void Configure(Design design)
        {
            BattleMechDesign battleMechDesign = design as BattleMechDesign;
            CriticalSpaceMech = 1;
            if (design.Tonnage <= 55)
                Tonnage = 0.5;
            else if (design.Tonnage <= 85)
                Tonnage = 1;
            else
                Tonnage = 2;

            if (Improved)
            {
                Tonnage *= 2;
                CriticalSpaceMech *= 2;
            }

        }

        public override Component CreateInstance()
        {
            return new ComponentJumpJet();
        }

        public static List<ComponentJumpJet> GetCanonicalJumpJets()
        {
            List<ComponentJumpJet> retval = new List<ComponentJumpJet>();

            retval.Add(new ComponentJumpJet() { Name = "Jump Jet", Tonnage = 0.5, CriticalSpaceMech = 1, TechnologyBase = TECHNOLOGY_BASE.BOTH, TechRating = "C" }
                .AddAlias("ISJumpJet")
				.AddAlias("Clan Jump Jet")
				.AddAlias("IS Jump Jet")
				.AddAlias("CLJumpJet") as ComponentJumpJet);
            retval.Add(new ComponentJumpJet() { Name = "Improved Jump Jet", Tonnage = 0.5, CriticalSpaceMech = 2, TechnologyBase = TECHNOLOGY_BASE.BOTH, TechRating = "C",Improved = true }
                .AddAlias("ImprovedJump Jet")
				.AddAlias("Clan Improved Jump Jet")
				.AddAlias("IS Improved Jump Jet")
				.AddAlias("ImprovedJumpJet") as ComponentJumpJet);

            return retval;
        }

        public override object Clone()
        {
            ComponentJumpJet retval = base.Clone() as ComponentJumpJet;
            retval.Improved = Improved;
            return retval;
        }
    }

}

