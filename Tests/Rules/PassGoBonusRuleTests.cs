using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Classic.Rules;
using MonopolyKata.Core;

namespace MonopolyKata.Tests.Rules
{
    [TestClass]
    public class PassGoBonusRuleTests
    {
        private Player horse;
        private ClassicPassGoBonusRule rule;

        public PassGoBonusRuleTests()
        {
            horse = new Player("Horse");
            rule = new ClassicPassGoBonusRule();
        }

        [TestMethod]
        public void BonusIsZeroWhenGoIsNotPassed()
        {
            var balanceBefore = horse.Balance;
            rule.Apply(horse, 1);
            Assert.AreEqual(balanceBefore, horse.Balance);
        }

        [TestMethod]
        public void BonusIsTwoHundredWhenGoIsPassed()
        {
            var balanceBefore = horse.Balance;
            horse.MoveTo(38);
            rule.Apply(horse, 3);
            Assert.AreEqual(200, horse.Balance);
        }

        [TestMethod]
        public void BonusIsTwoHundredWhenGoIsLandedOn()
        {
            var balanceBefore = horse.Balance;
            horse.MoveTo(38);
            rule.Apply(horse, 2);
            Assert.AreEqual(200, horse.Balance);
        }
    }
}
