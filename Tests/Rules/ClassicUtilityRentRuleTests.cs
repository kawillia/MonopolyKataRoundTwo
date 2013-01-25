using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Classic.Rules;
using MonopolyKata.Core;
using MonopolyKata.Core.Spaces;
using MonopolyKata.Tests.Fakes;
using System;

namespace MonopolyKata.Tests.Rules
{
    [TestClass]
    public class ClassicUtilityRentRuleTests
    {
        private ClassicUtilityRentRule rule;
        private String hat;
        private FakeDice fakeDice;
        private Property electricCompany;
        private Property waterWorks;

        public ClassicUtilityRentRuleTests()
        {
            fakeDice = new FakeDice();            
            hat = "Hat";

            var banker = new Banker(new[] { hat });
            electricCompany = new Property(ClassicBoardFactory.UtilityPrice, 0, banker);
            waterWorks = new Property(ClassicBoardFactory.UtilityPrice, 0, banker);
            rule = new ClassicUtilityRentRule(fakeDice, new[] { electricCompany, waterWorks });
        }

        [TestInitialize]
        public void TestInitialize()
        {
            fakeDice.SetDieValues(1, 5);
            fakeDice.Roll();
        }

        [TestMethod]
        public void RentForOneOwnedUtilityIsFourTimesCurrentDiceValue()
        {
            electricCompany.Owner = hat;

            var rent = rule.Calculate(electricCompany);

            Assert.AreEqual(4 * fakeDice.CurrentValue, rent);
        }

        [TestMethod]
        public void RentForTwoOwnedUtilitiesIsTenTimesCurrentDiceValue()
        {
            electricCompany.Owner = hat;
            waterWorks.Owner = hat;

            var rent = rule.Calculate(electricCompany);

            Assert.AreEqual(10 * fakeDice.CurrentValue, rent);
        }
    }
}
