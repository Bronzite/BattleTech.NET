using System;

namespace BattleTechNET.TotalWarfare
{
    public class ArmorFacing
    {
        public virtual string Type { get { return "Standard"; } }
        public int ArmorPoints { get; set; }
        public virtual double Tonnage { get { return (double)ArmorPoints / 16; } set { ArmorPoints = (int)Math.Round(Tonnage * 16); } }
        public string Name { get; set; }

    }
}
