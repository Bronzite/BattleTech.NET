using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.Common
{
    interface IBattleValue
    {
        double BV { get; }
    }
    interface IComponentBattleValue
    {
        double BV { get; }
        bool DefensiveBV { get; set; }
    }
}
