using System;
using System.Collections.Generic;
using Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cafe_Tests
{
    [TestClass]
    public class MenuItem_RepoTests
    {
        [TestMethod]
        public void AddToRepo_ShouldGetCorrectBool() //Create
        {
            //Arrange
            MenuItem item = new MenuItem();
            MenuItem_Repo menu = new MenuItem_Repo();
            //Act
            bool addResult = menu.AddMenuItem(item);

            //Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetMenu_ShouldReturnCorrectCollection()//Read
        {
            //Arrange
            MenuItem item = new MenuItem();
            MenuItem_Repo menu = new MenuItem_Repo();
            menu.AddMenuItem(item);
            //Act
            List<MenuItem> menuItems = menu.GetMenu();
            bool menuHasItems = menuItems.Contains(item);

            //Assert
            Assert.IsTrue(menuHasItems);
        }

        [TestMethod]
        public void GetMenuByMealNum_ShouldReturnCorrectMenuItem()//Read
        {
            //Arrange
            MenuItem_Repo menu = new MenuItem_Repo();
            MenuItem item = new MenuItem(01, 
                "Burger and Fries", 
                "Our delicious all beef burger and a medium fry", 
                "Bun, Burger, Pickles, Onion, Lettuce, Tomato, Fries", 
                8);
            menu.AddMenuItem(item);
            int mealNum = 01;
            //Act
            MenuItem searchResult = menu.GetMenuItemByMealNum(mealNum);

            //Assert
            Assert.AreEqual(searchResult.MealNumber, mealNum);

        }

        [TestMethod]
        public void UpdateExistingMenuItem_ShouldReturnTrue() //Update
        {
            //Arrange
            MenuItem_Repo menu = new MenuItem_Repo();
            MenuItem oldItem = new MenuItem(01,
                "Burger and Fries",
                "Our delicious all beef burger and a medium fry",
                "Bun, Burger, Pickles, Onion, Lettuce, Tomato, Fries",
                8);
            menu.AddMenuItem(oldItem);
            MenuItem newItem = new MenuItem(02,
                        "Bacon Cheese Burger and Fries",
                        "Our delicious all beef burger and a medium fry",
                        "Bun, Burger, Bacon, Cheese, Pickles, Onion, Lettuce, Tomato, Fries",
                         10);
            //Act
            bool updateResult = menu.UpdateExistingMenuItem(oldItem.MealNumber, newItem);

            //Assert
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue() //Delete
        {
            //Act
            MenuItem_Repo menu = new MenuItem_Repo();
            MenuItem item = new MenuItem(01,
                "Burger and Fries",
                "Our delicious all beef burger and a medium fry",
                "Bun, Burger, Pickles, Onion, Lettuce, Tomato, Fries",
                8);
            menu.AddMenuItem(item);
            int mealNum = 01;

            //Act
            MenuItem oldItem = menu.GetMenuItemByMealNum(mealNum);
            bool removeResult = menu.DeleteMenuItem(oldItem);

            //Assert
            Assert.IsTrue(removeResult);

        }
    }
}
