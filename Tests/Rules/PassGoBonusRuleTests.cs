using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Classic.Rules;

namespace MonopolyKata.Tests.Rules
{
    [TestClass]
    public class PassGoBonusRuleTests
    {
        private ClassicPassGoBonusRule rule;

        public PassGoBonusRuleTests()
        {
            rule = new ClassicPassGoBonusRule();
        }

        [TestMethod]
        public void BonusIsZeroWhenGoIsNotPassed()
        {
            Assert.AreEqual(0, rule.GetBonus(0, 1));
        }

        [TestMethod]
        public void BonusIsTwoHundredWhenGoIsPassed()
        {
            Assert.AreEqual(200, rule.GetBonus(38, 2));
        }

        [TestMethod]
        public void BonusIsTwoHundredWhenGoIsLandedOn()
        {
            Assert.AreEqual(200, rule.GetBonus(39, 1));
        }
    }
}
