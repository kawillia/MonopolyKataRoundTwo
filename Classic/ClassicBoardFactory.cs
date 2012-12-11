using System;
using System.Collections.Generic;
using MonopolyKata.Core.Board;
using MonopolyKata.Core.Board.Locations;

namespace MonopolyKata.Classic
{
    public class ClassicBoardFactory
    {
        public const Int32 GoLocation = 0;
        public const Int32 IncomeTaxLocation = 4;
        public const Int32 JailLocation = 10;
        public const Int32 JustVisitingLocation = 10;
        public const Int32 GoToJailLocation = 30;
        public const Int32 LuxuryTaxLocation = 38;
        public const Int32 NumberOfLocations = 40;

        public static GameBoard Create()
        {
            return new GameBoard(GetLocations());
        }

        private static IEnumerable<Location> GetLocations()
        {
            var locations = new List<Location>();

            for (var i = 0; i < 40; i++)
                locations.Add(new Location(i));

            locations[GoLocation] = new Go(GoLocation, ClassicGameConstants.GoSalaryBonus);
            locations[GoToJailLocation] = new GoToJail(GoToJailLocation, JustVisitingLocation);
            locations[IncomeTaxLocation] = new IncomeTax(IncomeTaxLocation, ClassicGameConstants.IncomeTaxPercentage, ClassicGameConstants.MaximumIncomeTaxPaymentAmount);
            locations[LuxuryTaxLocation] = new LuxuryTax(LuxuryTaxLocation, ClassicGameConstants.LuxuryTaxPaymentAmount);

            return locations;
        }
    }
}