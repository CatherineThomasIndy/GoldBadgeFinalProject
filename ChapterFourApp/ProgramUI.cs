using ChapterFourApp.Consoles;
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
        public ProgramUI(ICustomConsole console)
        {
            _con = console;
        }

        public void Run()
        {
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
        /*"Welcome to the Komodo Outings screen.\n" +
                "Select a menu item by entering the number of the menu item you wish to open.\n" +
                "1. Display a list of all outings\n" +
                "2. Add an individual outing\n" +
                "3. Display the total cost of all outings by type\n" +
                "4. Display the cost of all outings\n" +
                "5. Exit the app\n"*/
        private void OpenMenuItem(string userInput)
        {
            _con.Clear();

            switch (userInput)
            {
                case "1":
                    DisplayAllOutings();
                    break;
                case "2":
                    CreateAnOuting();
                    break;
                case "3":
                    DisplayCostOfAllOutingsByType();
                    break;
                case "4":
                    DisplayCostOfAllOutings();
                    break;
                case "5":
                    _con.Write("Good-bye!");
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

        private void DisplayAllOutings()
        {

        }

        private void CreateAnOuting()
        {

        }

        private void DisplayCostOfAllOutingsByType()
        {

        }

        private void DisplayCostOfAllOutings()
        {

        }


    }
}
