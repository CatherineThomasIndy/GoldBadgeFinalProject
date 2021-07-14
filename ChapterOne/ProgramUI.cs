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
            PrintMenuItems();
            _con.AnyKey();
            _con.ReadKey();
            RunMenu();
        }

        private void PrintMenuItems()
        {
            _con.Clear();
            List<Menu> menuItems = _menuRepo.GetAllMenuItems();
            foreach (Menu item in menuItems)
            {
                Console.WriteLine($"Number: {item.MealNumber}\n" +
                    $"Name: {item.MealName}\n" +
                    $"Description: {item.Description}\n" +
                    $"Ingredients: {item.Ingredients}\n" +
                    $"Price: {item.Price}\n");
            }
        }
        //public Menu(int mealNumber, string mealName, string description, List<string> ingredients, decimal price)
        private void AddNewMeal()
        {
            _con.Clear();
            _con.Write("What is the name of the new meal?\n");
            string mealName = _con.ReadLine();
            _con.Write("Describe the new meal:\n");
            string description = _con.ReadLine();
            _con.Write("Enter the price of the new meal (ex: 12.34 for $12.34):\n");
            string priceAsString = _con.ReadLine();
            decimal price;
            decimal.TryParse(priceAsString, out price);
            List<Menu> menuItemList = _menuRepo.GetAllMenuItems();
            int menuCount = menuItemList.Count;
            int mealNumber = menuCount + 1;
            Menu item = new Menu(mealNumber, mealName, description, price);
            _menuRepo.AddItemToMenu(item);
            if (menuItemList.Contains(item))
            {
                _con.Write("The new meal was successfully added!\n");
                _con.AnyKey();
                _con.ReadKey();
                RunMenu();
            }
            else
            {
                _con.Write("Something went wrong. The meal could not be added.\n");
                _con.AnyKey();
                _con.ReadKey();
                RunMenu();
            }

        }

        private void RemoveMeal()
        {
            List<Menu> listOfMenuItems = _menuRepo.GetAllMenuItems();
            int initialMenuItemCount = listOfMenuItems.Count;
            PrintMenuItems();
            _con.Write("Enter the meal number of the meal you would like to remove from the menu:\n");
            string mealToDeleteAsString = _con.ReadLine();
            int mealToDelete;
            int.TryParse(mealToDeleteAsString, out mealToDelete);j
            Menu item = _menuRepo.GetMenuItemByMenuItemNumber(mealToDelete);
            if (item != null)
            {
                _menuRepo.DeleteMenuItemByNumber(mealToDelete);
                List<Menu> updatedListOfMenuItems = _menuRepo.GetAllMenuItems();
                int updatedMenuItemCount = updatedListOfMenuItems.Count;
                if (updatedMenuItemCount == initialMenuItemCount - 1)
                {
                    _con.Write("The meal was successfully removed from the menu!\n");
                    _con.AnyKey();
                    _con.ReadKey();
                    RunMenu();
                }
                else
                {
                    _con.Write("Something went wrong. The meal could not be removed from the menu.\n");
                    _con.AnyKey();
                    _con.ReadKey();
                    RunMenu();
                }
            }
            else
            {
                _con.Write("Something went wrong. The meal could not be removed from the menu.\n");
                _con.AnyKey();
                RunMenu();
            }
        }

        private void AddIngredients()
        {
            List<Menu> listOfMenuItems = _menuRepo.GetAllMenuItems();
            PrintMenuItems();
            _con.Write("Enter the meal number of the meal to which you would like to add ingredients:\n");
            int mealForIngredientsToAdd = int.Parse(_con.ReadLine());
            Menu item = _menuRepo.GetMenuItemByMenuItemNumber(mealForIngredientsToAdd);
            if (item != null)
            {
                List<string> listOfIngredients = new List<string>();
                _con.Write("Enter an ingredient:\n");
                string firstIngredient = _con.ReadLine();
                listOfIngredients.Add(firstIngredient);
                bool enteringIngredients = true;
                while (enteringIngredients)
                {
                    _con.Write("Would you like to enter another ingredient?\n" +
                        "1. Yes\n" +
                        "2. No\n");
                    string input = _con.ReadLine();
                    switch (input)
                    {
                        case "1":
                            string nextIngredient = _con.ReadLine();
                            listOfIngredients.Add(nextIngredient);
                            return;
                        case "2":
                            enteringIngredients = false;
                            break;
                        default:
                            _con.InvalidSelection();
                            _con.AnyKey();
                            _con.ReadKey();
                            RunMenu();
                            break;
                    }
                }
                item.Ingredients = listOfIngredients;
            }
            else
            {
                _con.Write("That meal isn't on the menu.");
                _con.AnyKey();
                _con.ReadKey();
                RunMenu();
            }
        }

        private void SeedList()
        {
            Menu hamburger = new Menu(1, "Hamburger", "A beef patty on a bun with customizable fixins.", 5.00m);
            _menuRepo.AddItemToMenu(hamburger);
        }
    }
}
