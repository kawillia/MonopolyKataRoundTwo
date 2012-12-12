using System;
using MonopolyKata.Classic;
using MonopolyKata.Core.Rules;
using MonopolyKata.Core.Strategies;

namespace MonopolyKata.Classic.Rules
{
    public class ClassicPassGoBonusRule : IMovementBonusRule
    {
        public Int32 GetBonus(Int32 startingLocation, Int32 numberOfSpacesToMove)
        {
            if (startingLocation + numberOfSpacesToMove >= ClassicBoardFactory.NumberOfLocations)
                return ClassicGameConstants.GoSalaryBonus;

            return 0;
        }
    }
}
