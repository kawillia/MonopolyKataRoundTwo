using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata.Core.Board
{
    public class GameBoard
    {
        protected IEnumerable<BoardComponent> boardComponents;
        public Int32 TotalNumberOfLocations { get; private set; }
        
        public GameBoard()
        {
            this.boardComponents = boardComponents;
            TotalNumberOfLocations = boardComponents.Sum(l => l.NumberOfChildComponents);
        }

        public BoardComponent GetComponentAtLocation(Int32 location)
        {
            return boardComponents.First(bc => bc.ContainsComponentIndex(location));
        }
    }
}
