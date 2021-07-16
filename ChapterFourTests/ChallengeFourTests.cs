using ChapterFourRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChapterFourTests
{
    [TestClass]
    public class ChallengeFourTests
    {

        OutingRepository _outingRepo = new OutingRepository();

        [TestMethod]
        public void AddOutingToOutingList_ShouldReturnTrue()
        {
            IOuting item = new GolfOuting();
            bool addItemResult = _outingRepo.AddOutingToOutingList(item);
            Assert.IsTrue(addItemResult);
        }

        [TestMethod]
        public void GetAllOutings_ShouldReturnTrue()
        {
            List<IOuting> outingList = _outingRepo.GetAllOutings();
            Assert.IsInstanceOfType(outingList, typeof(List<IOuting>));
        }

        [TestMethod]
        public void ReturnSumOfTotalCost_ShouldReturnTrue()
        {
            List<decimal> listOfCosts = new List<decimal> { 1m, 2m, 3m };
            decimal actualResult = _outingRepo.ReturnSumOfTotalCost(listOfCosts);
            decimal expectedResult = 6m;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetCostOfGolfOutings_ShouldReturnTrue()
        {
            GolfOuting golfOuting1 = new GolfOuting(1);
            GolfOuting golfOuting2 = new GolfOuting(1);
            _outingRepo._listOfGolfOutings.Add(golfOuting1);
            _outingRepo._listOfGolfOutings.Add(golfOuting2);
            List<decimal> costOfOuting = _outingRepo.GetCostOfGolfOutings();
            decimal actualTotal = _outingRepo.ReturnSumOfTotalCost(costOfOuting);
            decimal expectedTotal = 60m;
            Assert.AreEqual(expectedTotal, actualTotal);
        }
        [TestMethod]
        public void GetCostOfBowling_ShouldReturnTrue()
        {
            BowlingOuting bowlingOuting1 = new BowlingOuting(1);
            BowlingOuting bowlingOuting2 = new BowlingOuting(1);
            _outingRepo._listOfBowlingOutings.Add(bowlingOuting1);
            _outingRepo._listOfBowlingOutings.Add(bowlingOuting2);
            List<decimal> costOfOuting = _outingRepo.GetCostOfBowlingOutings();
            decimal actualTotal = _outingRepo.ReturnSumOfTotalCost(costOfOuting);
            decimal expectedTotal = 40m;
            Assert.AreEqual(expectedTotal, actualTotal);
        }
        [TestMethod]
        public void GetCostOfAmusementParkOutings_ShouldReturnTrue()
        {
            AmusementParkOuting amuseParkOuting1 = new AmusementParkOuting(1);
            AmusementParkOuting amuseParkOuting2 = new AmusementParkOuting(1);
            _outingRepo._listOfAmuseParkOutings.Add(amuseParkOuting1);
            _outingRepo._listOfAmuseParkOutings.Add(amuseParkOuting2);
            List<decimal> costOfOuting = _outingRepo.GetCostOfAmusementParkOutings();
            decimal actualTotal = _outingRepo.ReturnSumOfTotalCost(costOfOuting);
            decimal expectedTotal = 80m;
            Assert.AreEqual(expectedTotal, actualTotal);
        }
        [TestMethod]
        public void GetCostOfConcertOutings_ShouldReturnTrue()
        {
            ConcertOuting concertOuting1 = new ConcertOuting(1);
            ConcertOuting concertOuting2 = new ConcertOuting(1);
            _outingRepo._listOfConcertOutings.Add(concertOuting1);
            _outingRepo._listOfConcertOutings.Add(concertOuting2);
            List<decimal> costOfOuting = _outingRepo.GetCostOfConcertOutings();
            decimal actualTotal = _outingRepo.ReturnSumOfTotalCost(costOfOuting);
            decimal expectedTotal = 50m;
            Assert.AreEqual(expectedTotal, actualTotal);
        }

        [TestMethod]
        public void GetCostOfAllOutings_ShouldReturnTrue()
        {
            GolfOuting golfOuting1 = new GolfOuting(1);
            GolfOuting golfOuting2 = new GolfOuting(1);
            _outingRepo._listOfOutings.Add(golfOuting1);
            _outingRepo._listOfOutings.Add(golfOuting2);
            BowlingOuting bowlingOuting1 = new BowlingOuting(1);
            BowlingOuting bowlingOuting2 = new BowlingOuting(1);
            _outingRepo._listOfOutings.Add(bowlingOuting1);
            _outingRepo._listOfOutings.Add(bowlingOuting2);
            AmusementParkOuting amuseParkOuting1 = new AmusementParkOuting(1);
            AmusementParkOuting amuseParkOuting2 = new AmusementParkOuting(1);
            _outingRepo._listOfOutings.Add(amuseParkOuting1);
            _outingRepo._listOfOutings.Add(amuseParkOuting2);
            ConcertOuting concertOuting1 = new ConcertOuting(1);
            ConcertOuting concertOuting2 = new ConcertOuting(1);
            _outingRepo._listOfOutings.Add(concertOuting1);
            _outingRepo._listOfOutings.Add(concertOuting2);
            List<decimal> allOutings = _outingRepo.GetCostOfAllOutings();
            decimal actualTotal = _outingRepo.ReturnSumOfTotalCost(allOutings);
            decimal expectedTotal = 230m;
            Assert.AreEqual(expectedTotal, actualTotal);
        }
    }
}
