using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    public class ComponentWeaponClustered:ComponentWeapon
    {

        public static int[,] ClusterHitsTable =
            {
            {1,1,1,1,2,2,3,3,3,4,4,4,5,5,5,5,6,6,6,7,7,7,8,8,9,9,9,10,10,12}, //2
            {1,1,2,2,2,2,3,3,3,4,4,4,5,5,5,5,6,6,6,7,7,7,8,8,9,9,9,10,10,12}, //3
            {1,1,2,2,3,3,4,4,4,5,5,5,6,6,7,7,8,8,9,9,9,10,10,10,11,11,11,12,12,18}, //4
            {1,2,2,3,3,4,4,5,6,7,8,8,9,9,10,10,11,11,12,13,14,15,16,16,17,17,17,18,18,24 }, //5,
            {1,2,2,3,4,4,5,5,6,7,8,8,9,9,10,10,11,11,12,13,14,15,16,16,17,17,17,18,18,24 }, //6
            {1,2,3,3,4,4,5,5,6,7,8,8,9,9,10,10,11,11,12,13,14,15,16,16,17,17,17,18,18,24 }, //7
            {2,2,3,3,4,4,5,5,6,7,8,8,9,9,10,10,11,11,12,13,14,15,16,16,17,17,17,18,18,24 }, //8
            {2,2,3,4,5,6,6,7,8,9,10,11,11,12,13,14,14,15,16,17,18,19,20,21,21,22,23,23,24,32 }, //9
            {2,3,3,4,5,6,6,7,8,9,10,11,11,12,13,14,14,15,16,17,18,19,20,21,21,22,23,23,24,32 },//10
            {2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,40 }, //11
            {2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,40 } //12
        };

        public static int ClusterHitResult(int iClusterSize, int iModifiedRoll)
        {
            int iActualRollIndex = iModifiedRoll;
            int iActualClusterIndex = iClusterSize;
            if (iActualRollIndex < 2) iActualRollIndex = 2;
            if (iActualRollIndex > 12) iActualRollIndex = 12;
            iActualRollIndex -= 2;
            if (iActualClusterIndex == 40) iActualClusterIndex = 31;
            iActualClusterIndex -= 2;

            return ClusterHitsTable[iActualRollIndex, iActualClusterIndex];
        }

        public int SalvoSize { get; set; }
        public int DamagePerMissile { get { return Damage; } set { Damage = value; } }
        public bool Streak { get; set; }
        public ComponentFireControlSystem FireControlSystem { get; set; }

        public override object Clone()
        {
         
            ComponentWeaponClustered retval = base.Clone() as ComponentWeaponClustered;
            (retval as ComponentWeapon).CopyComponents(this);
            retval.SalvoSize = SalvoSize;
            retval.DamagePerMissile = DamagePerMissile;
            retval.Streak = Streak;
            if(FireControlSystem != null)
            retval.FireControlSystem = (ComponentFireControlSystem)FireControlSystem.Clone();
            return retval;
        }

        public override Component CreateInstance()
        {
            return new ComponentWeaponClustered();
        }

        public override double BVHeatPoints
        {
            get {
                if (Name.EndsWith("(OS)")) return (double)Heat / 4;
                if (Streak) return (double)Heat / 2;
                return (double)Heat;
            }
        }

    }
}
