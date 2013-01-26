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

            var railroadGroup = new List<Property>();
            readingRailroad = new Railroad(ClassicBoardFactory.RailroadPrice, ClassicBoardFactory.BaseRailroadRent, banker, railroadGroup);
            pennsylvaniaRailroad = new Railroad(ClassicBoardFactory.RailroadPrice, ClassicBoardFactory.BaseRailroadRent, banker, railroadGroup);
            boRailroad = new Railroad(ClassicBoardFactory.RailroadPrice, ClassicBoardFactory.BaseRailroadRent, banker, railroadGroup);
            shortLine = new Railroad(ClassicBoardFactory.RailroadPrice, ClassicBoardFactory.BaseRailroadRent, banker, railroadGroup);

            railroadGroup.Add(readingRailroad);
            railroadGroup.Add(pennsylvaniaRailroad);
            railroadGroup.Add(boRailroad);
            railroadGroup.Add(shortLine);
        }

        [TestMethod]
        public void RentForOneOwnedRailroadIsTwentyFiveDollars()
        {
            readingRailroad.Owner = hat;

            var rent = readingRailroad.CalculateRent();

            Assert.AreEqual(25, rent);
        }

        [TestMethod]
        public void RentForTwoOwnedRailroadsBySameOwnerPlayerFiftyDollars()
        {
            readingRailroad.Owner = hat;
            pennsylvaniaRailroad.Owner = hat;

            var rent = readingRailroad.CalculateRent();

            Assert.AreEqual(50, rent);
        }

        [TestMethod]
        public void RentForThreeOwnedRailroadsBySameOwnerPlayerIsOneHundredDollars()
        {
            readingRailroad.Owner = hat;
            pennsylvaniaRailroad.Owner = hat;
            boRailroad.Owner = hat;

            var rent = readingRailroad.CalculateRent();

            Assert.AreEqual(100, rent);
        }

        [TestMethod]
        public void RentForFourOwnedRailroadsBySameOwnerPlayerIsTwoHundredDollars()
        {
            readingRailroad.Owner = hat;
            pennsylvaniaRailroad.Owner = hat;
            boRailroad.Owner = hat;
            shortLine.Owner = hat;

            var rent = readingRailroad.CalculateRent();

            Assert.AreEqual(200, rent);
        }
    }
}
