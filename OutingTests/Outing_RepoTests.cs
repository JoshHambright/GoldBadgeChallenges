using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Outings;

namespace OutingTests
{
    [TestClass]
    public class Outing_RepoTests
    {
        [TestMethod]
        public void AddToRepo_ShouldGetCorreBool()//Create
        {
            //Arrange
            Outing outing = new Outing();
            Outing_Repo repo = new Outing_Repo();



            //Act
            bool addResult = repo.AddOuting(outing);


            //Assert
            Assert.IsTrue(addResult);
        }


        [TestMethod]
        public void GetOutings_ShouldReturnCorrectCollection() //Read
        {
            //Arrange
            Outing outing = new Outing();
            Outing_Repo repo = new Outing_Repo();
            repo.AddOuting(outing);

            //Act
            List<Outing> outings = repo.GetAllOutings();

            bool repoHasOutings = outings.Contains(outing);
            //Assert
            Assert.IsTrue(repoHasOutings);
        }

        [TestMethod]
        public void GetOutingByDate_ShouldReturnCorrectOuting() //Read
        {
            //Arrange
            Outing_Repo repo = new Outing_Repo();
            Outing outing = new Outing(new DateTime(2008, 3, 15),EventType.Bowling, 100,3000m);
            repo.AddOuting(outing);
            DateTime date = new DateTime(2008, 3, 15);
            //Act
            Outing result = repo.GetOutingByDate(date);
            //Assert
            Assert.AreEqual(result.EventDate, date);
        }

        [TestMethod]
        public void UpdateExistingOuting_ShouldReturnTrue() //Update
        {
            //Arrange
            Outing_Repo repo = new Outing_Repo();
            Outing oldOuting = new Outing(new DateTime(2008, 3, 15), EventType.Bowling, 100, 3000m);
            repo.AddOuting(oldOuting);

            Outing newOuting = new Outing(new DateTime(2008, 3, 15), EventType.AmusementPark, 100, 5000m);

            //Act
            bool updateResult = repo.UpdateExistingOuting(oldOuting.EventDate, newOuting);

            //Assert
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void DeleteExistingOuting_ShouldReturnTrue() //Delete
        {
            //Arrange
            Outing_Repo repo = new Outing_Repo();
            Outing outing = new Outing(new DateTime(2008, 3, 15), EventType.Bowling, 100, 3000m);
            repo.AddOuting(outing);
            DateTime date = new DateTime(2008, 3, 15);

            //Act
            Outing oldOuting = repo.GetOutingByDate(date);

            bool removeResult = repo.DeleteExistingOuting(oldOuting);

            //Assert
            Assert.IsTrue(removeResult);
           

        }
    }
}
