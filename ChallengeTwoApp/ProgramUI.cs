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
                    _isRunning = false;
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
            foreach (Claim claim in claims)
            {

            }
            _con.AnyKey();
            _con.ReadKey();
            RunMenu();
        }
        private void GetNextClaim()
        {

        }
        private void CreateNewClaim()
        {

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
