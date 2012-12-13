using System;
using MonopolyKata.Classic;
using MonopolyKata.Core;
using MonopolyKata.Core.Rules;
using MonopolyKata.Core.Strategies;

namespace MonopolyKata.Classic.Rules
{
    public class ClassicPassGoBonusRule : IMovementRule
    {
        public void Apply(Player player, Int32 numberOfSpacesToMove)
        {
            if (player.CurrentLocation + numberOfSpacesToMove >= ClassicBoardFactory.NumberOfLocations)
                player.Receive(ClassicGameConstants.GoSalaryBonus);
        }
    }
}
