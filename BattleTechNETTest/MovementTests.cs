using System;
using Xunit;
using BattleTechNET;
using BattleTechNET.AlphaStrike;
using BattleTechNET.StrategicBattleForce;
using BattleTechNET.Common;

namespace BattleTechNETTest
{
    public class MovementTests
    {
        [Trait("Category", "Strategic Battleforce Movement")]
        [Fact(DisplayName ="Aggregate Movement For Lance of Identical BattleMechs")]
        public void BattleForceUnitMovementAggregateLikeBattlemechs()
        {
            //Get a Lance of BattleMechs
            Element element1 = Utilities.GenerateASBattleMech("Element 1", 4, 6, 3, 5, 5, 2, 3, 1);
            Element element2 = Utilities.GenerateASBattleMech("Element 2", 4, 6, 3, 5, 5, 2, 3, 1);
            Element element3 = Utilities.GenerateASBattleMech("Element 3", 4, 6, 3, 5, 5, 2, 3, 1);
            Element element4 = Utilities.GenerateASBattleMech("Element 4", 4, 6, 3, 5, 5, 2, 3, 1);

            Unit unit = new Unit();
            unit.Name = "Test Unit";
            unit.Elements.Add(element1);
            unit.Elements.Add(element2);
            unit.Elements.Add(element3);
            unit.Elements.Add(element4);

            unit.CalculateStats();

            foreach(MovementMode unitMovementMode in unit.MovementModes)
            {
                if (unitMovementMode.Code == "") Assert.Equal(6, unitMovementMode.Points);
                if (unitMovementMode.Code == "j") Assert.Equal(3, unitMovementMode.Points);
            }

        }
        [Trait("Category","Strategic Battleforce Movement")]
        [Fact(DisplayName = "Aggregate Movement For Lance of Different BattleMechs")]
        public void BattleForceUnitMovementAggregateDifferentBattlemechs()
        {
            //Get a Lance of BattleMechs
            Element element1 = Utilities.GenerateASBattleMech("Element 1", 4, 6, 6, 5, 5, 2, 3, 1);
            Element element2 = Utilities.GenerateASBattleMech("Element 2", 4, 4, 4, 5, 5, 2, 3, 1);
            Element element3 = Utilities.GenerateASBattleMech("Element 3", 4, 3, 3, 5, 5, 2, 3, 1);
            Element element4 = Utilities.GenerateASBattleMech("Element 4", 4, 4, 1, 5, 5, 2, 3, 1);

            Unit unit = new Unit();
            unit.Name = "Test Unit";
            unit.Elements.Add(element1);
            unit.Elements.Add(element2);
            unit.Elements.Add(element3);
            unit.Elements.Add(element4);

            unit.CalculateStats();

            foreach (MovementMode unitMovementMode in unit.MovementModes)
            {
                if (unitMovementMode.Code == "") Assert.Equal(3, unitMovementMode.Points);
                if (unitMovementMode.Code == "j") Assert.Equal(1, unitMovementMode.Points);
            }

        }
        [Trait("Category", "Strategic Battleforce Movement")]
        [Fact(DisplayName = "Aggregate Movement For Lance of Mixed Jump-Capability BattleMechs")]
        public void BattleForceUnitMovementAggregateMixedJumpCapableBattlemechs()
        {
            //Get a Lance of BattleMechs
            Element element1 = Utilities.GenerateASBattleMech("Element 1", 4, 6, 6, 5, 5, 2, 3, 1);
            Element element2 = Utilities.GenerateASBattleMech("Element 2", 4, 4, 4, 5, 5, 2, 3, 1);
            Element element3 = Utilities.GenerateASBattleMech("Element 3", 4, 3, 3, 5, 5, 2, 3, 1);
            Element element4 = Utilities.GenerateASBattleMech("Element 4", 4, 4, 0, 5, 5, 2, 3, 1);

            Unit unit = new Unit();
            unit.Name = "Test Unit";
            unit.Elements.Add(element1);
            unit.Elements.Add(element2);
            unit.Elements.Add(element3);
            unit.Elements.Add(element4);

            unit.CalculateStats();

            foreach (MovementMode unitMovementMode in unit.MovementModes)
            {
                if (unitMovementMode.Code == "") Assert.Equal(3, unitMovementMode.Points);
                Assert.NotEqual("j", unitMovementMode.Code); //Jump shouldn't even be on the Movement Mode list.
            }

        }

    }
}
