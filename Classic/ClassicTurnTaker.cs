using MonopolyKata.Core;
using MonopolyKata.Core.Board;
using System;

namespace MonopolyKata.Classic
{
    public class ClassicTurnTaker : ITurnTaker
    {
        private Dice dice;
        private GameBoard movementHandler;

        public ClassicTurnTaker(Dice dice, GameBoard board)
        {
            this.dice = dice;
            this.movementHandler = board;
        }

        public void Take(String player)
        {
            do
            {
                dice.Roll();

                if (dice.NumberOfConsecutiveDoubles == 3)
                    movementHandler.MovePlayerDirectlyToLocation(player, 10);
                else
                    movementHandler.MovePlayerSpaceBySpace(player, dice.CurrentValue);
            }
            while (dice.IsDoubles && dice.NumberOfConsecutiveDoubles < 3);
        }
    }
}
