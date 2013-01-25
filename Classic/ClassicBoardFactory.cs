using System;
using System.Collections.Generic;
using MonopolyKata.Classic.Rules;
using MonopolyKata.Core;
using MonopolyKata.Core.Board;
using MonopolyKata.Core.Rules;

namespace MonopolyKata.Classic
{
    public class ClassicBoardFactory
    {
        public const Int32 GoSalaryBonus = 200;
        public const Int32 IncomeTaxPercentage = 10;
        public const Int32 LuxuryTaxPaymentAmount = 75;
        public const Int32 MaximumIncomeTaxPaymentAmount = 200;

        public const Int32 RailroadPrice = 200;
        public const Int32 UtilityPrice = 150;

        public const Int32 BaseRailroadRent = 25;
        public const Int32 MediterraneanAvenueRent = 2;
        public const Int32 BalticAvenueRent = 4;
        public const Int32 OrientalAvenueRent = 6;
        public const Int32 VermontAvenueRent = 6;
        public const Int32 ConnecticutAvenueRent = 8;
        public const Int32 StCharlesPlaceRent = 10;
        public const Int32 StatesAvenueRent = 10;
        public const Int32 VirginiaAvenueRent = 12;
        public const Int32 StJamesPlaceRent = 14;
        public const Int32 TennesseeAvenueRent = 14;
        public const Int32 NewYorkAvenueRent = 16;
        public const Int32 KentuckyAvenueRent = 18;
        public const Int32 IndianaAvenueRent = 18;
        public const Int32 IllinoisAvenueRent = 20;
        public const Int32 AtlanticAvenueRent = 22;
        public const Int32 VentnorAvenueRent = 22;
        public const Int32 MarvinGardensRent = 24;
        public const Int32 PacificAvenueRent = 26;
        public const Int32 NorthCarolinaAvenueRent = 26;
        public const Int32 PennsylvaniaAvenueRent = 28;
        public const Int32 ParkPlaceRent = 35;
        public const Int32 BoardwalkRent = 50;

        public const Int32 MediterraneanAvenuePrice = 60;
        public const Int32 BalticAvenuePrice = 60;
        public const Int32 OrientalAvenuePrice = 100;
        public const Int32 VermontAvenuePrice = 100;
        public const Int32 ConnecticutAvenuePrice = 120;
        public const Int32 StCharlesPlacePrice = 140;
        public const Int32 StatesAvenuePrice = 140;
        public const Int32 VirginiaAvenuePrice = 160;
        public const Int32 StJamesPlacePrice = 180;
        public const Int32 TennesseeAvenuePrice = 180;
        public const Int32 NewYorkAvenuePrice = 200;
        public const Int32 KentuckyAvenuePrice = 220;
        public const Int32 IndianaAvenuePrice = 220;
        public const Int32 IllinoisAvenuePrice = 240;
        public const Int32 AtlanticAvenuePrice = 260;
        public const Int32 VentnorAvenuePrice = 260;
        public const Int32 MarvinGardensPrice = 280;
        public const Int32 PacificAvenuePrice = 300;
        public const Int32 NorthCarolinaAvenuePrice = 300;
        public const Int32 PennsylvaniaAvenuePrice = 320;
        public const Int32 ParkPlacePrice = 350;
        public const Int32 BoardwalkPrice = 400;

        public const Int32 JustVisitingLocation = 10;
        public const Int32 NumberOfSpaces = 40;

