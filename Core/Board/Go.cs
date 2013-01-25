using System;

namespace MonopolyKata.Core.Board
{
    public class Go : Space
    {
        private Int32 goSalaryBonus;
        private Banker banker;

        public Go(Int32 goSalaryBonus, Banker banker)
            : base()
        {
            this.goSalaryBonus = goSalaryBonus;
            this.banker = banker;
        }

        public override void LandOn(String player)
        {
            banker.Pay(player, goSalaryBonus);
        }
    }
}
