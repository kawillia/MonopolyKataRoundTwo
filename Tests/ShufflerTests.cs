using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using System;

namespace MonopolyTests
{
    [TestClass]
    public class ListShufflerTests
    {
        [TestMethod]
        public void ShuffleReturnsSameNumberOfItems()
        {
            List<Player> nonShuffledPlayers = new List<Player>();

            nonShuffledPlayers.Add(new Player("Horse"));
            nonShuffledPlayers.Add(new Player("Car"));

            Shuffler<Player> shuffler = new Shuffler<Player>();
            IEnumerable<Player> shuffledPlayers = shuffler.Shuffle(nonShuffledPlayers);

            Assert.AreEqual(nonShuffledPlayers.Count, shuffledPlayers.Count());
        }

        [TestMethod]
        public void ShuffleOneHundredTimesShufflesTwoItemsProperly()
        {
            List<Player> nonShuffledPlayers = new List<Player>();

            nonShuffledPlayers.Add(new Player("Horse"));
            nonShuffledPlayers.Add(new Player("Car"));

            AssertProperShuffling(nonShuffledPlayers);
        }

        [TestMethod]
        public void ShuffleOneHundredTimesShufflesMoreThanTwoItemsProperly()
        {
            List<Player> nonShuffledPlayers = new List<Player>();

            nonShuffledPlayers.Add(new Player("Horse"));
            nonShuffledPlayers.Add(new Player("Car"));
            nonShuffledPlayers.Add(new Player("Hat"));
            nonShuffledPlayers.Add(new Player("Iron"));

            AssertProperShuffling(nonShuffledPlayers);
        }

        private void AssertProperShuffling(List<Player> nonShuffledPlayers)
        {
            List<IEnumerable<Player>> shuffledLists = new List<IEnumerable<Player>>();
            Shuffler<Player> shuffler = new Shuffler<Player>();

            for (Int32 i = 0; i < 100; i++)
            {
                shuffledLists.Add(shuffler.Shuffle(nonShuffledPlayers));
            }

            IEnumerable<string> firstItems = shuffledLists.Select(l => l.First().Name).Distinct();

            Assert.AreEqual(nonShuffledPlayers.Count, firstItems.Count());
        }
    }
}
