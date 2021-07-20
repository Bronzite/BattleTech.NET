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
    }
}

