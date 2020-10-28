using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class MenuItem
    {
        // Properties
        public int MealNumber { get; set; }
        public string MealName { get; set; }

        public string Description { get; set; }

        public string Ingredients { get; set; }
        public double Price { get; set; }


        public MenuItem() { }

        public MenuItem(int mealNum, string mealName, string desc, string ingredients, double price)
        {
            MealNumber = mealNum;
            MealName = mealName;
            Description = desc;
            Ingredients = ingredients;
            Price = price;
        }

    }
}
