using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Classic.Rules;
using MonopolyKata.Core;
using MonopolyKata.Core.Board.Properties;
using MonopolyKata.Tests.Fakes;

namespace MonopolyKata.Tests.Rules
{
    [TestClass]
    public class ClassicUtilityRentRuleTests
    {
        private ClassicUtilityRentRule strategy;
        private IEnumerable<Property> properties;
        private Player hat;
        private FakeDice fakeDice;
        private Property electricCompany;
        private Property waterWorks;

        public ClassicUtilityRentRuleTests()
        {
            fakeDice = new FakeDice();
            strategy = new ClassicUtilityRentRule(fakeDice);
            hat = new Player("Hat", 1000);
            electricCompany = new Property(ClassicBoardFactory.ElectricCompanyLocation, ClassicBoardFactory.UtilityPrice, 0);
            waterWorks = new Property(ClassicBoardFactory.ElectricCompanyLocation, ClassicBoardFactory.UtilityPrice, 0);

            properties = new[] { electricCompany, waterWorks };
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

            var rent = strategy.CalculateRent(electricCompany, properties);

            Assert.AreEqual(4 * fakeDice.CurrentValue, rent);
        }

        [TestMethod]
        public void RentForTwoOwnedUtilitiesIsTenTimesCurrentDiceValue()
        {
            electricCompany.Owner = hat;
            waterWorks.Owner = hat;

            var rent = strategy.CalculateRent(electricCompany, properties);

            Assert.AreEqual(10 * fakeDice.CurrentValue, rent);
        }
    }
}
