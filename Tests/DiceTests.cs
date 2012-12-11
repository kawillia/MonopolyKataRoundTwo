using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Core;

namespace MonopolyKata.Tests
{
    [TestClass]
    public class DiceTests
    {
        private Dice dice;

        [TestInitialize]
        public void Initialize()
        {
            dice = new Dice();
        }

        [TestMethod]
        public void RollReturnsValueWithinValidRange()
        {
            for (var i = 0; i < 100; i++)
            {
                var diceValue = dice.Roll();

                Assert.IsTrue(diceValue >= 2 && diceValue <= 12);
            }
        }

        [TestMethod]
        public void AllPossibleValuesAreRolled()
        {
            var rolledValues = new List<Int32>();

            for (var i = 0; i < 100; i++)
                rolledValues.Add(dice.Roll());

            Assert.AreEqual(11, rolledValues.Distinct().Count());
        }
    }
}
