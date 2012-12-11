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
        private Game game;

        public GameControllerTests()
        {
            game = ClassicGameFactory.Create();
        }

        [TestMethod]
        public void PlayExecutesSpecifiedNumberOfRounds()
        {
            game.AddPlayer(new Player("Horse"));
            game.AddPlayer(new Player("Car"));

            var controller = new GameController(game);
            controller.Play();

            Assert.AreEqual(GameController.NumberOfRoundsToPlay, game.Rounds.Count());
        }

        [TestMethod]
        public void PlayExecutesSamePlayerOrderInEachRound()
        {
            game.AddPlayer(new Player("Horse"));
            game.AddPlayer(new Player("Car"));
            game.AddPlayer(new Player("Hat"));

            var controller = new GameController(game);
            controller.Play();

            Round lastRound = null;

            foreach (var currentRound in game.Rounds)
            {
                if (lastRound != null)
                {
                    var currentRoundPlayerRolls = currentRound.Players;
                    var lastRoundPlayerRolls = lastRound.Players;
                    var lastRoundCount = lastRound.Players.Count();

                    for (var i = 0; i < lastRoundCount; i++)
                        Assert.AreEqual(currentRoundPlayerRolls.ElementAt(i), lastRoundPlayerRolls.ElementAt(i));
                }

                lastRound = currentRound;
            }
        }
    }
}
