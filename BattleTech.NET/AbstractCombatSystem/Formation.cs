using System;

namespace BattleTechNET.AbstractCombatSystem
{
    public class Formation:IGameObject 
    {
        public Guid Id { get; set; }

        public string Name { get; set; }


    }
}
