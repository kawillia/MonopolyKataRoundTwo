using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly;

namespace Monopoly.Board.Locations
{
    public class Go : Location
    {
        public Int32 GoSalaryBonus { get; private set; }

        public Go(Int32 locationIndex, Int32 goSalaryBonus)
            : base(locationIndex)
        {
            GoSalaryBonus = goSalaryBonus;
        }

        public override void LandedOnByPlayer(Player player)
        {
            ReceiveGoSalaryBonus(player);
        }

        public override void PassedByPlayer(Player player)
        {
            ReceiveGoSalaryBonus(player);
        }

        private void ReceiveGoSalaryBonus(Player player)
        {
            player.Receive(GoSalaryBonus);
        }
    }
}
