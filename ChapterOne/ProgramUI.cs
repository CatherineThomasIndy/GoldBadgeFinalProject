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
            _con.Clear();
            List<Menu> menuItems = _menuRepo.GetAllMenuItems();
            foreach(Menu item in menuItems)
            {
                Console.WriteLine($"Number: {item.MealNumber}\n" +
                    $"Name: {item.MealName}\n" +
                    $"Description: {item.Description}\n" +
                    $"Ingredients: {item.Ingredients}\n" +
                    $"Price: {item.Price}\n");
            }
            _con.AnyKey();
            _con.ReadKey();
            RunMenu();
        }
        //public Menu(int mealNumber, string mealName, string description, List<string> ingredients, decimal price)
        private void AddNewMeal()
        {
            _con.Clear();
            _con.Write("What is the name of the new meal?\n");
            string mealName = _con.ReadLine();
            _con.Write("Describe the new meal:\n");
            string description = _con.ReadLine();
            _con.Write("List each ingredient in the meal separated by commas (ex: 'cheese,pasta,tomato' etc.):\n");
            string ingredientString = _con.ReadLine();
            List<string> ingredients = ingredientString.Split(',').ToList();
            _con.Write("Enter the price of the new meal:\n");
            decimal price = decimal.Parse(_con.ReadLine());
            List<Menu> menuItemList = _menuRepo.GetList();
            int menuCount = menuItemList.Count;
            int mealNumber = menuCount + 1;
            Menu item = new Menu(mealNumber, mealName, description, ingredients, price);
            _menuRepo.AddItemToMenu(item);
            if (menuItemList.Contains(item))
            {
                _con.Write("The new meal was successfully added!");
                _con.AnyKey();
                RunMenu();
            }
            else
            {
                _con.Write("Something went wrong. The meal could not be added.");
                _con.AnyKey();
                RunMenu();
            }

        }

        private void RemoveMeal()
        {

        }
    }
}
