using ChapterOne.Consoles;
using ChapterOneRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapterOne
{
    public class ProgramUI
    {
        private bool _isRunning = true;
        private readonly ICustomConsole _con;
        private readonly MenuRepository _menuRepo = new MenuRepository();
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

        private void OpenMenuItem(string userInput)
        {
            _con.Clear();
            /*"1. See the full list of menu items.\n" +
                "2. Add a new meal to the menu.\n" +
                "3. Remove a meal from the menu.\n" +
                "4. Exit program.*/
            switch (userInput)
            {
                case "1":
                    SeeFullMenu();
                    _con.AnyKey();
                    _con.ReadKey();
                    RunMenu();
                    break;
                case "2":
                    AddNewMeal();
                    break;
                case "3":
                    RemoveMeal();
                    break;
                case "4":
                    _con.Write("Do you really want to exit? (y/n)\n");
                    string reallyExit = _con.ReadLine().ToLower();
                    if (reallyExit == "y")
                    {
                        _con.Write("Good-bye!");
                        _con.ReadKey();
                        _isRunning = false;
                    }
                    else if (reallyExit == "n")
                    {
                        _con.AnyKey();
                        _con.ReadKey();
                        RunMenu();
                    }
                    else
                    {
                        _con.InvalidSelection();
                        _con.AnyKey();
                        _con.ReadKey();
                        RunMenu();
                    }
                    break;
                default:
                    _con.InvalidSelection();
                    _con.AnyKey();
                    _con.ReadKey();
                    RunMenu();
                    break;
            }
        }

        private void SeeFullMenu()
        {

        }

        private void AddNewMeal()
        {

        }

        private void RemoveMeal()
        {

        }
    }
}
