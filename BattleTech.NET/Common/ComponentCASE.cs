using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    class ComponentCASE:Component,IDesignConfigured
    {
        public ComponentCASE()
        {
            Name = "CASE";
            TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE;
            Tonnage = 0.5;
            //TODO: Add CASE Cost

        }
        public ComponentCASE(Design design):this()
        {
            Configure(design);

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

