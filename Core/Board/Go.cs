using System;

namespace MonopolyKata.Core.Board
{
    public class Go : Space
    {
        public Int32 GoSalaryBonus { get; private set; }

        public Go(Int32 goSalaryBonus)
            : base()
        {
            GoSalaryBonus = goSalaryBonus;
        }

        public override void LandOn(Player player)
        {
            player.Receive(GoSalaryBonus);
        }
    }
}
