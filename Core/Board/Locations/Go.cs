using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonopolyKata;
using MonopolyKata.Core;

namespace MonopolyKata.Core.Board.Locations
{
    public class Go : Location
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
