using System.Collections.Generic;
using MonopolyKata.Classic.Rules;
using MonopolyKata.Core;
using MonopolyKata.Core.Spaces;
using System;

namespace MonopolyKata.Classic
{
    public class ClassicGameFactory
    {
        public static Game Create(IEnumerable<String> players)
        {
            var dice = new Dice();
            var banker = new Banker(players);
            var board = ClassicBoardFactory.CreateBoard(dice, new[] { new ClassicGoBonusRule(banker) }, banker, players);
            var turnTaker = new ClassicTurn(dice, board);

            return new Game(players, turnTaker, new GuidShuffler<String>());
        }
    }
}
