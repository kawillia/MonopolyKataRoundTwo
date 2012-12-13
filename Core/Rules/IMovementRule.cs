using System;

namespace MonopolyKata.Core.Rules
{
    public interface IMovementRule
    {
        void Apply(Player player, Int32 numberOfSpaces);
    }
}
