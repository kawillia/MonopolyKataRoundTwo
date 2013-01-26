using MonopolyKata.Core;
using MonopolyKata.Core.Spaces;
using System;
using System.Linq;

namespace MonopolyKata.Classic
{
    public class ClassicTurn : ITurn
    {
        private Dice dice;
        private Board board;
        private Banker banker;
        private PropertyManager propertyManager;

        public ClassicTurn(Dice dice, Board board, Banker banker, PropertyManager propertyManager)
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
            var ownedProperties = propertyManager.GetPropertiesOwnedByPlayer(player);

            if (banker.GetBalance(player) < 200)
            {
                var propertiesToMortgage = ownedProperties.Where(p => !p.IsMortgaged);

                foreach (var property in ownedProperties)
                    if (banker.GetBalance(player) < 200)
                        property.Mortgage();
            }
            else
            {
                var propertiesToUnmortgage = ownedProperties.Where(p => p.IsMortgaged);

                foreach (var property in ownedProperties)
                    if (banker.GetBalance(player) > property.Price)
                        property.Unmortgage();
            }
        }
    }
}
