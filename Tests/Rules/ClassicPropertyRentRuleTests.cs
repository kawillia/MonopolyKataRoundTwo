using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Classic.Rules;
using MonopolyKata.Core;
using MonopolyKata.Core.Spaces;
using System;

namespace MonopolyKata.Tests.Rules
{
    [TestClass]
    public class ClassicPropertyRentRuleTests
    {
        private ClassicPropertyRentRule rule;
        private String hat;
        private Property mediterraneanAvenue;
        private Property balticAvenue;
        private Banker banker;

        public ClassicPropertyRentRuleTests()
        {
            hat = "Hat";
            banker = new Banker(new[] { hat });
            mediterraneanAvenue = new Property(ClassicBoardFactory.MediterraneanAvenuePrice, ClassicBoardFactory.MediterraneanAvenueRent, banker);
            balticAvenue = new Property(ClassicBoardFactory.BalticAvenuePrice, ClassicBoardFactory.BalticAvenueRent, banker);
            rule = new ClassicPropertyRentRule(new[] { mediterraneanAvenue, balticAvenue });
        }

        [TestMethod]
        public void RentForPropertyWhenNoneAreOwnedIsBaseRent()
        {
            var rent = rule.Calculate(mediterraneanAvenue);
            Assert.AreEqual(mediterraneanAvenue.BaseRent, rent);
        }

        [TestMethod]
        public void RentForPropertyWhenNotAllAreOwnedBySamePlayerIsBaseRent()
        {
            mediterraneanAvenue.Owner = hat;

            var rent = rule.Calculate(mediterraneanAvenue);
            Assert.AreEqual(mediterraneanAvenue.BaseRent, rent);
        }

        [TestMethod]
        public void RentForPropertyDoublesWhenAllAreOwnedBySamePlayer()
        {
            mediterraneanAvenue.Owner = hat;
            balticAvenue.Owner = hat;

            var rent = rule.Calculate(mediterraneanAvenue);
            Assert.AreEqual(2 * mediterraneanAvenue.BaseRent, rent);
        }
    }
}
