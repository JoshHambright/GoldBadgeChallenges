using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting
{
    public class Customer_Repo
    {
        //Repo Field
        private List<Customer> _customers = new List<Customer>();

        //Create customer
        public bool AddCustomer(Customer customer)
        {
            int startingCount = _customers.Count;
            _customers.Add(customer);
            bool wasAdded = (_customers.Count > startingCount) ? true : false;
            return wasAdded;
        }

        // Read

        //Get full customer list
        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }

        //Get individual Customer from list
        public Customer GetCustomerByFullName(string fullName)
        {
            foreach (Customer customer in _customers)
            {
                if (customer.FullName.ToLower() == fullName.ToLower())
                {
                    return customer;
                }
            }
            return null;
        }


        //Update customer
        public bool UpdateExistingCustomer(string oldFullName, Customer newCustomer)
        {
            Customer oldCustomer = GetCustomerByFullName(oldFullName);

            if (oldCustomer != null)
            {
                oldCustomer.FirstName = newCustomer.FirstName;
                oldCustomer.LastName = newCustomer.LastName;
                oldCustomer.Type = newCustomer.Type;
                return true;
            }
            else { return false; }
        }

        //Delete customer
        public bool DeleteCustomer(Customer customer)
        {
            bool deleteItem = _customers.Remove(customer);
            return deleteItem;
        }
    }
}
