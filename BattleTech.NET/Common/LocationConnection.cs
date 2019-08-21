
using System;


namespace BattleTechNET.Common
{
    public class LocationConnection
    {
        public Guid Id { get; set; }
        public ILocation SourceLocation { get; set; }
        public ILocation TargetLocation { get; set; }
        public MovementMode MovementModeCost {get;set;}
    }
}