        public static GameBoard CreateBoard(Dice dice, IEnumerable<IMovementRule> movementRules, Banker banker, IEnumerable<String> players)
        {
            var spaces = new List<Space>();
            var board = new GameBoard(spaces, movementRules, players);

            var go = new Go(GoSalaryBonus, banker);
            var mediterraneanAvenue = new Property(MediterraneanAvenuePrice, MediterraneanAvenueRent, banker);
            var communityChestOne = new Space();
            var balticAvenue = new Property(BalticAvenuePrice, BalticAvenueRent, banker);
            var incomeTax = new IncomeTax(IncomeTaxPercentage, MaximumIncomeTaxPaymentAmount, banker);
            var readingRailroad = new Property(RailroadPrice, BaseRailroadRent, banker);
            var orientalAvenue = new Property(OrientalAvenuePrice, OrientalAvenueRent, banker);
            var chanceOne = new Space();
            var vermontAvenue = new Property(VermontAvenuePrice, VermontAvenueRent, banker);
            var connecticutAvenue = new Property(ConnecticutAvenuePrice, ConnecticutAvenueRent, banker);
            var justVisiting = new Space();
            var stCharlesPlace = new Property(StCharlesPlacePrice, StCharlesPlaceRent, banker);
            var electricCompany = new Property(UtilityPrice, 0, banker);
            var statesAvenue = new Property(StatesAvenuePrice, StatesAvenueRent, banker);
            var virginiaAvenue = new Property(VirginiaAvenuePrice, VirginiaAvenueRent, banker);
            var pennsylvaniaRailroad = new Property(RailroadPrice, BaseRailroadRent, banker);
            var stJamesPlace = new Property(StJamesPlacePrice, StJamesPlaceRent, banker);
            var communityChestTwo = new Space();
            var tennesseeAvenue = new Property(TennesseeAvenuePrice, TennesseeAvenueRent, banker);
            var newYorkAvenue = new Property(NewYorkAvenuePrice, NewYorkAvenueRent, banker);
            var freeParking = new Space();
            var kentuckyAvenue = new Property(KentuckyAvenuePrice, KentuckyAvenueRent, banker);
            var chanceTwo = new Space();
            var indianaAvenue = new Property(IndianaAvenuePrice, IndianaAvenueRent, banker);
            var illinoisAvenue = new Property(IllinoisAvenuePrice, IllinoisAvenueRent, banker);
            var boRailroad = new Property(RailroadPrice, BaseRailroadRent, banker);
            var atlanticAvenue = new Property(AtlanticAvenuePrice, AtlanticAvenueRent, banker);
            var ventnorAvenue = new Property(VentnorAvenuePrice, VentnorAvenueRent, banker);
            var waterWorks = new Property(UtilityPrice, 0, banker);
            var marvinGardens = new Property(MarvinGardensPrice, MarvinGardensRent, banker);
            var goToJail = new GoToJail(JustVisitingLocation, board);
            var pacificAvenue = new Property(PacificAvenuePrice, PacificAvenueRent, banker);
            var northCarolinaAvenue = new Property(NorthCarolinaAvenuePrice, NorthCarolinaAvenueRent, banker);
            var communityChestThree = new Space();
            var pennsylvaniaAvenue = new Property(PennsylvaniaAvenuePrice, PennsylvaniaAvenueRent, banker);
            var shortLine = new Property(RailroadPrice, BaseRailroadRent, banker);
            var chanceThree = new Space();
            var parkPlace = new Property(ParkPlacePrice, ParkPlaceRent, banker);
            var luxuryTax = new LuxuryTax(LuxuryTaxPaymentAmount, banker);
            var boardwalk = new Property(BoardwalkPrice, BoardwalkRent, banker);

            var purpleGroupRentRule = new ClassicPropertyRentRule(new[] { mediterraneanAvenue, balticAvenue });
            var lightBlueGroupRentRule = new ClassicPropertyRentRule(new[] { orientalAvenue, vermontAvenue, connecticutAvenue });
            var violetGroupRentRule = new ClassicPropertyRentRule(new[] { stCharlesPlace, statesAvenue, virginiaAvenue });
            var orangeGroupRentRule = new ClassicPropertyRentRule(new[] { stJamesPlace, tennesseeAvenue, newYorkAvenue });
            var redGroupRentRule = new ClassicPropertyRentRule(new[] { kentuckyAvenue, indianaAvenue, illinoisAvenue });
            var yellowGroupRentRule = new ClassicPropertyRentRule(new[] { atlanticAvenue, ventnorAvenue, marvinGardens });
            var darkGreenGroupRentRule = new ClassicPropertyRentRule(new[] { pacificAvenue, northCarolinaAvenue, pennsylvaniaAvenue });
            var darkBlueGroupRentRule = new ClassicPropertyRentRule(new[] { parkPlace, boardwalk });
            var railroadGroupRentRule = new ClassicPropertyRentRule(new[] { readingRailroad, pennsylvaniaRailroad, boRailroad, shortLine });
            var utilityGroupRentRule = new ClassicPropertyRentRule(new[] { electricCompany, waterWorks });

            mediterraneanAvenue.ChangeChargeRentRule(purpleGroupRentRule);
            balticAvenue.ChangeChargeRentRule(purpleGroupRentRule);

            orientalAvenue.ChangeChargeRentRule(lightBlueGroupRentRule);
            vermontAvenue.ChangeChargeRentRule(lightBlueGroupRentRule);
            connecticutAvenue.ChangeChargeRentRule(lightBlueGroupRentRule);

            stCharlesPlace.ChangeChargeRentRule(violetGroupRentRule);
            statesAvenue.ChangeChargeRentRule(violetGroupRentRule);
            virginiaAvenue.ChangeChargeRentRule(violetGroupRentRule);

            stJamesPlace.ChangeChargeRentRule(orangeGroupRentRule);
            tennesseeAvenue.ChangeChargeRentRule(orangeGroupRentRule);
            newYorkAvenue.ChangeChargeRentRule(orangeGroupRentRule);

            kentuckyAvenue.ChangeChargeRentRule(redGroupRentRule);
            indianaAvenue.ChangeChargeRentRule(redGroupRentRule);
            illinoisAvenue.ChangeChargeRentRule(redGroupRentRule);

            atlanticAvenue.ChangeChargeRentRule(yellowGroupRentRule);
            ventnorAvenue.ChangeChargeRentRule(yellowGroupRentRule);
            marvinGardens.ChangeChargeRentRule(yellowGroupRentRule);

            pacificAvenue.ChangeChargeRentRule(darkGreenGroupRentRule);
            northCarolinaAvenue.ChangeChargeRentRule(darkGreenGroupRentRule);
            pennsylvaniaAvenue.ChangeChargeRentRule(darkGreenGroupRentRule);

            parkPlace.ChangeChargeRentRule(darkBlueGroupRentRule);
            boardwalk.ChangeChargeRentRule(darkBlueGroupRentRule);

            spaces.Add(go);
            spaces.Add(mediterraneanAvenue);
            spaces.Add(communityChestOne);
            spaces.Add(balticAvenue);
            spaces.Add(incomeTax);
            spaces.Add(readingRailroad);
            spaces.Add(orientalAvenue);
            spaces.Add(chanceOne);
            spaces.Add(vermontAvenue);
            spaces.Add(connecticutAvenue);
            spaces.Add(justVisiting);
            spaces.Add(stCharlesPlace);
            spaces.Add(electricCompany);
            spaces.Add(statesAvenue);
            spaces.Add(virginiaAvenue);
            spaces.Add(pennsylvaniaRailroad);
            spaces.Add(stJamesPlace);
            spaces.Add(communityChestTwo);
            spaces.Add(tennesseeAvenue);
            spaces.Add(newYorkAvenue);
            spaces.Add(freeParking);
            spaces.Add(kentuckyAvenue);
            spaces.Add(chanceTwo);
            spaces.Add(indianaAvenue);
            spaces.Add(illinoisAvenue);
            spaces.Add(boRailroad);
            spaces.Add(atlanticAvenue);
            spaces.Add(ventnorAvenue);
            spaces.Add(waterWorks);
            spaces.Add(marvinGardens);
            spaces.Add(goToJail);
            spaces.Add(pacificAvenue);
            spaces.Add(northCarolinaAvenue);
            spaces.Add(communityChestThree);
            spaces.Add(pennsylvaniaAvenue);
            spaces.Add(shortLine);
            spaces.Add(chanceThree);
            spaces.Add(parkPlace);
            spaces.Add(luxuryTax);
            spaces.Add(boardwalk);

            return board;
        }
    }
}