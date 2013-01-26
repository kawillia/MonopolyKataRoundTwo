using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Classic.Rules;
using MonopolyKata.Core;
using MonopolyKata.Core.Spaces;
using System;
using System.Collections.Generic;

namespace MonopolyKata.Tests.Spaces
{
    [TestClass]
    public class PropertyTests
    {
        private String hat;
        private String horse;
        private Property mediterraneanAvenue;
        private Property balticAvenue;
        private Banker banker;

        public PropertyTests()
        {
            hat = "Hat";
            horse = "Horse";
            banker = new Banker(new[] { hat, horse });
            banker.Pay(hat, 2000);
            banker.Pay(horse, 2000);

            var purpleGroup = new List<Property>();
            mediterraneanAvenue = new Property(ClassicBoardFactory.MediterraneanAvenuePrice, ClassicBoardFactory.MediterraneanAvenueRent, banker, purpleGroup);
            balticAvenue = new Property(ClassicBoardFactory.BalticAvenuePrice, ClassicBoardFactory.BalticAvenueRent, banker, purpleGroup);

            purpleGroup.Add(mediterraneanAvenue);
            purpleGroup.Add(balticAvenue);
        }

        [TestMethod]
        public void PlayerLandingOnUnownedPropertyBuysProperty()
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

        [TestMethod]
        public void RentForPropertyWhenNoneAreOwnedIsBaseRent()
        {
            var rent = mediterraneanAvenue.CalculateRent();
            Assert.AreEqual(mediterraneanAvenue.BaseRent, rent);
        }

        [TestMethod]
        public void RentForPropertyWhenNotAllAreOwnedBySamePlayerIsBaseRent()
        {
            mediterraneanAvenue.Owner = hat;

            var rent = mediterraneanAvenue.CalculateRent();
            Assert.AreEqual(mediterraneanAvenue.BaseRent, rent);
        }

        [TestMethod]
        public void RentForPropertyDoublesWhenAllAreOwnedBySamePlayer()
        {
            mediterraneanAvenue.Owner = hat;
            balticAvenue.Owner = hat;

            var rent = mediterraneanAvenue.CalculateRent();
            Assert.AreEqual(2 * mediterraneanAvenue.BaseRent, rent);
        }

        [TestMethod]
        public void PlayerDoesNotBuyUnownedPropertyWhenBalanceIsLessThanPrice()
        {
            var currentBalance = banker.GetBalance(horse);
            banker.Charge(horse, currentBalance);
            balticAvenue.LandOn(horse);

            Assert.IsFalse(balticAvenue.IsOwned);
            Assert.AreEqual(0, banker.GetBalance(horse));
        }
    }
}
