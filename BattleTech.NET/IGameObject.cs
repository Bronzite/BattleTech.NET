using System;


namespace BattleTechNET
{
    public interface IGameObject
    {
        Guid Id { get; }
        string Name { get; }

    }
}
