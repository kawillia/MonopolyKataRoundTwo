using System.Collections.Generic;
using MonopolyKata.Classic.Rules;
using MonopolyKata.Core;

namespace MonopolyKata.Classic
{
    public class ClassicGameFactory
    {
        public static Game Create(IEnumerable<Player> players)
        {
            var dice = new Dice();
            var boardComponents = ClassicBoardFactory.GetComponents(dice);
            var movementHandler = new MovementHandler(boardComponents, new[] { new ClassicPassGoBonusRule() });
            var turnTaker = new ClassicTurnTaker(dice, movementHandler);

            return new Game(players, turnTaker, new GuidShuffler<Player>());
        }
    }
}
