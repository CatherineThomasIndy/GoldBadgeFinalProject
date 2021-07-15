using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapterFourRepo
{
    public interface IOuting
    {
        EventType EventType { get; }
        int Attendance { get; set; }
        DateTime Date { get; set; }
        decimal CostPerPerson { get; }
        decimal TotalCost { get; }
    }
    public enum EventType
    {
        Golf = 1,
        Bowling,
        AmusementPark,
        Concert
    }
    public class GolfOuting : IOuting
    {
        public EventType EventType { get { return EventType.Golf; } }
        public int Attendance { get; set; }
        public DateTime Date { get; set; }
        public decimal CostPerPerson { get { return 30.00m; } }
        public decimal TotalCost { get { return CostPerPerson * Attendance; } }
        public GolfOuting() { }
        public GolfOuting(int attendance, DateTime date)
        {
            Attendance = attendance;
            Date = date;
        }
    }
    public class BowlingOuting : IOuting
    {
        public EventType EventType { get { return EventType.Bowling; } }
        public int Attendance { get; set; }
        public DateTime Date { get; set; }
        public decimal CostPerPerson { get { return 20.00m; } }
        public decimal TotalCost { get { return CostPerPerson * Attendance; } }
        public BowlingOuting() { }
        public BowlingOuting(int attendance, DateTime date)
        {
            Attendance = attendance;
            Date = date;
        }
    }
    public class AmusementParkOuting : IOuting
    {
        public EventType EventType { get { return EventType.AmusementPark; } }
        public int Attendance { get; set; }
        public DateTime Date { get; set; }
        public decimal CostPerPerson { get { return 40.00m; } }
        public decimal TotalCost { get { return CostPerPerson * Attendance; } }
        public AmusementParkOuting() { }
        public AmusementParkOuting(int attendance, DateTime date)
        {
            Attendance = attendance;
            Date = date;
        }
    }
    public class ConcertOuting : IOuting
    {
        public EventType EventType { get { return EventType.Concert; } }
        public int Attendance { get; set; }
        public DateTime Date { get; set; }
        public decimal CostPerPerson { get { return 25.00m; } }
        public decimal TotalCost { get { return CostPerPerson * Attendance; } }
        public ConcertOuting() { }
        public ConcertOuting(int attendance, DateTime date)
        {
            Attendance = attendance;
            Date = date;
        }
    }
}
