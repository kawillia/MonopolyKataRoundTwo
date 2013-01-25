using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Classic.Rules;
using MonopolyKata.Core;
using MonopolyKata.Core.Board;
using MonopolyKata.Tests.Fakes;

namespace MonopolyKata.Tests.Rules
{
    [TestClass]
    public class ClassicUtilityRentRuleTests
    {
        private ClassicUtilityRentRule strategy;
        private Player hat;
        private FakeDice fakeDice;
        private Property electricCompany;
        private Property waterWorks;

        public ClassicUtilityRentRuleTests()
        {
            fakeDice = new FakeDice();            
            hat = new Player("Hat");

            var banker = new Banker(new[] { hat });
            electricCompany = new Property(ClassicBoardFactory.UtilityPrice, 0, banker);
            waterWorks = new Property(ClassicBoardFactory.UtilityPrice, 0, banker);
            strategy = new ClassicUtilityRentRule(fakeDice, new[] { electricCompany, waterWorks });
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

            var rent = strategy.CalculateRent(electricCompany);

            Assert.AreEqual(4 * fakeDice.CurrentValue, rent);
        }

        [TestMethod]
        public void RentForTwoOwnedUtilitiesIsTenTimesCurrentDiceValue()
        {
            electricCompany.Owner = hat;
            waterWorks.Owner = hat;

            var rent = strategy.CalculateRent(electricCompany);

            Assert.AreEqual(10 * fakeDice.CurrentValue, rent);
        }
    }
}
