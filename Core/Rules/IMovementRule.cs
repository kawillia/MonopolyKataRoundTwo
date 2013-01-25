using System;

namespace MonopolyKata.Core.Rules
{
    public interface IMovementRule
    {
        void Apply(String player, Int32 currentLocation, Int32 numberOfSpaces);
    }
}
