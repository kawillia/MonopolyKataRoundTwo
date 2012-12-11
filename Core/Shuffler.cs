using System;
using System.Collections.Generic;

namespace MonopolyKata.Core
{
    public class Shuffler<T>
    {
        private Random randomIndexGenerator;
        private List<T> nonShuffledList;
        private List<T> shuffledList;

        public Shuffler()
        {
            randomIndexGenerator = new Random();
        }

        public IEnumerable<T> Shuffle(IEnumerable<T> nonShuffledList)
        {
            this.nonShuffledList = new List<T>(nonShuffledList);
            shuffledList = new List<T>();

            while (ItemLeftToShuffle())
                ShuffleNextItem();

            return shuffledList;
        }

        private Boolean ItemLeftToShuffle()
        {
            return nonShuffledList.Count > 0;
        }

        private void ShuffleNextItem()
        {
            var itemIndexToShuffle = randomIndexGenerator.Next(0, nonShuffledList.Count);
            shuffledList.Add(nonShuffledList[itemIndexToShuffle]);
            nonShuffledList.RemoveAt(itemIndexToShuffle);
        }   
    }
}
