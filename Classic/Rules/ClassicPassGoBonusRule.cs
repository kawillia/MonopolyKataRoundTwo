using System;
using MonopolyKata.Classic;
using MonopolyKata.Core;
using MonopolyKata.Core.Rules;

namespace MonopolyKata.Classic.Rules
{
    public class ClassicPassGoBonusRule : IMovementRule
    {
        private Banker banker;

        public ClassicPassGoBonusRule(Banker banker)
        {
            this.banker = banker;
        }

        public void Apply(Player player, Int32 numberOfSpacesToMove)
        {
            if (player.CurrentLocation + numberOfSpacesToMove >= ClassicBoardFactory.NumberOfSpaces)
                banker.Pay(player, ClassicGameConstants.GoSalaryBonus);
        }
    }
}
