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
            var nonShuffledPlayers = new List<Player>();

            nonShuffledPlayers.Add(new Player("Horse"));
            nonShuffledPlayers.Add(new Player("Car"));

            var shuffler = new GuidShuffler<Player>();
            var shuffledPlayers = shuffler.Shuffle(nonShuffledPlayers);

            Assert.AreEqual(nonShuffledPlayers.Count, shuffledPlayers.Count());
        }

        [TestMethod]
        public void ShuffleOneHundredTimesShufflesTwoItemsProperly()
        {
            var nonShuffledPlayers = new List<Player>();

            nonShuffledPlayers.Add(new Player("Horse"));
            nonShuffledPlayers.Add(new Player("Car"));

            AssertProperShuffling(nonShuffledPlayers);
        }

        [TestMethod]
        public void ShuffleOneHundredTimesShufflesMoreThanTwoItemsProperly()
        {
            var nonShuffledPlayers = new List<Player>();

            nonShuffledPlayers.Add(new Player("Horse"));
            nonShuffledPlayers.Add(new Player("Car"));
            nonShuffledPlayers.Add(new Player("Hat"));
            nonShuffledPlayers.Add(new Player("Iron"));

            AssertProperShuffling(nonShuffledPlayers);
        }

        private void AssertProperShuffling(List<Player> nonShuffledPlayers)
        {
            var shuffledLists = new List<IEnumerable<Player>>();
            var shuffler = new GuidShuffler<Player>();

            for (var i = 0; i < 100; i++)
                shuffledLists.Add(shuffler.Shuffle(nonShuffledPlayers));

            var firstItems = shuffledLists.Select(l => l.First().Name).Distinct();

            Assert.AreEqual(nonShuffledPlayers.Count, firstItems.Count());
        }
    }
}
