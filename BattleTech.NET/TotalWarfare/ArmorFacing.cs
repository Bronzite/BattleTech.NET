using System;

namespace BattleTechNET.TotalWarfare
{
    public class ArmorFacing
    {
        public ArmorFacing()
        {
            ArmorType = new ArmorType();
        }
        public ArmorType ArmorType { get; set; }
        public int ArmorPoints { get; set; }
        public virtual double Tonnage { get { return (double)ArmorPoints / ArmorType.PointsPerTon; } set { ArmorPoints = (int)Math.Round(Tonnage * ArmorType.PointsPerTon); } }
        public string Name { get; set; }

    }
}
