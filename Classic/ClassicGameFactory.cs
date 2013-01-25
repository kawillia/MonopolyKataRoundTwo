using System.Collections.Generic;
using MonopolyKata.Classic.Rules;
using MonopolyKata.Core;
using MonopolyKata.Core.Board;

namespace MonopolyKata.Classic
{
    public class ClassicGameFactory
    {
        public static Game Create(IEnumerable<Player> players)
        {
            var dice = new Dice();
            var banker = new Banker(players);
            var spaces = ClassicBoardFactory.GetSpaces(dice, banker);
            var movementHandler = new GameBoard(spaces, new[] { new ClassicPassGoBonusRule(banker) });
            var turnTaker = new ClassicTurnTaker(dice, movementHandler);

            return new Game(players, turnTaker, new GuidShuffler<Player>());
        }
    }
}
