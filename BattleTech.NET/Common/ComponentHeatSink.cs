using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.Common
{
    public class ComponentHeatSink:Component
    {
        public int HeatDissipation { get; set; }
        public bool Integral { get; set; }

        public ComponentHeatSink()
        {
            Tonnage = 1;
        }

        public ComponentHeatSink(TECHNOLOGY_BASE techBase, bool bSingle, bool bIntegral, bool bFirstTen):this()
        {
            this.TechnologyBase = techBase;
            if(!bSingle)
            {
                if (TechnologyBase == TECHNOLOGY_BASE.CLAN)
                {
                    Name = "Clan Double Heat Sink";
                    CriticalSpaceMech = 2;
                }
                else
                {
                    Name = "Double Heat Sink";
                    CriticalSpaceMech = 3;
                }
                HeatDissipation = 2;
            }
            else
            {
                Name = "Heat Sink";
                CriticalSpaceMech = 1;
                HeatDissipation = 1;
            }
            Integral = bIntegral;
            if (Integral)
                Name = $"Integral {Name}";
            if(bFirstTen)
                Tonnage = 0;
            
        }

        public override Component CreateInstance()
        {
            return new ComponentHeatSink();
        }

        public override object Clone()
        {
            ComponentHeatSink retval = base.Clone() as ComponentHeatSink;
            retval.HeatDissipation = HeatDissipation;
            retval.Integral = Integral;
            return retval;
        }

        static public void ResolveComponents(Design design)
        {

            BattleMechDesign bmd = design as BattleMechDesign;
            

            
            int iCritFreeHitsinks = 10 - Math.Min(bmd.Engine.CriticalFreeHeatSinks,bmd.HeatDissipation);
            //Add tonnage for integral heat sinks that require tonnage

            if(iCritFreeHitsinks < 0)
                foreach (BattleMechHitLocation bmhl in bmd.HitLocations)
                {
                    if(Utilities.IsSynonymFor("CT", bmhl.Name))
                    {
                        while (iCritFreeHitsinks < 0)
                        {
                            ComponentHeatSink heatSink = new ComponentHeatSink(bmd.TechnologyBase, true, false,false);
                            UnitComponent uc = new UnitComponent(heatSink, bmhl);
                            design.Components.Add(uc);
                            iCritFreeHitsinks++;
                        }

                        for (int i = 0; i<Math.Min(bmd.Engine.CriticalFreeHeatSinks, 10); i++)
                        {
                            ComponentHeatSink hs = new ComponentHeatSink(bmd.TechnologyBase, !bmd.DoubleIntegralHeatSinks, true, true);
                            UnitComponent unitComponent = new UnitComponent(hs, bmhl);
                            design.Components.Add(unitComponent);
                        }
                    }
                }
            int iDoubleHeatSinkCritSlots = 3;
            if(bmd.TechnologyBase == TECHNOLOGY_BASE.CLAN)
            {
                iDoubleHeatSinkCritSlots = 2;
            }
            foreach (BattleMechHitLocation bmhl in bmd.HitLocations)
            {

                int iHeatSinkCount = 0;
                int iDoubleHeatSinkCount = 0;
                foreach (CriticalSlot slot in bmhl.CriticalSlots)
                {
                    if (slot.Label.Contains("Heat Sink", StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (slot.Label.Contains("Double", StringComparison.CurrentCultureIgnoreCase))
                        {
                            iDoubleHeatSinkCount++;
                        }
                        else
                        {
                            iHeatSinkCount++;
                        }
                    }
                }

                while(iHeatSinkCount > 0)
                {
                    ComponentHeatSink heatSink = new ComponentHeatSink(bmd.TechnologyBase, true, false, (iCritFreeHitsinks-->0));
                    UnitComponent uc = new UnitComponent(heatSink, bmhl);
                    design.Components.Add(uc);
                    iHeatSinkCount--;
                }
                while (iDoubleHeatSinkCount > 0)
                {
                    ComponentHeatSink heatSink = new ComponentHeatSink(bmd.TechnologyBase, true, false, (iCritFreeHitsinks-->0));
                    UnitComponent uc = new UnitComponent(heatSink, bmhl);
                    design.Components.Add(uc);
                    iDoubleHeatSinkCount-=iDoubleHeatSinkCritSlots;
                }

            }

        }

    }
}

