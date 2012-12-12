using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Core;
using MonopolyKata.Tests.Fakes;

namespace MonopolyKata.Tests
{
    [TestClass]
    public class GameControllerTests
    {
        [TestMethod]
        public void PlayExecutesSpecifiedNumberOfRounds()
        {
            var players = new[] { new Player("Horse"), new Player("Car") };
            var turnTaker = new FakeTurnTaker();
            var game = new Game(players, turnTaker, new GuidShuffler<Player>());
            var controller = new GameController(game);

            controller.Play();

            Assert.AreEqual(GameController.NumberOfRoundsToPlay, turnTaker.Turns.Count() / players.Count());
        }

        [TestMethod]
        public void PlayExecutesSamePlayerOrderInEachRound()
        {
            var players = new[]
            {
                new Player("Horse"),
                new Player("Car"),
                new Player("Hat")
            };

            var turnTaker = new FakeTurnTaker();
            var game = new Game(players, turnTaker, new GuidShuffler<Player>());
            var controller = new GameController(game);

            controller.Play();
            
            var lastRoundTurns = Enumerable.Empty<Player>();
            var turnsTaken = turnTaker.Turns;

            while (turnsTaken.Any())
            {
                var roundTurns = turnsTaken.Take(players.Count());

                if (lastRoundTurns.Any())
                {
                    for (var i = 0; i < lastRoundTurns.Count(); i++)
                        Assert.AreEqual(roundTurns.ElementAt(i), lastRoundTurns.ElementAt(i));
                }

                lastRoundTurns = roundTurns;
                turnsTaken.RemoveRange(0, players.Count());
            }
        }
    }
}
