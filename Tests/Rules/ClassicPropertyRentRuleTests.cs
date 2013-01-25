using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Classic.Rules;
using MonopolyKata.Core;
using MonopolyKata.Core.Board.Properties;

namespace MonopolyKata.Tests.Rules
{
    [TestClass]
    public class ClassicPropertyRentRuleTests
    {
        private ClassicPropertyRentRule strategy;
        private IEnumerable<Property> properties;
        private Player hat;
        private Property mediterraneanAvenue;
        private Property balticAvenue;
        private Banker banker;

        public ClassicPropertyRentRuleTests()
        {
            strategy = new ClassicPropertyRentRule();
            hat = new Player("Hat");
            banker = new Banker(new[] { hat });
            mediterraneanAvenue = new Property(ClassicBoardFactory.MediterraneanAvenuePrice, ClassicBoardFactory.MediterraneanAvenueRent, banker);
            balticAvenue = new Property(ClassicBoardFactory.BalticAvenuePrice, ClassicBoardFactory.BalticAvenueRent, banker);
            properties = new[] { mediterraneanAvenue, balticAvenue };
        }

        [TestMethod]
        public void RentForPropertyWhenNotAllAreOwnedBySamePlayerIsBaseRent()
        {
            var rent = strategy.CalculateRent(mediterraneanAvenue, properties);
            Assert.AreEqual(mediterraneanAvenue.BaseRent, rent);
        }

        [TestMethod]
        public void PlayerLandingOnOwnedPropertyGroupBySameOwnerPlayerPaysStatedRentTimesTwo()
        {
            mediterraneanAvenue.Owner = hat;
            balticAvenue.Owner = hat;

            var rent = strategy.CalculateRent(mediterraneanAvenue, properties);
            Assert.AreEqual(2 * mediterraneanAvenue.BaseRent, rent);
        }
    }
}
