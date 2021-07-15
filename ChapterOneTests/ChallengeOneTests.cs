using ChapterOneRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChapterOneTests
{
    [TestClass]
    public class ChallengeOneTests
    {
        private MenuRepository _menuRepo;
        private Menu _menuItem;

        [TestInitialize]
        public void Initialize()
        {
            _menuRepo = new MenuRepository();
            List<string> hamburgerIngredients = new List<string> { "beef", "hamburger bun" };
            _menuItem = new Menu(1, "Hamburger", "A sandwich of a beef patty on a round bun.", hamburgerIngredients, 5.00m);
            _menuRepo.AddItemToMenu(_menuItem);
        }

        [TestMethod]
        public void AddItemToMenu_ShouldReturnTrue()
        {
            Menu item = new Menu();
            bool addItemResult = _menuRepo.AddItemToMenu(item);
            Assert.IsTrue(addItemResult);
        }

        [TestMethod]
        public void GetAllMenuItems_ShouldReturnTrue()
        {
            List<Menu> menuList = _menuRepo.GetAllMenuItems();
            Assert.IsInstanceOfType(menuList, typeof(List<Menu>));
        }

        [TestMethod]
        public void GetMenuItemByMenuItemNumber_ShouldReturnIsNotNull()
        {
            Menu item = _menuRepo.GetMenuItemByMenuItemNumber(_menuItem.MealNumber);
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            bool deleteResult = _menuRepo.DeleteMenuItem(_menuItem);
            Assert.IsTrue(deleteResult);
        }

        [TestMethod]
        public void DeleteMenuItemByMenuItemNumber_ShouldReturnTrue()
        {
            bool deleteResult = _menuRepo.DeleteMenuItemByNumber(_menuItem.MealNumber);
            Assert.IsTrue(deleteResult);
        }
    }
}
