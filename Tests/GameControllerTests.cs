﻿using System;
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
            var turnsBegan = 0;
            var turnsTaken = 0;
            var turnsEnded = 0;

            mockTurn.Setup(m => m.Begin(It.IsAny<String>())).Callback(() => turnsBegan++);
            mockTurn.Setup(m => m.Take(It.IsAny<String>())).Callback(() => turnsTaken++);
            mockTurn.Setup(m => m.End(It.IsAny<String>())).Callback(() => turnsEnded++);
            controller.Play();

            Assert.AreEqual(GameController.NumberOfRoundsToPlay, turnsBegan / 2);
            Assert.AreEqual(GameController.NumberOfRoundsToPlay, turnsTaken / 2);
            Assert.AreEqual(GameController.NumberOfRoundsToPlay, turnsEnded / 2);
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
