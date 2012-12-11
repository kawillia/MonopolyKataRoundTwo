using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Classic.Strategies;

namespace MonopolyKata.Tests.Strategies
{
    [TestClass]
    public class PassGoBonusStrategyTests
    {
        private PassGoBonusStrategy strategy;

        public PassGoBonusStrategyTests()
        {
            strategy = new PassGoBonusStrategy();
        }

        [TestMethod]
        public void BonusIsZeroWhenGoIsNotPassed()
        {
            Assert.AreEqual(0, strategy.GetBonus(0, 1));
        }

        [TestMethod]
        public void BonusIsTwoHundredWhenGoIsPassed()
        {
            Assert.AreEqual(200, strategy.GetBonus(38, 2));
        }

        [TestMethod]
        public void BonusIsTwoHundredWhenGoIsLandedOn()
        {
            Assert.AreEqual(200, strategy.GetBonus(39, 1));
        }
    }
}
