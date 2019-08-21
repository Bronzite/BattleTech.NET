using System;


namespace BattleTechNET
{
    public interface IGameObject
    {
        Guid ID { get; }
        string Name { get; }

    }
}
