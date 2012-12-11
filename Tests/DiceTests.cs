using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Core;

namespace MonopolyTests
{
    [TestClass]
    public class DiceTests
    {
        private Dice dice;
        private const Int32 NumberOfPossibleRolledValues = 11;

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
        public void UpperAndLowerDieValuesAreRolled()
        {
            var rolledValues = new List<Int32>();

            for (Int32 i = 0; i < 100; i++)
                rolledValues.Add(dice.Roll());

            Assert.AreEqual(NumberOfPossibleRolledValues, rolledValues.Distinct().Count());
        }
    }
}
