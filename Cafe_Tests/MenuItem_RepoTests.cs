using System;
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
    }
}
