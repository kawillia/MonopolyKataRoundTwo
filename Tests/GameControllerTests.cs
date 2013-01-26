using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Core;
using Moq;
using System.Collections.Generic;

namespace MonopolyKata.Tests
{
    [TestClass]
    public class GameControllerTests
    {
        [TestMethod]
        public void PlayExecutesSpecifiedNumberOfRounds()
        {
            var players = new[] { "Horse", "Car" };
            var mockTurn = new Mock<ITurn>();
            var game = new Game(players, mockTurn.Object, new GuidShuffler<String>());
            var controller = new GameController(game);
            var turnsBegan = new List<String>();
            var turnsTaken = new List<String>();
            var turnsEnded = new List<String>();

            mockTurn.Setup(m => m.Begin(It.IsAny<String>())).Callback((String p) => turnsBegan.Add(p));
            mockTurn.Setup(m => m.Take(It.IsAny<String>())).Callback((String p) => turnsTaken.Add(p));
            mockTurn.Setup(m => m.End(It.IsAny<String>())).Callback((String p) => turnsEnded.Add(p));
            controller.Play();

            Assert.AreEqual(GameController.NumberOfRoundsToPlay, turnsBegan.Count / players.Count());
            Assert.AreEqual(GameController.NumberOfRoundsToPlay, turnsTaken.Count / players.Count());
            Assert.AreEqual(GameController.NumberOfRoundsToPlay, turnsEnded.Count / players.Count());
        }

        [TestMethod]
        public void PlayExecutesSamePlayerOrderInEachRound()
        {
            var players = new[]
            {
                "Horse",
                "Car",
                "Hat"
            };

            var mockTurn = new Mock<ITurn>();
            var game = new Game(players, mockTurn.Object, new GuidShuffler<String>());
            var controller = new GameController(game);
            var turnsTaken = new List<String>();

            mockTurn.Setup(m => m.Take(It.IsAny<String>())).Callback((String p) => turnsTaken.Add(p));
            controller.Play();

            var lastRoundTurns = Enumerable.Empty<String>();

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
