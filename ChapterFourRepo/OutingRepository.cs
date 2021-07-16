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
        //Create an individual outing
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
        //Display a list of all outings
        public List<IOuting> GetAllOutings()
        {
            return _listOfOutings;
        }
        //Display combined cost for all outings
        public decimal ReturnSumOfTotalCost(List<decimal> returnTotalCost)
        {
            decimal total = returnTotalCost.Sum();
            return total;
        }
        public List<decimal> GetCostOfAllOutingsByType(EventType eventType)
        {
            List<decimal> returnTotalCost = new List<decimal>();
            if(eventType == EventType.Golf)
            {
                foreach(GolfOuting outing in _listOfOutings)
                {
                    returnTotalCost.Add(outing.TotalCost);
                }
            }
            else if(eventType == EventType.AmusementPark)
            {
                foreach (AmusementParkOuting outing in _listOfOutings)
                {
                    returnTotalCost.Add(outing.TotalCost);
                }
            }
            else if(eventType == EventType.Bowling)
            {
                foreach (BowlingOuting outing in _listOfOutings)
                {
                    returnTotalCost.Add(outing.TotalCost);
                }
            }
            else
            {
                foreach (ConcertOuting outing in _listOfOutings)
                {
                    returnTotalCost.Add(outing.TotalCost);
                }
            }
            return returnTotalCost;
        }
        //Display outing costs by type
    }
}
