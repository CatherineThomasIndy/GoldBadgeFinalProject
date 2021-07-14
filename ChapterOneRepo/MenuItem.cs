using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapterOneRepo
{
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public decimal Price { get; set; }

        public Menu(){ }

        public Menu(int mealNumber, string mealName, string description, decimal price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Price = price;
        }
    }
}
