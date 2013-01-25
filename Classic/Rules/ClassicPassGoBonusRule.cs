using System;
using MonopolyKata.Classic;
using MonopolyKata.Core;
using MonopolyKata.Core.Rules;
using MonopolyKata.Core.Board;

namespace MonopolyKata.Classic.Rules
{
    public class ClassicPassGoBonusRule : IMovementRule
    {
        private Banker banker;

        public ClassicPassGoBonusRule(Banker banker)
        {
            this.banker = banker;
        }

        public void Apply(String player, Int32 currentLocation, Int32 numberOfSpacesToMove)
        {
            if (currentLocation + numberOfSpacesToMove >= ClassicBoardFactory.NumberOfSpaces)
                banker.Pay(player, ClassicGameConstants.GoSalaryBonus);
        }
    }
}
