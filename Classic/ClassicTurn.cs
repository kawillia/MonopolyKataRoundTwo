using MonopolyKata.Core;
using MonopolyKata.Core.Spaces;
using System;

namespace MonopolyKata.Classic
{
    public class ClassicTurn : ITurn
    {
        private Dice dice;
        private Board board;

        public ClassicTurn(Dice dice, Board board)
        {
            this.dice = dice;
            this.board = board;
        }

        public void Take(String player)
        {
            var numberOfRolls = 0;

            do
            {
                dice.Roll();

                if (dice.IsDoubles && ++numberOfRolls == 3)
                {
                    board.TeleportPlayer(player, 10);
                    return;
                }
                else
                {
                    board.MovePlayer(player, dice.CurrentValue);
                }
            }
            while (dice.IsDoubles);
        }
    }
}
