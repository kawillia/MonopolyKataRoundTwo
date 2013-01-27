using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Core;
using MonopolyKata.Core.Spaces;
using MonopolyKata.Core.Rules;
using System;
using Moq;

namespace MonopolyKata.Tests
{
    [TestClass]
    public class ClassicTurnTests
    {
        private Mock<Dice> mockDice;
        private Queue<Int32> dieValues;
        private String horse;
        private Mock<IBoard> mockBoard;
        private ClassicTurn turn;
        private IEnumerable<Property> properties;
        private Banker banker;

        [TestInitialize]
        public void Initialize()
        {
            mockDice = new Mock<Dice>();
            mockDice.Setup(m => m.RollDie()).Returns(() => dieValues.Dequeue());
            horse = "Horse";
            banker = new Banker(new[] { horse });

            var propertyManager = new PropertyManager();
            properties = ClassicBoardFactory.CreateProperties(banker, propertyManager);
            propertyManager.ManageProperties(properties);

            mockBoard = new Mock<IBoard>();
            turn = new ClassicTurn(mockDice.Object, mockBoard.Object, banker, propertyManager);
        }

        [TestMethod]
        public void PlayerDoesNotRollDoublesMovesRollValues()
        {
            dieValues = new Queue<Int32>(new[] { 3, 1 });
            turn.Take(horse);

            mockBoard.Verify(b => b.MovePlayer(horse, 4), Times.Once());
        }

        [TestMethod]
        public void RollsDoublesOnceMoveTwice()
        {
            dieValues = new Queue<Int32>(new[] { 3, 3, 1, 3 });
            turn.Take(horse);

            mockBoard.Verify(b => b.MovePlayer(horse, 6), Times.Once());
            mockBoard.Verify(b => b.MovePlayer(horse, 4), Times.Once());
        }

        [TestMethod]
        public void RollDoublesTwiceMovesThreeRollsTotal()
        {
            dieValues = new Queue<Int32>(new[] { 1, 1, 2, 2, 1, 5 });
            turn.Take(horse);

            mockBoard.Verify(b => b.MovePlayer(horse, 2), Times.Once());
            mockBoard.Verify(b => b.MovePlayer(horse, 4), Times.Once());
            mockBoard.Verify(b => b.MovePlayer(horse, 6), Times.Once());
        }

        [TestMethod]
        public void RollDoublesThreeTimesEndOnJustVisiting()
        {
            dieValues = new Queue<Int32>(new[] { 1, 1, 2, 2, 3, 3 });
            turn.Take(horse);

            mockBoard.Verify(b => b.MovePlayer(horse, 2), Times.Once());
            mockBoard.Verify(b => b.MovePlayer(horse, 4), Times.Once());
            mockBoard.Verify(b => b.TeleportPlayer(horse, ClassicBoardFactory.JustVisitingLocation), Times.Once());
        }

        [TestMethod]
        public void PlayerMortgagesPropertiesAtBeginningOfTurnWhenBalanceIsLessThanTwoHundred()
        {
            var propertiesToMortgage = properties.Take(3);

            foreach (var property in propertiesToMortgage)
                property.Sell(horse);

            var balanceBeforeTurn = banker.GetBalance(horse);
            turn.Begin(horse);

            Assert.IsTrue(propertiesToMortgage.All(p => p.IsMortgaged));
            Assert.AreEqual(balanceBeforeTurn + propertiesToMortgage.Sum(p => p.Price * 9 / 10), banker.GetBalance(horse));
        }

        [TestMethod]
        public void PlayerUnmortgagesPropertiesAtBeginningOfTurnWhenBalanceIsMoreThanTwoHundred()
        {
            banker.Pay(horse, 2000);            

            var property = properties.ElementAt(0);
            property.Sell(horse);
            property.Mortgage();

            var balanceBeforeTurn = banker.GetBalance(horse);
            turn.Begin(horse);

            Assert.IsFalse(property.IsMortgaged);
            Assert.AreEqual(balanceBeforeTurn - property.Price, banker.GetBalance(horse));
        }

        [TestMethod]
        public void PlayerMortgagesPropertiesAtEndOfTurnWhenBalanceIsLessThanTwoHundred()
        {
            var propertiesToMortgage = properties.Take(3);

            foreach (var property in propertiesToMortgage)
                property.Sell(horse);

            var balanceBeforeTurn = banker.GetBalance(horse);
            turn.End(horse);

            Assert.IsTrue(propertiesToMortgage.All(p => p.IsMortgaged));
            Assert.AreEqual(balanceBeforeTurn + propertiesToMortgage.Sum(p => p.Price * 9 / 10), banker.GetBalance(horse));
        }

        [TestMethod]
        public void PlayerUnmortgagesPropertiesAtEndOfTurnWhenBalanceIsMoreThanTwoHundred()
        {
            banker.Pay(horse, 2000);

            var property = properties.ElementAt(0);
            property.Sell(horse);
            property.Mortgage();

            var balanceBeforeTurn = banker.GetBalance(horse);
            turn.End(horse);

            Assert.IsFalse(property.IsMortgaged);
            Assert.AreEqual(balanceBeforeTurn - property.Price, banker.GetBalance(horse));
        }

        [TestMethod]
        public void NoPropertiesAreMortgagedAtBeginningOfTurnWhenPlayerOwnsNothing()
        {
            var propertiesToCheck = properties.Take(3);
            var balanceBeforeTurn = banker.GetBalance(horse);
            turn.Begin(horse);

            Assert.IsFalse(propertiesToCheck.Any(p => p.IsMortgaged));
            Assert.AreEqual(balanceBeforeTurn, banker.GetBalance(horse));
        }

        [TestMethod]
        public void NoPropertiesAreMortgagedAtEndOfTurnWhenPlayerOwnsNothing()
        {
            var propertiesToCheck = properties.Take(3);
            var balanceBeforeTurn = banker.GetBalance(horse);
            turn.End(horse);

            Assert.IsFalse(propertiesToCheck.Any(p => p.IsMortgaged));
            Assert.AreEqual(balanceBeforeTurn, banker.GetBalance(horse));
        }
    }
}
