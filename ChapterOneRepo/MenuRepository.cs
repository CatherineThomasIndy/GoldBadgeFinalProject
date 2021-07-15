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

        public List<Menu> GetAllMenuItems()
        {
            return _menuItems;
        }

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
