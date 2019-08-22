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

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Model, this.Variant);
        }

    }
}
