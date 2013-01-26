using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Core.Spaces;
using MonopolyKata.Core;
using MonopolyKata.Classic;
using System.Collections.Generic;
using Moq;

namespace MonopolyKata.Tests.Spaces
{
    [TestClass]
    public class UtilityTests
    {
        private const Int32 DiceValue = 12;

        private String hat;
        private Dice dice;
        private Utility electricCompany;
        private Utility waterWorks;

        public UtilityTests()
        {
            dice = new Dice();
            hat = "Hat";

            var banker = new Banker(new[] { hat });
            var propertyManager = new PropertyManager();
            electricCompany = new Utility(ClassicBoardFactory.UtilityPrice, ClassicBoardFactory.UtilityGroup, banker, propertyManager, dice);
            waterWorks = new Utility(ClassicBoardFactory.UtilityPrice, ClassicBoardFactory.UtilityGroup, banker, propertyManager, dice);

            propertyManager.ManageProperties(new[] { electricCompany, waterWorks });
        }

        [TestInitialize]
        public void TestInitialize()
        {
            dice.Roll();
        }

        [TestMethod]
        public void RentForOneOwnedUtilityIsFourTimesCurrentDiceValue()
        {
            electricCompany.Sell(hat);

            var rent = electricCompany.CalculateRent();

            Assert.AreEqual(4 * dice.CurrentValue, rent);
        }

        [TestMethod]
        public void RentForTwoOwnedUtilitiesIsTenTimesCurrentDiceValue()
        {
            electricCompany.Sell(hat);
            waterWorks.Sell(hat);

            var rent = electricCompany.CalculateRent();

            Assert.AreEqual(10 * dice.CurrentValue, rent);
        }
    }
}
