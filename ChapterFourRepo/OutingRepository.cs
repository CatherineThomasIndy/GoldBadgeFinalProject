using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapterFourRepo
{
    public class OutingRepository
    {
        public List<Outing> _listOfOutings = new List<Outing>();
        //Create an individual outing
        public bool AddOutingToOutingList(Outing outing)
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
        public List<Outing> GetAllOutings()
        {
            return _listOfOutings;
        }
        //Display combined cost for all outings
        public decimal CostOfAllOutingsByType(EventType eventType)
        {
            foreach (Outing outing in _listOfOutings)
            {
                if (outing.EventType == eventType)
                {
                    
                }
            }
        }
        //Display outing costs by type
    }
}
