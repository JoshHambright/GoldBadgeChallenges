using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class MenuItem_Repo
    {
        //Repo Field
        private List<MenuItem> _menu = new List<MenuItem>();

        //Create
        public bool AddMenuItem(MenuItem item)
        {
            int startingCount = _menu.Count;

            _menu.Add(item);
            bool wasAdded = (_menu.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Read

        //  Get all MenuItems in the Menu
        public List<MenuItem> GetMenu()
        {
            return _menu;
        }

        //  Get MenuItem by Meal Number
        public MenuItem GetMenuItemByMealNum(int mealNum)
        {
            foreach (MenuItem menuItem in _menu)
            {
                if (menuItem.MealNumber == mealNum)
                {
                    return menuItem;
                }
            }
            return null;
        }


        //Update

        public bool UpdateExistingMenuItem(int oldMealNum, MenuItem newItem)
        {
            MenuItem oldMenuItem = GetMenuItemByMealNum(oldMealNum);

            if (oldMenuItem != null)
            {
                oldMenuItem.MealNumber = newItem.MealNumber;
                oldMenuItem.MealName = newItem.MealName;
                oldMenuItem.Description = newItem.Description;
                oldMenuItem.Ingredients = newItem.Ingredients;
                oldMenuItem.Price = newItem.Price;
                return true;
            }
            else { return false; }
        }

        //Delete
        public bool DeleteMenuItem(MenuItem item)
        {
            bool deleteItem = _menu.Remove(item);
            return deleteItem;
        }


    }
}
