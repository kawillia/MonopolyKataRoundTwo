using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Core;

namespace MonopolyTests
{
    [TestClass]
    public class GameTests
    {
        private Game game;

        [TestInitialize]
        public void Initialize()
        {
            game = ClassicGameFactory.Create();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddingDuplicatePlayerThrowsException()
        {
            game.AddPlayer(new Player("Horse"));
            game.AddPlayer(new Player("Horse"));
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PlayingGameWithLessThanMinimumNumberOfPlayersThrowsException()
        {
            game.Start();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PlayingGameWithGreaterThanMaximumNumberOfPlayersThrowsException()
        {
            game.AddPlayer(new Player("Horse"));
            game.AddPlayer(new Player("Car"));
            game.AddPlayer(new Player("Iron"));
            game.AddPlayer(new Player("Ship"));
            game.AddPlayer(new Player("Thimble"));
            game.AddPlayer(new Player("Wheelbarrow"));
            game.AddPlayer(new Player("Cannon"));
            game.AddPlayer(new Player("Hat"));
            game.AddPlayer(new Player("Hokie"));
            game.Start();
        }

        [TestMethod]
        public void PlayingGameWithValidNumberOfPlayersDoesNotThrowException()
        {
            game.AddPlayer(new Player("Horse"));
            game.AddPlayer(new Player("Car"));
            game.AddPlayer(new Player("Iron"));
            game.AddPlayer(new Player("Ship"));
            game.AddPlayer(new Player("Thimble"));
            game.AddPlayer(new Player("Wheelbarrow"));
            game.AddPlayer(new Player("Cannon"));
            game.AddPlayer(new Player("Hat"));
            game.Start();
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

                    for (var i = 0; i < lastRound.NumberOfPlayers; i++)
                        Assert.AreEqual(currentRoundPlayerRolls.ElementAt(i), lastRoundPlayerRolls.ElementAt(i));
                }

                lastRound = currentRound;
            }
        }
    }
}
