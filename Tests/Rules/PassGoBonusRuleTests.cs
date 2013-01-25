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
        private Banker banker;

        public PassGoBonusRuleTests()
        {            
            horse = new Player("Horse");
            banker = new Banker(new[] { horse });
            rule = new ClassicPassGoBonusRule(banker);
        }

        [TestMethod]
        public void BonusIsZeroWhenGoIsNotPassed()
        {
            var balanceBefore = banker.GetBalance(horse);
            rule.Apply(horse, 1);
            Assert.AreEqual(balanceBefore, banker.GetBalance(horse));
        }

        [TestMethod]
        public void BonusIsTwoHundredWhenGoIsPassed()
        {
            var balanceBefore = banker.GetBalance(horse);
            horse.MoveTo(38);
            rule.Apply(horse, 3);
            Assert.AreEqual(200, banker.GetBalance(horse));
        }

        [TestMethod]
        public void BonusIsTwoHundredWhenGoIsLandedOn()
        {
            var balanceBefore = banker.GetBalance(horse);
            horse.MoveTo(38);
            rule.Apply(horse, 2);
            Assert.AreEqual(200, banker.GetBalance(horse));
        }
    }
}
