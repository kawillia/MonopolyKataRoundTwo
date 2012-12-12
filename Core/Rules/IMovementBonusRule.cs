using System;

namespace MonopolyKata.Core.Rules
{
    public interface IMovementBonusRule
    {
        Int32 GetBonus(Int32 startingLocation, Int32 numberOfSpaces);
    }
}
