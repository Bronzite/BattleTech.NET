using System;

namespace BattleTechNET.TotalWarfare
{
    public class Unit:IGameObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
