using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Classic.Rules;
using MonopolyKata.Core;
using MonopolyKata.Core.Board;

namespace MonopolyKata.Tests.Rules
{
    [TestClass]
    public class ClassicPropertyRentRuleTests
    {
        private ClassicPropertyRentRule strategy;
        private Player hat;
        private Property mediterraneanAvenue;
        private Property balticAvenue;
        private Banker banker;

        public ClassicPropertyRentRuleTests()
        {
            
            hat = new Player("Hat");
            banker = new Banker(new[] { hat });
            mediterraneanAvenue = new Property(ClassicBoardFactory.MediterraneanAvenuePrice, ClassicBoardFactory.MediterraneanAvenueRent, banker);
            balticAvenue = new Property(ClassicBoardFactory.BalticAvenuePrice, ClassicBoardFactory.BalticAvenueRent, banker);
            strategy = new ClassicPropertyRentRule(new[] { mediterraneanAvenue, balticAvenue });
        }

        [TestMethod]
        public void RentForPropertyWhenNotAllAreOwnedBySamePlayerIsBaseRent()
        {
            var rent = strategy.CalculateRent(mediterraneanAvenue);
            Assert.AreEqual(mediterraneanAvenue.BaseRent, rent);
        }

        [TestMethod]
        public void PlayerLandingOnOwnedPropertyGroupBySameOwnerPlayerPaysStatedRentTimesTwo()
        {
            mediterraneanAvenue.Owner = hat;
            balticAvenue.Owner = hat;

            var rent = strategy.CalculateRent(mediterraneanAvenue);
            Assert.AreEqual(2 * mediterraneanAvenue.BaseRent, rent);
        }
    }
}
