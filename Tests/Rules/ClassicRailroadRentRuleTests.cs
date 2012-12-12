using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Classic.Rules;
using MonopolyKata.Core;
using MonopolyKata.Core.Board.Properties;

namespace MonopolyKata.Tests.Rules
{
    [TestClass]
    public class ClassicRailroadRentRuleTests
    {
        private ClassicRailroadRentRule strategy;
        private IEnumerable<Property> properties;
        private Player horse;
        private Player hat;
        private Property readingRailroad;
        private Property pennsylvaniaRailroad;
        private Property boRailroad;
        private Property shortLine;

        public ClassicRailroadRentRuleTests()
        {
            strategy = new ClassicRailroadRentRule();
            horse = new Player("Horse", 1500);
            hat = new Player("Hat", 1000);

            readingRailroad = new Property(ClassicBoardFactory.ReadingRailroadLocation, ClassicBoardFactory.RailroadPrice, ClassicBoardFactory.BaseRailroadRent);
            pennsylvaniaRailroad = new Property(ClassicBoardFactory.PennsylvaniaAvenueLocation, ClassicBoardFactory.RailroadPrice, ClassicBoardFactory.BaseRailroadRent);
            boRailroad = new Property(ClassicBoardFactory.BORailroadLocation, ClassicBoardFactory.RailroadPrice, ClassicBoardFactory.BaseRailroadRent);
            shortLine = new Property(ClassicBoardFactory.ShortLineLocation, ClassicBoardFactory.RailroadPrice, ClassicBoardFactory.BaseRailroadRent);
            properties = new[] { readingRailroad, pennsylvaniaRailroad, boRailroad, shortLine };
        }

        [TestMethod]
        public void RentForOneOwnedRailroadIsTwentyFiveDollars()
        {
            readingRailroad.Owner = hat;

            var rent = strategy.CalculateRent(readingRailroad, properties);

            Assert.AreEqual(25, rent);
        }

        [TestMethod]
        public void RentForTwoOwnedRailroadsBySameOwnerPlayerFiftyDollars()
        {
            readingRailroad.Owner = hat;
            pennsylvaniaRailroad.Owner = hat;

            var rent = strategy.CalculateRent(readingRailroad, properties);

            Assert.AreEqual(50, rent);
        }

        [TestMethod]
        public void RentForThreeOwnedRailroadsBySameOwnerPlayerIsOneHundredDollars()
        {
            readingRailroad.Owner = hat;
            pennsylvaniaRailroad.Owner = hat;
            boRailroad.Owner = hat;

            var rent = strategy.CalculateRent(readingRailroad, properties);

            Assert.AreEqual(100, rent);
        }

        [TestMethod]
        public void RentForFourOwnedRailroadsBySameOwnerPlayerIsTwoHundredDollars()
        {
            readingRailroad.Owner = hat;
            pennsylvaniaRailroad.Owner = hat;
            boRailroad.Owner = hat;
            shortLine.Owner = hat;

            var rent = strategy.CalculateRent(readingRailroad, properties);

            Assert.AreEqual(200, rent);
        }
    }
}