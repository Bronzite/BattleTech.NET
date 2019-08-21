using System;

namespace BattleTechNET.TotalWarfare
{
    public class Unit:IGameObject
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
    }
}
