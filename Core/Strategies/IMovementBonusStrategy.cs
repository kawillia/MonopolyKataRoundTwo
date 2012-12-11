using System;

namespace MonopolyKata.Core.Strategies
{
    public interface IMovementBonusStrategy
    {
        Int32 GetBonus(Int32 startingLocation, Int32 numberOfSpaces);
    }
}
