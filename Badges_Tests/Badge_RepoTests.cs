using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Badges_Tests
{
    [TestClass]
    public class Badge_RepoTests
    {
        [TestMethod]
        public void AddToRepo_ShouldGetCorrectBool()//Create
        {
            //Arrange
            Badge badge = new Badge(01);
            Badge_Repo repo = new Badge_Repo();

            //Act
            bool addResult = repo.AddBadge(badge);

            //Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetBadges_ShouldReturnCorrectCollection() //Read
        {

            //Arrange
            Badge badge = new Badge(001);
            Badge_Repo repo = new Badge_Repo();
            repo.AddBadge(badge);

            //Act
            Dictionary<int, List<string>> badges = repo.GetAllBadges();
            bool hasBadges = badges.ContainsKey(badge.BadgeID);

            //Assert
            Assert.IsTrue(hasBadges);

        }

        [TestMethod]
        public void GetBadgeByID_ShouldReturnCorrectBadge() //Read
        {
            //Arrange
            Badge badge = new Badge(001, new List<string>{ "A1", "A2" });
            Badge_Repo repo = new Badge_Repo();
            repo.AddBadge(badge);
            int badgeID = 001;
            //Act
            Badge searchResult = repo.GetABadgeByID(badgeID);

            //Assert
            Assert.AreEqual(searchResult.BadgeID, badgeID);
        }

        [TestMethod]
        public void UpdateExistingBadge_ShouldReturnTrue() //Update
        {
            //Arrange
            Badge oldBadge = new Badge(001, new List<string> { "A1", "A2" });
            Badge newBadge = new Badge(001, new List<string> { "A2", "A3", "B5" });
            Badge_Repo repo = new Badge_Repo();
            repo.AddBadge(oldBadge);

            //Act
            bool updateResult = repo.UpdateExistingBadge(oldBadge.BadgeID, newBadge);

            //Assert
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void DeleteBadge_ShouldReturnTrue() //Delete
        {
            //Arrange
            Badge badge = new Badge(001, new List<string> { "A1", "A2" });
            Badge_Repo repo = new Badge_Repo();
            repo.AddBadge(badge);
            int badgeID = 001;
            //Act
            Badge oldBadge = repo.GetABadgeByID(badgeID);
            bool removeResult = repo.DeleteBadge(oldBadge);

            //Assert
            Assert.IsTrue(removeResult);

        }
    }
}
