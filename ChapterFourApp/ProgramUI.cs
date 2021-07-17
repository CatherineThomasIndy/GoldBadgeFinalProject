using ChapterFourApp.Consoles;
using ChapterFourRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapterFourApp
{
    public class ProgramUI
    {
        private bool _isRunning = true;
        private ICustomConsole _con;
        private readonly OutingRepository _outingRepo = new OutingRepository();
        public ProgramUI(ICustomConsole console)
        {
            _con = console;
        }
        public void Run()
        {
            SeedList();
            RunMenu();
        }
        private void RunMenu()
        {
            while (_isRunning)
            {
                string userInput = GetMenuSelection();
                OpenMenuItem(userInput);
            }
        }
        private string GetMenuSelection()
        {
            _con.Clear();
            _con.PrintMenu();
            string userInput = _con.ReadLine();
            return userInput;
        }
        private void OpenMenuItem(string userInput)
        {
            _con.Clear();
            switch (userInput)
            {
                case "1":
                    DisplayAllOutings();
                    break;
                case "2":
                    CreateANewOuting();
                    break;
                case "3":
                    DisplayCostOfAllOutingsByType();
                    break;
                case "4":
                    DisplayCostOfAllOutings();
                    break;
                case "5":
                    ExitApplication();
                    break;
                default:
                    _con.InvalidInput();
                    Continue();
                    break;
            }
        }
        private void DisplayAllOutings()
        {
            foreach(IOuting outing in _outingRepo._listOfOutings)
            {
                _con.Write($"Type of Event: {outing.EventType}\n" +
                    $"Date of Event: {outing.Date.ToShortDateString()}\n" +
                    $"Attendance: {outing.Attendance}\n" +
                    $"Cost per Person: {outing.CostPerPerson}\n" +
                    $"Total Cost of Outing: {outing.TotalCost}\n");
            }
            Continue();
        }
        private void CreateANewOuting()
        {
            _con.Write("Enter the number for which event you would like to create:\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert\n");
            string eventInputAsString = _con.ReadLine();
            int eventInput;
            int.TryParse(eventInputAsString, out eventInput);
            if(eventInput >= 1 && eventInput <= 4)
            {
                CreateOuting(eventInput);
            }
            else
            {
                _con.InvalidInput();
                Continue();
            }
        }
        private void DisplayCostOfAllOutingsByType()
        {
            _con.Write("Enter the number for which event you would like to see the total costs:\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert\n");
            string input = _con.ReadLine();
            switch (input)
            {
                case "1":
                    List<decimal> golfOutingsCost = _outingRepo.GetCostOfGolfOutings();
                    PrintTotalCost(EventType.Golf, golfOutingsCost);
                    break;
                case "2":
                    List<decimal> bowlingOutingsCost = _outingRepo.GetCostOfBowlingOutings();
                    PrintTotalCost(EventType.Bowling, bowlingOutingsCost);
                    break;
                case "3":
                    List<decimal> amuseParkOutingsCost = _outingRepo.GetCostOfAmusementParkOutings();
                    PrintTotalCost(EventType.AmusementPark, amuseParkOutingsCost);
                    break;
                case "4":
                    List<decimal> concertOutingsCost = _outingRepo.GetCostOfConcertOutings();
                    PrintTotalCost(EventType.Concert, concertOutingsCost);
                    break;
                default:
                    _con.InvalidInput();
                    Continue();
                    break;
            }
        }
        private void DisplayCostOfAllOutings()
        {
            List<decimal> costOfAllOutings = _outingRepo.GetCostOfAllOutings();
            PrintTotalCostOfAllOutings(costOfAllOutings);
        }
        private void CreateOuting(int eventInput)
        {
            DateTime eventDate = EventDate();
            InvalidDate(eventDate);
            int attendance = Attendance();
            InvalidAttendance(attendance);
            switch (eventInput)
            {
                case 1:
                    CreateGolfOuting(eventDate, attendance);
                    break;
                case 2:
                    CreateBowlingOuting(eventDate, attendance);
                    break;
                case 3:
                    CreateAmuseParkOuting(eventDate, attendance);
                    break;
                case 4:
                    CreateConcertOuting(eventDate, attendance);
                    break;
            }
        }
        private void CreateGolfOuting(DateTime eventDate, int attendance)
        {
            GolfOuting outing = new GolfOuting(attendance, eventDate);
            _outingRepo._listOfGolfOutings.Add(outing);
            bool successfulAdd = _outingRepo.AddOutingToOutingList(outing);
            AddedBool(successfulAdd);
        }
        private void CreateBowlingOuting(DateTime eventDate, int attendance)
        {      
            BowlingOuting outing = new BowlingOuting(attendance, eventDate);
            _outingRepo._listOfBowlingOutings.Add(outing);
            bool successfulAdd = _outingRepo.AddOutingToOutingList(outing);
            AddedBool(successfulAdd);
        }
        private void CreateAmuseParkOuting(DateTime eventDate, int attendance)
        {
            AmusementParkOuting outing = new AmusementParkOuting(attendance, eventDate);
            _outingRepo._listOfAmuseParkOutings.Add(outing);
            bool successfulAdd = _outingRepo.AddOutingToOutingList(outing);
            AddedBool(successfulAdd);
        }
        private void CreateConcertOuting(DateTime eventDate, int attendance)
        {
            ConcertOuting outing = new ConcertOuting(attendance, eventDate);
            _outingRepo._listOfConcertOutings.Add(outing);
            bool successfulAdd = _outingRepo.AddOutingToOutingList(outing);
            AddedBool(successfulAdd);
        }
        private DateTime EventDate()
        {
            _con.Write("Enter the year that the event occurred (YYYY):\n");
            string year = _con.ReadLine();
            _con.Write("Enter the month that the event occurred (MM):\n");
            string month = _con.ReadLine();
            _con.Write("Enter the day of the month that the event occurred (DD):\n");
            string day = _con.ReadLine();
            string date = $"{month}/{day}/{year}";
            DateTime eventDate;
            if (DateTime.TryParse(date, out eventDate))
            {
                return eventDate;
            }
            else
            {
                return DateTime.MaxValue;
            }
        }
        private int Attendance()
        {
            _con.Write("Enter the number of people who attended/will attend the event:\n");
            string attendanceAsString = _con.ReadLine();
            int attendance;
            int.TryParse(attendanceAsString, out attendance);
            return attendance;
        }
        private void AddedBool(bool successfulAdd)
        {
            if (successfulAdd == true)
            {
                SuccessfulAdd();
            }
            else UnsuccessfulAdd();
        }
        private void SuccessfulAdd()
        {
            _con.Write("The outing was successfully created!");
            Continue();
        }
        private void UnsuccessfulAdd()
        {
            _con.Write("Something went wrong. The outing could not be successfully created.");
            Continue();
        }
        private void PrintTotalCost(EventType eventType, List<decimal> outing)
        {
            decimal outingCostTotal = _outingRepo.ReturnSumOfTotalCost(outing);
            _con.Write($"The total for all {eventType} events is ${outingCostTotal}\n");
            Continue();
        }
        private void PrintTotalCostOfAllOutings(List<decimal> outing)
        {
            decimal outingCostTotal = _outingRepo.ReturnSumOfTotalCost(outing);
            _con.Write($"The total for all outings is ${outingCostTotal}\n");
            Continue();
        }
        private void InvalidDate(DateTime dateTime)
        {
            DateTime startDate = new DateTime(0001, 01, 01, 00, 00, 00);
            if (dateTime == startDate)
            {
                UnsuccessfulAdd();
            }
            else if (dateTime > DateTime.Now)
            {
                UnsuccessfulAdd();
            }
        }
        private void InvalidAttendance(int attendance)
        {
            if (attendance <= 0)
            {
                UnsuccessfulAdd();
            }
        }
        private void Continue()
        {
            _con.AnyKey();
            _con.ReadKey();
            RunMenu();
        }
        private void ExitApplication()
        {
            _isRunning = false;
        }
        private void SeedList()
        {
            DateTime bowlingTripJanuaryDate = new DateTime(2019, 1, 21);
            BowlingOuting bowlingTripJanuary = new BowlingOuting(25, bowlingTripJanuaryDate);
            DateTime golfTripMayDate = new DateTime(2019, 5, 30);
            GolfOuting golfTripMay = new GolfOuting(15, golfTripMayDate);
            DateTime golfTripJuneDate = new DateTime(2019, 6, 14);
            GolfOuting golfTripJune = new GolfOuting(20, golfTripJuneDate);
            DateTime concertTripJulyDate = new DateTime(2019, 7, 15);
            ConcertOuting concertTripJuly = new ConcertOuting(36, concertTripJulyDate);
            DateTime amuseParkTripAugustDate = new DateTime(2019, 8, 20);
            AmusementParkOuting amuseParkTripAugust = new AmusementParkOuting(27, amuseParkTripAugustDate);
            _outingRepo._listOfBowlingOutings.Add(bowlingTripJanuary);
            _outingRepo._listOfGolfOutings.Add(golfTripMay);
            _outingRepo._listOfGolfOutings.Add(golfTripJune);
            _outingRepo._listOfConcertOutings.Add(concertTripJuly);
            _outingRepo._listOfAmuseParkOutings.Add(amuseParkTripAugust);
            _outingRepo._listOfOutings.Add(bowlingTripJanuary);
            _outingRepo._listOfOutings.Add(golfTripMay);
            _outingRepo._listOfOutings.Add(golfTripJune);
            _outingRepo._listOfOutings.Add(concertTripJuly);
            _outingRepo._listOfOutings.Add(amuseParkTripAugust);
        }
    }
}
