using Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_UI
{
    public class ProgramUI
    {
        //Menu Repo
        private MenuItem_Repo _menu = new MenuItem_Repo();


        //Methods
        public void Run()
        {
            SeedItemMenu();
            MainMenu();
        }

        public void SeedItemMenu()
        {
            //Seed content for menu
            //Arrange
            MenuItem meal1 = new MenuItem(01,
                "Burger and Fries",
                "Our delicious all beef burger and a medium fry",
                "Bun, Burger, Pickles, Onion, Lettuce, Tomato, Fries",
                8);
            MenuItem meal2 = new MenuItem(02,
                "Double Chese Burger with Fries",
                "Double the burger and double the fun!",
                "Bun, Burger,Cheese, Pickles, Onion, Lettuce, Tomato, Fries",
                8);
            MenuItem meal3 = new MenuItem(03,
                "Pork Tenderloin and Fries",
                "Breaded and fried pork Tenderloin with a side of fries",
                "Bun, Fried Tenderloin, Pickles, Onion, Lettuce, Tomato, Fries",
                8);

            _menu.AddMenuItem(meal1);
            _menu.AddMenuItem(meal2);
            _menu.AddMenuItem(meal3);
        }

        public void MainMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Header();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("-- Main Menu --");
                Console.WriteLine("1> View Cafe Menu Items");
                Console.WriteLine("2> Add New Cafe Menu Item");
                Console.WriteLine("3> Update Existing Cafe Menu Item");
                Console.WriteLine("4> Delete Cafe Menu Item");
                Console.WriteLine("5> Exit Cafe Menu");
                Console.WriteLine("Please enter a number to proceed:");
                string menuSelection = Console.ReadLine();

                switch (menuSelection)
                {
                    case "1":
                        ShowMenu();
                        break;
                    case "2":
                        AddNewItem();
                        break;
                    case "3":
                        UpdateMenuItem();
                        break;
                    case "4":
                        DeleteItem();
                        break;
                    case "5":
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public void Header()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("+-++-++-++-++-++-+ +-++-++-++-+");
            Console.WriteLine("|K||o||m||o||d||o| |C||a||f||e|");
            Console.WriteLine("+-++-++-++-++-++-+ +-++-++-++-+");
            Console.ResetColor();

        }

        public void ShowMenu()
        {
            Console.Clear();
            Header();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--- Displaying all Menu Items ---");
            List<MenuItem> menuItems = _menu.GetMenu();

            foreach (MenuItem item in menuItems)
            {
                Console.WriteLine("Meal #:            " + item.MealNumber);
                Console.WriteLine("Meal Name:         " + item.MealName);
                Console.WriteLine("Meal Description:  " + item.Description);
                Console.WriteLine("Meal Ingredients:  " + item.Ingredients);
                Console.WriteLine("Meal Price:        $" + item.Price);
                Console.WriteLine("");
            }

            Console.WriteLine("Press Enter to return to main menu.");
            Console.ReadKey();
        }

        public void AddNewItem()
        {
            MenuItem newItem = new MenuItem();
            bool looper = true;

            while (looper)
            {

                Console.Clear();
                Header();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("-- Adding New Menu Item --");
                Console.WriteLine("Enter Meal #:");
                newItem.MealNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Meal Name:");
                newItem.MealName = Console.ReadLine();
                Console.WriteLine("Enter Meal Description:");
                newItem.Description = Console.ReadLine();
                Console.WriteLine("Enter list of meal ingredients:");
                newItem.Ingredients = Console.ReadLine();
                Console.WriteLine("Enter price of meal:");
                newItem.Price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("-- New Item --");
                Console.WriteLine("Meal #:            " + newItem.MealNumber);
                Console.WriteLine("Meal Name:         " + newItem.MealName);
                Console.WriteLine("Meal Description:  " + newItem.Description);
                Console.WriteLine("Meal Ingredients:  " + newItem.Ingredients);
                Console.WriteLine("Meal Price:        $" + newItem.Price);
                Console.WriteLine("");
                Console.WriteLine("Is the new menu item correct? \nEnter Y to continue adding New Item to the menu. Enter N to start over creating New Item.");
                string isCorrect = Console.ReadLine();
                if (isCorrect.ToLower() == "y")
                {
                    looper = false;
                }
            }
            bool wasAdded = _menu.AddMenuItem(newItem);
            if (wasAdded == true)
            {
                Console.WriteLine("Menu Item added successfully");
                Console.WriteLine("Press any key to return to the main menu");
            }
            else
            {
                Console.WriteLine("Oops! Something went wrong. Your new item was not added to the menu. Please try again.");
                Console.WriteLine("Press any key to return to the main menu");
            }

            Console.ReadKey();

        }

        public void UpdateMenuItem()
        {
            MenuItem oldItem = new MenuItem();
            Console.Clear();
            Header();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-- Update Existing Menu Item --");
            Console.WriteLine("Enter the Meal # for the Menu Item you'd like to update:");
            int oldMenuNum = Convert.ToInt32(Console.ReadLine());
            oldItem = _menu.GetMenuItemByMealNum(oldMenuNum);
            bool looper = true;
            while (looper)
            {
                Console.Clear();
                Console.WriteLine("-- Menu Item --");
                Console.WriteLine("1> Meal #:            " + oldItem.MealNumber);
                Console.WriteLine("2> Meal Name:         " + oldItem.MealName);
                Console.WriteLine("3> Meal Description:  " + oldItem.Description);
                Console.WriteLine("4> Meal Ingredients:  " + oldItem.Ingredients);
                Console.WriteLine("5> Meal Price:        $" + oldItem.Price);
                Console.WriteLine("6> Done Editing");
                Console.WriteLine("Please enter the number for the value you'd like to edit");
                string menuSelection = Console.ReadLine();
                switch (menuSelection)
                {
                    case "1":
                        Console.WriteLine("Enter new Meal #:");
                        oldItem.MealNumber = Convert.ToInt32(Console.ReadLine());
                        break;
                    case "2":
                        Console.WriteLine("Enter new Name:");
                        oldItem.MealName = Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Enter new meal Description:");
                        oldItem.Description = Console.ReadLine();
                        break;
                    case "4":
                        Console.WriteLine("Enter new Ingredients:");
                        oldItem.Ingredients = Console.ReadLine();
                        break;
                    case "5":
                        Console.WriteLine("Enter new Price:");
                        oldItem.Price = Convert.ToDouble(Console.ReadLine());
                        break;
                    case "6":
                        looper = false;
                        break;
                }
            }
            bool wasUpdate = _menu.UpdateExistingMenuItem(oldMenuNum, oldItem);
            if (wasUpdate == true)
            {
                Console.WriteLine("Menu Item updated. \nPress any key to continue");
            }
            else
            {
                Console.WriteLine("Oops. Something went wrong. Please try updating again. \nPress any key to continue");
            }

            Console.ReadKey();



        }

        public void DeleteItem()
        {
            MenuItem oldItem = new MenuItem();
            Console.Clear();
            Header();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-- Deleting Item --");
            Console.WriteLine("Enter the Meal # of the item you'd like to delete:");
            int mealNum = Convert.ToInt32(Console.ReadLine());
            oldItem = _menu.GetMenuItemByMealNum(mealNum);
            Console.WriteLine("-- Menu Item To Delete --");
            Console.WriteLine("Meal #:            " + oldItem.MealNumber);
            Console.WriteLine("Meal Name:         " + oldItem.MealName);
            Console.WriteLine("Meal Description:  " + oldItem.Description);
            Console.WriteLine("Meal Ingredients:  " + oldItem.Ingredients);
            Console.WriteLine("Meal Price:        $" + oldItem.Price);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!!!!! WARNING DELETE CAN NOT BE UNDONE !!!!!  \nDo you want to continue Deleting this item?");
            Console.WriteLine("Enter Y to to continue deleting this Item. Enter N to return to the main menu.");
            Console.ResetColor();
            string deleteConfirm = Console.ReadLine();
            if (deleteConfirm.ToLower() == "y")
            {
                bool deleteResult = _menu.DeleteMenuItem(oldItem);
                if (deleteResult == true)
                {
                    Console.WriteLine("Item deleted Successfully.");
                    Console.WriteLine("Press any key to continue.");

                }
                else
                {
                    Console.WriteLine("Something went wrong. Please try again.");
                    Console.WriteLine("Press any key to continue.");

                }
            }
            else
            {
                Console.WriteLine("Delete Canceled. \nPress any Key to return to main menu.");

            }
            Console.ReadKey();
        }
    }
}
