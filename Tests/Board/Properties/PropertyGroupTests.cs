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

        public PropertyGroupTests()
        {
            hat = new Player("Hat", 1500);
            horse = new Player("Horse", 1500);
            mediterraneanAvenue = new Property(ClassicBoardFactory.MediterraneanAvenueLocation, ClassicBoardFactory.MediterraneanAvenuePrice, ClassicBoardFactory.MediterraneanAvenueRent);
            balticAvenue = new Property(ClassicBoardFactory.BalticAvenueLocation, ClassicBoardFactory.BalticAvenuePrice, ClassicBoardFactory.BalticAvenueRent);
            purpleGroup = new PropertyGroup(new FakeRentRule(), mediterraneanAvenue, balticAvenue);
        }

        [TestMethod]
        public void PlayerLandingOnUnownedPropertyBuysPropertyWhenStrategyAllows()
        {
            var balanceBeforePurchase = horse.Balance;

            horse.MoveTo(ClassicBoardFactory.BalticAvenueLocation);
            purpleGroup.LandOn(horse);

            Assert.AreEqual(horse, balticAvenue.Owner);
            Assert.AreEqual(balanceBeforePurchase - balticAvenue.Price, horse.Balance);
        }

        [TestMethod]
        public void PlayerLandingOnOwnedPropertyPlayerPaysRent()
        {
            var horseBalanceBeforeRentPayment = horse.Balance;
            var hatBalanceBeforeRentPayment = hat.Balance;

            balticAvenue.Owner = hat;
            horse.MoveTo(ClassicBoardFactory.BalticAvenueLocation);
            purpleGroup.LandOn(horse);

            Assert.AreEqual(hat, balticAvenue.Owner);
            Assert.AreEqual(horseBalanceBeforeRentPayment - FakeRentRule.RentAmount, horse.Balance);
            Assert.AreEqual(hatBalanceBeforeRentPayment + FakeRentRule.RentAmount, hat.Balance);
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
