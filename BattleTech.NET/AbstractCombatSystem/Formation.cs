using System;

namespace BattleTechNET.AbstractCombatSystem
{
    public class Formation:IGameObject 
    {
        public Guid ID { get; set; }

        public string Name { get; set; }


    }
}
