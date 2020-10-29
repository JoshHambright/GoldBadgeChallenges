using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Greeting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Greeting_Tests
{
    [TestClass]
    public class Customer_RepoTest
    {
        [TestMethod]
        public void AddToRepo_ShouldReturnCorrectBool() //Create
        {
            //Arrange
            Customer customer = new Customer();
            Customer_Repo repo = new Customer_Repo();
            //Act
            bool wasAdded = repo.AddCustomer(customer);

            //Assert
            Assert.IsTrue(wasAdded);
        }


        [TestMethod]
        public void GetCustomers_ShouldReturnCorrectRepo() //Read
        {
            //Arrange
            Customer customer = new Customer();
            Customer_Repo repo = new Customer_Repo();
            repo.AddCustomer(customer);

            //Act
            List<Customer> customers = repo.GetAllCustomers();
            bool customersHasCustomer = customers.Contains(customer);

            //Assert
            Assert.IsTrue(customersHasCustomer);

        }

        [TestMethod]
        public void GetCustomerByFullName_ShouldReturnCorrectCustomer() //Read
        {
            //Arrange
            Customer_Repo repo = new Customer_Repo();
            Customer customer = new Customer("Hambright", "Josh", CustomerType.Current);
            repo.AddCustomer(customer);
            string fullName = "Josh Hambright";

            //Act
            Customer searchResult = repo.GetCustomerByFullName(fullName);

            //Assert
            Assert.AreEqual(searchResult.FullName, fullName);

        }

        [TestMethod]
        public void UpdateExistingCustomer_ShouldReturnTrue()//Update
        {
            //Arrange
            Customer_Repo repo = new Customer_Repo();
            Customer customer = new Customer("Hambright", "Josh", CustomerType.Current);
            repo.AddCustomer(customer);
            Customer newCustomer = new Customer("Hambright", "Josh", CustomerType.Potential);

            //Act
            bool updateResult = repo.UpdateExistingCustomer(customer.FullName, newCustomer);

            //Assert
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void DeleteCustomer_ShouldReturnTrue() //Delete
        {
            //Arrange
            Customer_Repo repo = new Customer_Repo();
            Customer customer = new Customer("Hambright", "Josh", CustomerType.Current);
            repo.AddCustomer(customer);
            string fullName = "Josh Hambright";

            //Act
            Customer oldCustomer = repo.GetCustomerByFullName(fullName);
            bool removeCustomer = repo.DeleteCustomer(oldCustomer);

            //Assert
            Assert.IsTrue(removeCustomer);

        }
    }
}
