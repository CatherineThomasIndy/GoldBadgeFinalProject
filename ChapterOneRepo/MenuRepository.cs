using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapterOneRepo
{
    public class MenuRepository
    {
        public List<Menu> _menuItems = new List<Menu>();

        //Create a menu item
        public bool AddItemToMenu(Menu item)
        {
            int menuItemsCount = _menuItems.Count();
            _menuItems.Add(item);
            if (_menuItems.Count() == menuItemsCount + 1)
            {
                return true;
            }
            else return false;
        }

        //Receive a list of all items
        public List<Menu> GetAllMenuItems()
        {
            return _menuItems;
        }

        //Get menu item by menu number
        public Menu GetMenuItemByMenuItemNumber(int menuItemNumber)
        {
            foreach (Menu item in _menuItems)
            {
                if (item.MealNumber == menuItemNumber)
                {
                    return item;
                }
            }
            return null;
        }

        //Delete menu items
        public bool DeleteMenuItem(Menu item)
        {
            return _menuItems.Remove(item);
        }

        public bool DeleteMenuItemByNumber(int menuItemNumber)
        {
            Menu item = GetMenuItemByMenuItemNumber(menuItemNumber);
            return DeleteMenuItem(item);
        }
    }
}
