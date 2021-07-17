using ChallengeTwoApp.Consoles;
using ChallengeTwoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoApp
{
    public class ProgramUI
    {
        private bool _isRunning = true;
        private ICustomConsole _con;
        private readonly ClaimRepository _claimRepo = new ClaimRepository();
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
                    PrintAllClaims();
                    break;
                case "2":
                    GetNextClaim();
                    break;
                case "3":
                    CreateNewClaim();
                    break;
                case "4":
                    ExitApplication();
                    break;
                default:
                    _con.InvalidInput();
                    _con.AnyKey();
                    _con.ReadKey();
                    RunMenu();
                    break;
            }
        }
        
        private void PrintAllClaims()
        {
            _con.Clear();
            List<Claim> claims = _claimRepo.GetAllClaims();
            _con.Write("Claim ID | Claim Type | Description | Amount | Date of Accident | Date of Claim | Is Valid?");
            foreach (Claim claim in claims)
            {
                _con.Write($"{claim.ClaimID} | {claim.ClaimID} | {claim.Description} | {claim.Amount} | {claim.DateOfAccident} | {claim.DateOfClaim} | {claim.IsValid}");
            }
            _con.AnyKey();
            _con.ReadKey();
            RunMenu();
        }
        private void GetNextClaim()
        {
            _con.Clear();
            Claim nextClaim = _claimRepo.GetNextClaim();
            _con.Write($"Claim ID: {nextClaim.ClaimID}\n" +
                $"Claim Type: {nextClaim.ClaimType}\n" +
                $"Description: {nextClaim.Description}\n" +
                $"Amount: {nextClaim.Amount}\n" +
                $"Date of Accident: {nextClaim.DateOfAccident.ToString("MM/dd/yyyy/")}\n" +
                $"Date of Claim: {nextClaim.DateOfClaim.ToString("MM/dd/yyyy")}\n" +
                $"Is Valid: {nextClaim.IsValid}\n" +
                $"\nWould you like to take care of this claim now? (y/n)\n");
            string takeClaim = _con.ReadLine();
            switch (takeClaim)
            {
                case "y":
                    bool deleted = _claimRepo.DeleteClaim(nextClaim);
                    if (deleted)
                    {
                        _con.Write("The claim has been successfully removed from the queue to be processed.");
                        _con.AnyKey();
                        _con.ReadKey();
                        RunMenu();
                    }
                    break;
                case "n":
                    _con.Write("This claim will stay in the queue.");
                    _con.AnyKey();
                    _con.ReadKey();
                    RunMenu();
                    break;
                default:
                    _con.InvalidInput();
                    _con.AnyKey();
                    _con.ReadKey();
                    RunMenu();
                    break;
            }
        }
        private void CreateNewClaim()
        {
            Claim newClaim = new Claim();
            _con.Write("Enter a claim ID for the new claim:");
            string idInput = _con.ReadLine();
            int claimID = 
                CreateNewClaimID(idInput);
            if(claimID <= 0)
            {
                _con.Write("Please only enter a positive whole number that isn't already used by another claim.");
                _con.AnyKey();
                _con.ReadKey();
                RunMenu();
            }
            _con.Write("Enter the claim type:\n" +
                "1. Car\n" +
                "2. Theft\n" +
                "3. Home\n");
            newClaim.ClaimID = claimID;
            int typeInput;
            int.TryParse(_con.ReadLine(), out typeInput);
            if(typeInput <= 0 || typeInput > 3)
            {
                _con.InvalidInput();
                _con.AnyKey();
                _con.ReadKey();
                RunMenu();
            }
            newClaim.ClaimType = (ClaimType)typeInput;
            _con.Write("Enter a description of the incident:");
            string description = _con.ReadLine();
            if(description == "")
            {
                _con.Write("You didn't enter anything!");
                _con.AnyKey();
                _con.ReadKey();
                RunMenu();
            }
            newClaim.Description = description;
            _con.Write("Enter the amount the claim is worth:");
            string amountAsString = _con.ReadLine();
            decimal amount;
            decimal.TryParse(amountAsString, out amount);
            if(amount <= 0)
            {
                UnsuccessfulAdd();
            }
            DateTime dateOfIncident = IncidentDate();
            DateTime dateOfClaim = ClaimDate();
            InvalidDate(dateOfIncident);
            InvalidDate(dateOfClaim);
            newClaim.DateOfAccident = dateOfIncident;
            newClaim.DateOfClaim = dateOfClaim;
            bool added = _claimRepo.AddClaimToQueue(newClaim);
            if (added)
            {
                _con.Write("The claim was successfully created!");
                _con.AnyKey();
                _con.ReadKey();
                RunMenu();
            }
            else
            {
                _con.Write("Something went wrong. The claim could not be created.");
                _con.AnyKey();
                _con.ReadKey();
                RunMenu();
            }
        }
        private int CreateNewClaimID(string input)
        {
            int claimID;
            int.TryParse(input, out claimID);
            bool claimExists = _claimRepo.ClaimIDExists(claimID);
            if (claimExists == true)
            {
                return 0;
            }
            else return claimID;
            
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
        private void UnsuccessfulAdd()
        {
            _con.Write("Something went wrong. The claim could not be successfully created.");
            _con.AnyKey();
            _con.ReadKey();
            RunMenu();
        }
        private DateTime IncidentDate()
        {
            _con.Write("Enter the year that the incident occurred (YYYY):\n");
            string year = _con.ReadLine();
            _con.Write("Enter the month that the incident occurred (MM):\n");
            string month = _con.ReadLine();
            _con.Write("Enter the day of the month that the incident occurred (DD):\n");
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
        private DateTime ClaimDate()
        {
            _con.Write("Enter the year that the claim was made (YYYY):\n");
            string year = _con.ReadLine();
            _con.Write("Enter the month that the claim was made (MM):\n");
            string month = _con.ReadLine();
            _con.Write("Enter the day of the month that the claim was made (DD):\n");
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
        private void ExitApplication()
        {
            _con.Write("Good-bye!");
            _con.ReadKey();
            _isRunning = false;
        }
        private void SeedList()
        {
            DateTime carIncident = new DateTime(2021, 03, 17);
            DateTime carClaim = new DateTime(2021, 03, 18);
            DateTime theftIncident = new DateTime(2021, 05, 30);
            DateTime theftClaim = new DateTime(2021, 6, 3);
            DateTime homeIncident = new DateTime(2021, 6, 3);
            DateTime homeClaim = new DateTime(2021, 7, 13);
            Claim carCollisionClaim = new Claim(1, ClaimType.Car, "A collision with no injuries and light damage to bumper.", 500.00m, carIncident, carClaim);
            Claim theftOfJewelryClaim = new Claim(2, ClaimType.Theft, "Client's sister stole client's diamond necklace and sold it to an unknown party.", 800.00m, theftIncident, theftClaim);
            Claim homeGardenDamage = new Claim(3, ClaimType.Home, "Client's garden was destroyed by wild rabbits.", 100.00m, homeIncident, homeClaim);
            _claimRepo.AddClaimToQueue(carCollisionClaim);
            _claimRepo.AddClaimToQueue(theftOfJewelryClaim);
            _claimRepo.AddClaimToQueue(homeGardenDamage);
        }
    }
}
