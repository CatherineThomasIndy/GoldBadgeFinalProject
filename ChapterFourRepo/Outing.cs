using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapterFourRepo
{
    public class Outing
    {
        public EventType EventType { get; set; }
        public int Attendance { get; set; }
        public DateTime Date { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal TotalCost { get; set; }

        public Outing() { }

        public Outing(EventType eventType, int attendance, DateTime date, decimal costPerPerson, decimal totalCost)
        {
            EventType = eventType;
            Attendance = attendance;
            Date = date;
            CostPerPerson = costPerPerson;
            TotalCost = totalCost;
        }
    }

    public enum EventType
    {
        Golf = 1,
        Bowling,
        AmusementPark,
        Concert
    }
}
