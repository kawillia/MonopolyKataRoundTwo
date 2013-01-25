using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Classic;
using MonopolyKata.Classic.Rules;
using MonopolyKata.Core;
using MonopolyKata.Core.Spaces;
using System;

namespace MonopolyKata.Tests.Rules
{
    [TestClass]
    public class ClassicRailroadRentRuleTests
    {
        private ClassicRailroadRentRule rule;
        private String horse;
        private String hat;
        private Property readingRailroad;
        private Property pennsylvaniaRailroad;
        private Property boRailroad;
        private Property shortLine;

        public ClassicRailroadRentRuleTests()
        {
            horse = "Horse";
            hat = "Hat";

            var banker = new Banker(new[] { horse, hat });

            readingRailroad = new Property(ClassicBoardFactory.RailroadPrice, ClassicBoardFactory.BaseRailroadRent, banker);
            pennsylvaniaRailroad = new Property(ClassicBoardFactory.RailroadPrice, ClassicBoardFactory.BaseRailroadRent, banker);
            boRailroad = new Property(ClassicBoardFactory.RailroadPrice, ClassicBoardFactory.BaseRailroadRent, banker);
            shortLine = new Property(ClassicBoardFactory.RailroadPrice, ClassicBoardFactory.BaseRailroadRent, banker);
            rule = new ClassicRailroadRentRule(new[] { readingRailroad, pennsylvaniaRailroad, boRailroad, shortLine });
        }

        [TestMethod]
        public void RentForOneOwnedRailroadIsTwentyFiveDollars()
        {
            readingRailroad.Owner = hat;

            var rent = rule.Calculate(readingRailroad);

            Assert.AreEqual(25, rent);
        }

        [TestMethod]
        public void RentForTwoOwnedRailroadsBySameOwnerPlayerFiftyDollars()
        {
            readingRailroad.Owner = hat;
            pennsylvaniaRailroad.Owner = hat;

            var rent = rule.Calculate(readingRailroad);

            Assert.AreEqual(50, rent);
        }

        [TestMethod]
        public void RentForThreeOwnedRailroadsBySameOwnerPlayerIsOneHundredDollars()
        {
            readingRailroad.Owner = hat;
            pennsylvaniaRailroad.Owner = hat;
            boRailroad.Owner = hat;

            var rent = rule.Calculate(readingRailroad);

            Assert.AreEqual(100, rent);
        }

        [TestMethod]
        public void RentForFourOwnedRailroadsBySameOwnerPlayerIsTwoHundredDollars()
        {
            readingRailroad.Owner = hat;
            pennsylvaniaRailroad.Owner = hat;
            boRailroad.Owner = hat;
            shortLine.Owner = hat;

            var rent = rule.Calculate(readingRailroad);

            Assert.AreEqual(200, rent);
        }
    }
}