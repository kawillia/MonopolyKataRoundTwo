using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata.Core;

namespace MonopolyKata.Tests
{
    [TestClass]
    public class ListShufflerTests
    {
        [TestMethod]
        public void ShuffleReturnsSameNumberOfItems()
        {
            var nonShuffledList = new List<String>();

            nonShuffledList.Add("Horse");
            nonShuffledList.Add("Car");

            var shuffler = new GuidShuffler<String>();
            var shuffledPlayers = shuffler.Shuffle(nonShuffledList);

            Assert.AreEqual(nonShuffledList.Count, shuffledPlayers.Count());
        }

        [TestMethod]
        public void ShuffleOneHundredTimesShufflesTwoItemsProperly()
        {
            var nonShuffledList = new List<String>();

            nonShuffledList.Add("Horse");
            nonShuffledList.Add("Car");

            AssertProperShuffling(nonShuffledList);
        }

        [TestMethod]
        public void ShuffleOneHundredTimesShufflesMoreThanTwoItemsProperly()
        {
            var nonShuffledList = new List<String>();

            nonShuffledList.Add("Horse");
            nonShuffledList.Add("Car");
            nonShuffledList.Add("Hat");
            nonShuffledList.Add("Iron");

            AssertProperShuffling(nonShuffledList);
        }

        private void AssertProperShuffling(List<String> nonShuffledPlayers)
        {
            var shuffledLists = new List<IEnumerable<String>>();
            var shuffler = new GuidShuffler<String>();

            for (var i = 0; i < 100; i++)
                shuffledLists.Add(shuffler.Shuffle(nonShuffledPlayers));

            var firstItems = shuffledLists.Select(l => l.First()).Distinct();

            Assert.AreEqual(nonShuffledPlayers.Count, firstItems.Count());
        }
    }
}
