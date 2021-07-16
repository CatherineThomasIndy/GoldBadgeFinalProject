using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapterFourRepo
{
    public class OutingRepository
    {
        public List<IOuting> _listOfOutings = new List<IOuting>();
        public List<GolfOuting> _listOfGolfOutings = new List<GolfOuting>();
        public List<BowlingOuting> _listOfBowlingOutings = new List<BowlingOuting>();
        public List<AmusementParkOuting> _listOfAmuseParkOutings = new List<AmusementParkOuting>();
        public List<ConcertOuting> _listOfConcertOutings = new List<ConcertOuting>();
        public bool AddOutingToOutingList(IOuting outing)
        {
            int listOfOutingsCount = _listOfOutings.Count();
            _listOfOutings.Add(outing);
            if (_listOfOutings.Count() == listOfOutingsCount + 1)
            {
                return true;
            }
            else return false;
        }
        public List<IOuting> GetAllOutings()
        {
            return _listOfOutings;
        }
        public decimal ReturnSumOfTotalCost(List<decimal> returnTotalCost)
        {
            decimal total = returnTotalCost.Sum();
            return total;
        }
        public List<decimal> GetCostOfGolfOutings()
        {
            List<decimal> totalCost = new List<decimal>();
            foreach(GolfOuting outing in _listOfGolfOutings)
            {
                totalCost.Add(outing.TotalCost);
            }
            return totalCost;
        }
        public List<decimal> GetCostOfBowlingOutings()
        {
            List<decimal> totalCost = new List<decimal>();
            foreach (BowlingOuting outing in _listOfBowlingOutings)
            {
                totalCost.Add(outing.TotalCost);
            }
            return totalCost;
        }
        public List<decimal> GetCostOfAmusementParkOutings()
        {
            List<decimal> totalCost = new List<decimal>();
            foreach (AmusementParkOuting outing in _listOfAmuseParkOutings)
            {
                totalCost.Add(outing.TotalCost);
            }
            return totalCost;
        }
        public List<decimal> GetCostOfConcertOutings()
        {
            List<decimal> totalCost = new List<decimal>();
            foreach (ConcertOuting outing in _listOfConcertOutings)
            {
                totalCost.Add(outing.TotalCost);
            }
            return totalCost;
        }
        public List<decimal> GetCostOfAllOutings()
        {
            List<decimal> returnTotalCost = new List<decimal>();
            foreach(IOuting outing in _listOfOutings)
            {
                returnTotalCost.Add(outing.TotalCost);
            }
            return returnTotalCost;
        }
    }
}
