using System;
using MonopolyKata.Classic;
using MonopolyKata.Core.Strategies;

namespace MonopolyKata.Classic.Strategies
{
    public class PassGoBonusStrategy : IMovementBonusStrategy
    {
        public Int32 GetBonus(Int32 startingLocation, Int32 numberOfSpacesToMove)
        {
            if (startingLocation + numberOfSpacesToMove >= ClassicBoardFactory.NumberOfLocations)
                return ClassicGameConstants.GoSalaryBonus;

            return 0;
        }
    }
}
