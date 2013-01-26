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
            var propertyManager = new PropertyManager();
            var properties = ClassicBoardFactory.CreateProperties(banker, propertyManager);
            propertyManager.ManageProperties(properties);

            var board = ClassicBoardFactory.CreateBoard(dice, new[] { new ClassicGoBonusRule(banker) }, properties, banker, players);
            var turnTaker = new ClassicTurn(dice, board, banker, propertyManager);

            return new Game(players, turnTaker, new GuidShuffler<String>());
        }
    }
}
