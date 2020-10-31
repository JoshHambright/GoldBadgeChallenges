using System;
using System.Collections.Generic;
using GreenPlan;
using GreenPlan.Cars;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreenPlan_Tests
{
    [TestClass]
    public class Cars_RepoTest
    {
        [TestMethod]
        public void AddCar_ShouldGetCorrectBool() //Create
        {
            //Arrange
            HybridCar hybridCar = new HybridCar();
            Car_Repo repo = new Car_Repo();

            //Act
            bool addResult = repo.AddCar(hybridCar);


            //Assert
            Assert.IsTrue(addResult);

        }

        [TestMethod]
        public void GetAllCars_ShouldReturnCorrectCollection() //Read
        {
            //Arrange
            GasCar car = new GasCar("ford", "mustang", 2020);
            Car_Repo repo = new Car_Repo();
            repo.AddCar(car);
            //Act
            List<Car> localCars = repo.GetAllCars();
            bool hasCar = localCars.Contains(car);
            //Assert
            Assert.IsTrue(hasCar);
        }

        [TestMethod]
        public void GetCarByID_ShouldReturnCorrectCar()//Read
        {
            //Arrange
            GasCar car = new GasCar("ford", "mustang", 2020);
            HybridCar car2 = new HybridCar("toyota", "prius", 2019);
            Car_Repo repo = new Car_Repo();
            repo.AddCar(car);
            repo.AddCar(car2);

            string id = "2020fordmustang";

            //Act
            var localCar = repo.GetCarByID(id);

            //assert
            Assert.AreEqual(localCar.CarID, id);
        }

        [TestMethod]
        public void UpdateExistingCar_() //Update a car
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod]
        public void DeleteCar()//Delete a car from repo
        {
            //Arrange
            GasCar car = new GasCar("ford", "mustang", 2020);
            Car_Repo repo = new Car_Repo();
            repo.AddCar(car);
            string id = "2020fordmustang";


            //Act
            Car oldCar = repo.GetCarByID(id);
            bool removeResult = repo.DeleteCar(oldCar);

            //Assert
            Assert.IsTrue(removeResult);
        }
    }
}
