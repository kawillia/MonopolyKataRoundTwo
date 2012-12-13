using System;
using System.Collections.Generic;
using MonopolyKata.Classic.Rules;
using MonopolyKata.Core;
using MonopolyKata.Core.Board;
using MonopolyKata.Core.Board.Properties;

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

        public const Int32 GoLocation = 0;
        public const Int32 MediterraneanAvenueLocation = 1;
        public const Int32 CommunityChestOneLocation = 2;
        public const Int32 BalticAvenueLocation = 3;
        public const Int32 IncomeTaxLocation = 4;
        public const Int32 ReadingRailroadLocation = 5;
        public const Int32 OrientalAvenueLocation = 6;
        public const Int32 ChanceOneLocation = 7;
        public const Int32 VermontAvenueLocation = 8;
        public const Int32 ConnecticutAvenueLocation = 9;
        public const Int32 JailLocation = 10;
        public const Int32 JustVisitingLocation = 10;
        public const Int32 StCharlesPlaceLocation = 11;
        public const Int32 ElectricCompanyLocation = 12;
        public const Int32 StatesAvenueLocation = 13;
        public const Int32 VirginiaAvenueLocation = 14;
        public const Int32 PennsylvaniaRailroadLocation = 15;
        public const Int32 StJamesPlaceLocation = 16;
        public const Int32 CommunityChestTwoLocation = 17;
        public const Int32 TennesseeAvenueLocation = 18;
        public const Int32 NewYorkAvenueLocation = 19;
        public const Int32 FreeParkingLocation = 20;
        public const Int32 KentuckyAvenueLocation = 21;
        public const Int32 ChanceTwoLocation = 22;
        public const Int32 IndianaAvenueLocation = 23;
        public const Int32 IllinoisAvenueLocation = 24;
        public const Int32 BORailroadLocation = 25;
        public const Int32 AtlanticAvenueLocation = 26;
        public const Int32 VentnorAvenueLocation = 27;
        public const Int32 WaterWorksLocation = 28;
        public const Int32 MarvinGardensLocation = 29;
        public const Int32 GoToJailLocation = 30;
        public const Int32 PacificAvenueLocation = 31;
        public const Int32 NorthCarolinaAvenueLocation = 32;
        public const Int32 CommunityChestThreeLocation = 33;
        public const Int32 PennsylvaniaAvenueLocation = 34;
        public const Int32 ShortLineLocation = 35;
        public const Int32 ChanceThreeLocation = 36;
        public const Int32 ParkPlaceLocation = 37;
        public const Int32 LuxuryTaxLocation = 38;
        public const Int32 BoardwalkLocation = 39;
        public const Int32 NumberOfLocations = 40;
        
        public static IEnumerable<BoardComponent> GetComponents(Dice dice)
        {
            var boardComponents = new List<BoardComponent>();
            var go = new Go(GoLocation, GoSalaryBonus);
            var mediterraneanAvenue = new Property(MediterraneanAvenueLocation, MediterraneanAvenuePrice, MediterraneanAvenueRent);
            var communityChestOne = new CommunityChest(CommunityChestOneLocation);
            var balticAvenue = new Property(BalticAvenueLocation, BalticAvenuePrice, BalticAvenueRent);
            var incomeTax = new IncomeTax(IncomeTaxLocation, IncomeTaxPercentage, MaximumIncomeTaxPaymentAmount);
            var readingRailrod = new Property(ReadingRailroadLocation, RailroadPrice, BaseRailroadRent);
            var orientalAvenue = new Property(OrientalAvenueLocation, OrientalAvenuePrice, OrientalAvenueRent);
            var chanceOne = new Chance(ChanceOneLocation);
            var vermontAvenue = new Property(VermontAvenueLocation, VermontAvenuePrice, VermontAvenueRent);
            var connecticutAvenue = new Property(ConnecticutAvenueLocation, ConnecticutAvenuePrice, ConnecticutAvenueRent);
            var justVisiting = new Space(JustVisitingLocation);
            var stCharlesPlace = new Property(StCharlesPlaceLocation, StCharlesPlacePrice, StCharlesPlaceRent);
            var electricCompany = new Property(ElectricCompanyLocation, UtilityPrice, 0);
            var statesAvenue = new Property(StatesAvenueLocation, StatesAvenuePrice, StatesAvenueRent);
            var virginiaAvenue = new Property(VirginiaAvenueLocation, VirginiaAvenuePrice, VirginiaAvenueRent);
            var pennsylvaniaRailroad = new Property(PennsylvaniaRailroadLocation, RailroadPrice, BaseRailroadRent);
            var stJamesPlace = new Property(StJamesPlaceLocation, StJamesPlacePrice, StJamesPlaceRent);
            var communityChestTwo = new CommunityChest(CommunityChestTwoLocation);
            var tennesseeAvenue = new Property(TennesseeAvenueLocation, TennesseeAvenuePrice, TennesseeAvenueRent);
            var newYorkAvenue = new Property(NewYorkAvenueLocation, NewYorkAvenuePrice, NewYorkAvenueRent);
            var freeParking = new Space(FreeParkingLocation);
            var kentuckyAvenue = new Property(KentuckyAvenueLocation, KentuckyAvenuePrice, KentuckyAvenueRent);
            var chanceTwo = new Chance(ChanceTwoLocation);
            var indianaAvenue = new Property(IndianaAvenueLocation, IndianaAvenuePrice, IndianaAvenueRent);
            var illinoisAvenue = new Property(IllinoisAvenueLocation, IllinoisAvenuePrice, IllinoisAvenueRent);
            var boRailroad = new Property(BORailroadLocation, RailroadPrice, BaseRailroadRent);
            var atlanticAvenue = new Property(AtlanticAvenueLocation, AtlanticAvenuePrice, AtlanticAvenueRent);
            var ventnorAvenue = new Property(VentnorAvenueLocation, VentnorAvenuePrice, VentnorAvenueRent);
            var waterWorks = new Property(WaterWorksLocation, UtilityPrice, 0);
            var marvinGardens = new Property(MarvinGardensLocation, MarvinGardensPrice, MarvinGardensRent);
            var goToJail = new GoToJail(GoToJailLocation, JustVisitingLocation);
            var pacificAvenue = new Property(PacificAvenueLocation, PacificAvenuePrice, PacificAvenueRent);
            var northCarolinaAvenue = new Property(NorthCarolinaAvenueLocation, NorthCarolinaAvenuePrice, NorthCarolinaAvenueRent);
            var communityChestThree = new CommunityChest(CommunityChestThreeLocation);
            var pennsylvaniaAvenue = new Property(PennsylvaniaAvenueLocation, PennsylvaniaAvenuePrice, PennsylvaniaAvenueRent);
            var shortLine = new Property(ShortLineLocation, RailroadPrice, BaseRailroadRent);
            var chanceThree = new Chance(ChanceThreeLocation);
            var parkPlace = new Property(ParkPlaceLocation, ParkPlacePrice, ParkPlaceRent);
            var luxuryTax = new LuxuryTax(LuxuryTaxLocation, LuxuryTaxPaymentAmount);
            var boardwalk = new Property(BoardwalkLocation, BoardwalkPrice, BoardwalkRent);

            var classicPropertyRentRule = new ClassicPropertyRentRule();

            var purpleGroup = new PropertyGroup(classicPropertyRentRule, mediterraneanAvenue, balticAvenue);
            var lightBlueGroup = new PropertyGroup(classicPropertyRentRule, orientalAvenue, vermontAvenue, connecticutAvenue);
            var violetGroup = new PropertyGroup(classicPropertyRentRule, stCharlesPlace, statesAvenue, virginiaAvenue);
            var orangeGroup = new PropertyGroup(classicPropertyRentRule, stJamesPlace, tennesseeAvenue, newYorkAvenue);
            var redGroup = new PropertyGroup(classicPropertyRentRule, kentuckyAvenue, indianaAvenue, illinoisAvenue);
            var yellowGroup = new PropertyGroup(classicPropertyRentRule, atlanticAvenue, ventnorAvenue, marvinGardens);
            var darkGreenGroup = new PropertyGroup(classicPropertyRentRule, pacificAvenue, northCarolinaAvenue, pennsylvaniaAvenue);
            var darkBlueGroup = new PropertyGroup(classicPropertyRentRule, parkPlace, boardwalk);
            var railroadGroup = new PropertyGroup(new ClassicRailroadRentRule(), readingRailrod, pennsylvaniaRailroad, boRailroad, shortLine);
            var utilityGroup = new PropertyGroup(new ClassicUtilityRentRule(dice), electricCompany, waterWorks);

            boardComponents = new List<BoardComponent>();
            boardComponents.Add(purpleGroup);
            boardComponents.Add(lightBlueGroup);
            boardComponents.Add(violetGroup);
            boardComponents.Add(orangeGroup);
            boardComponents.Add(redGroup);
            boardComponents.Add(yellowGroup);
            boardComponents.Add(darkGreenGroup);
            boardComponents.Add(darkBlueGroup);
            boardComponents.Add(railroadGroup);
            boardComponents.Add(utilityGroup);
            boardComponents.Add(go);
            boardComponents.Add(goToJail);
            boardComponents.Add(incomeTax);
            boardComponents.Add(luxuryTax);
            boardComponents.Add(justVisiting);
            boardComponents.Add(freeParking);
            boardComponents.Add(communityChestOne);
            boardComponents.Add(communityChestTwo);
            boardComponents.Add(communityChestThree);
            boardComponents.Add(chanceOne);
            boardComponents.Add(chanceTwo);
            boardComponents.Add(chanceThree);

            return boardComponents;
        }
    }
}