using System;

namespace MonopolyKata.Core.Board
{
    public class Go : Space
    {
        public Int32 GoSalaryBonus { get; private set; }

        public Go(Int32 locationIndex, Int32 goSalaryBonus)
            : base(locationIndex)
        {
            GoSalaryBonus = goSalaryBonus;
        }

        public override void LandOn(Player player)
        {
            player.Receive(GoSalaryBonus);
        }
    }
}
