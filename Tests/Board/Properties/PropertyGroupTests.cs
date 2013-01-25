using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Classic.Rules;
using MonopolyKata.Core;
using MonopolyKata.Core.Board.Properties;
using MonopolyKata.Core.Rules;

namespace MonopolyKata.Tests.Board.Properties
{
    [TestClass]
    public class PropertyGroupTests
    {
        private Player hat;
        private Player horse;
        private Property mediterraneanAvenue;
        private Property balticAvenue;
        private PropertyGroup purpleGroup;
        private Banker banker;

        public PropertyGroupTests()
        {
            hat = new Player("Hat");
            horse = new Player("Horse");
            banker = new Banker(new[] { hat, horse });
            mediterraneanAvenue = new Property(ClassicBoardFactory.MediterraneanAvenuePrice, ClassicBoardFactory.MediterraneanAvenueRent, banker);
            balticAvenue = new Property(ClassicBoardFactory.BalticAvenuePrice, ClassicBoardFactory.BalticAvenueRent, banker);
            balticAvenue.ChangeChargeRentRule(new ClassicPropertyRentRule());
            purpleGroup = new PropertyGroup(mediterraneanAvenue, balticAvenue);
        }

        [TestMethod]
        public void PlayerLandingOnUnownedPropertyBuysPropertyWhenStrategyAllows()
        {
            var balanceBeforePurchase = banker.GetBalance(horse);
            balticAvenue.LandOn(horse);

            Assert.AreEqual(horse, balticAvenue.Owner);
            Assert.AreEqual(balanceBeforePurchase - balticAvenue.Price, banker.GetBalance(horse));
        }

        [TestMethod]
        public void PlayerLandingOnOwnedPropertyPlayerPaysRent()
        {
            var horseBalanceBeforeRentPayment = banker.GetBalance(horse);
            var hatBalanceBeforeRentPayment = banker.GetBalance(hat);

            balticAvenue.Owner = hat;
            balticAvenue.LandOn(horse);

            Assert.AreEqual(hat, balticAvenue.Owner);
            Assert.AreEqual(horseBalanceBeforeRentPayment - balticAvenue.BaseRent, banker.GetBalance(horse));
            Assert.AreEqual(hatBalanceBeforeRentPayment + balticAvenue.BaseRent, banker.GetBalance(hat));
        }

        private class FakeRentRule : IChargeRentRule
        {
            public const Int32 RentAmount = 1000;

            public Int32 CalculateRent(Property propertyLandedOn, System.Collections.Generic.IEnumerable<Property> locationsInGroup)
            {
                return RentAmount;
            }
        }
    }
}
