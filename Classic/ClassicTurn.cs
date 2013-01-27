using MonopolyKata.Core;
using MonopolyKata.Core.Spaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata.Classic
{
    public class ClassicTurn : ITurn
    {
        private Dice dice;
        private IBoard board;
        private Banker banker;
        private PropertyManager propertyManager;

        public ClassicTurn(Dice dice, IBoard board, Banker banker, PropertyManager propertyManager)
        {
            this.dice = dice;
            this.board = board;
            this.banker = banker;
            this.propertyManager = propertyManager;
        }

        public void Begin(String player)
        {
            MakePropertyDecisions(player);
        }

        public void Take(String player)
        {
            var numberOfRolls = 0;

            do
            {
                dice.Roll();

                if (dice.IsDoubles && ++numberOfRolls == 3)
                {
                    board.TeleportPlayer(player, 10);
                    return;
                }

                board.MovePlayer(player, dice.CurrentValue);
            }
            while (dice.IsDoubles);
        }

        public void End(String player)
        {
            MakePropertyDecisions(player);
        }

        private void MakePropertyDecisions(String player)
        {
            if (banker.GetBalance(player) < 200)
                MortgageProperties(player);
            else
                UnmortgageProperties(player);
        }

        private void MortgageProperties(String player)
        {
            var properties = propertyManager.GetUnmortgagedProperties(player);

            foreach (var property in properties)
                if (banker.GetBalance(player) < 200)
                    property.Mortgage();
        }

        private void UnmortgageProperties(String player)
        {
            var properties = propertyManager.GetMortgagedProperties(player);

            foreach (var property in properties)
                if (banker.GetBalance(player) > property.Price)
                    property.Unmortgage();
        }
    }
}
