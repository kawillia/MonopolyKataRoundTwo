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
    public class RailroadTests
    {
        private String hat;
        private String horse;
        private Railroad readingRailroad;
        private Railroad pennsylvaniaRailroad;
        private Railroad boRailroad;
        private Railroad shortLine;
        private Banker banker;

        public RailroadTests()
        {
            hat = "Hat";
            horse = "Horse";
            banker = new Banker(new[] { hat, horse });

            var propertyManager = new PropertyManager();
            readingRailroad = new Railroad(ClassicBoardFactory.RailroadPrice, ClassicBoardFactory.BaseRailroadRent, ClassicBoardFactory.RailroadGroup, banker, propertyManager);
            pennsylvaniaRailroad = new Railroad(ClassicBoardFactory.RailroadPrice, ClassicBoardFactory.BaseRailroadRent, ClassicBoardFactory.RailroadGroup, banker, propertyManager);
            boRailroad = new Railroad(ClassicBoardFactory.RailroadPrice, ClassicBoardFactory.BaseRailroadRent, ClassicBoardFactory.RailroadGroup, banker, propertyManager);
            shortLine = new Railroad(ClassicBoardFactory.RailroadPrice, ClassicBoardFactory.BaseRailroadRent, ClassicBoardFactory.RailroadGroup, banker, propertyManager);

            propertyManager.ManageProperties(new[] { readingRailroad, pennsylvaniaRailroad, boRailroad, shortLine });
        }

        [TestMethod]
        public void RentForOneOwnedRailroadIsTwentyFiveDollars()
        {
            readingRailroad.Sell(hat);

            var rent = readingRailroad.CalculateRent();

            Assert.AreEqual(25, rent);
        }

        [TestMethod]
        public void RentForTwoOwnedRailroadsBySameOwnerPlayerFiftyDollars()
        {
            readingRailroad.Sell(hat);
            pennsylvaniaRailroad.Sell(hat);

            var rent = readingRailroad.CalculateRent();

            Assert.AreEqual(50, rent);
        }

        [TestMethod]
        public void RentForThreeOwnedRailroadsBySameOwnerPlayerIsOneHundredDollars()
        {
            readingRailroad.Sell(hat);
            pennsylvaniaRailroad.Sell(hat);
            boRailroad.Sell(hat);

            var rent = readingRailroad.CalculateRent();

            Assert.AreEqual(100, rent);
        }

        [TestMethod]
        public void RentForFourOwnedRailroadsBySameOwnerPlayerIsTwoHundredDollars()
        {
            readingRailroad.Sell(hat);
            pennsylvaniaRailroad.Sell(hat);
            boRailroad.Sell(hat);
            shortLine.Sell(hat);

            var rent = readingRailroad.CalculateRent();

            Assert.AreEqual(200, rent);
        }
    }
}
