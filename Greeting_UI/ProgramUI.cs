using Greeting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_UI
{
    public class ProgramUI
    {
        //Customer Repo
        private Customer_Repo _repo = new Customer_Repo();

        //Methods

        public void Run()
        {
            SeedCustomers();
            MainMenu();
        }

        public void SeedCustomers()
        {
            //Seed Customers for Testing

            Customer customer1 = new Customer("Smith", "Jake", CustomerType.Potential);
            Customer customer2 = new Customer("Smith", "James", CustomerType.Current);
            Customer customer3 = new Customer("Smith", "Jane", CustomerType.Past);
            _repo.AddCustomer(customer1);
            _repo.AddCustomer(customer2);
            _repo.AddCustomer(customer3);

        }


        public void MainMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                KomodoLogo();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("=+= Main Manu =+=");
                Console.WriteLine("1> Add Customer to Database");
                Console.WriteLine("2> View a Customer");
                Console.WriteLine("3> Update a Customer");
                Console.WriteLine("4> Delete a Customer");
                Console.WriteLine("5> Alphabetical List View of all Customers");
                Console.WriteLine("6> Exit");
                Console.WriteLine("Please enter a number to proceed:");
                string menuSelection = Console.ReadLine();

                switch (menuSelection)
                {
                    case "1":
                        AddCustomer();
                        break;
                    case "2":
                        ViewCustomer();
                        break;
                    case "3":
                        UpdateCustomer();
                        break;
                    case "4":
                    DeleteCustomer();
                    break;
                    case "5":
                    ListView();
                    break;
                    case "6":
                        continueToRun = false;
                        break;
                    default:
                        break;
                }

            }

        }

        public void AddCustomer()
        {
            Customer newCustomer = new Customer();
            bool looper = true;
            while (looper)
            {
                Console.Clear();
                KomodoLogo();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("=+= New Customer =+=");
                Console.WriteLine("Enter Customer First Name:");
                newCustomer.FirstName = Console.ReadLine();
                Console.WriteLine("Enter Customer Last Name:");
                newCustomer.LastName = Console.ReadLine();
                bool typeLoop = true;
                Console.WriteLine("Customer Types");
                Console.WriteLine("1> Potential");
                Console.WriteLine("2> Current");
                Console.WriteLine("3> Past");
                Console.WriteLine("Please enter number for customer type.");
                string type = "1";
                while (typeLoop)
                {
                    type = Console.ReadLine();
                    if (type == "1" || type == "2" || type == "3")
                    {
                        typeLoop = false;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid selection (1,2, or 3)");
                    }
                }
                newCustomer.Type = (CustomerType)int.Parse(type);
                Console.WriteLine("-- New Customer Preview --");
                Console.WriteLine("First Name:      " + newCustomer.FirstName);
                Console.WriteLine("Last Name:       " + newCustomer.LastName);
                Console.WriteLine("Customer Type:   " + newCustomer.Type);
                Console.WriteLine();
                Console.WriteLine("Is the preview correct? \nEnter Y to add this customer to the database.\nEnter N to start over entering customer information.");
                string isCorrect = Console.ReadLine();
                if (isCorrect.ToLower() == "y")
                {
                    looper = false;
                }
            }
            bool wasAdded = _repo.AddCustomer(newCustomer);
            if (wasAdded == true)
            {
                Console.WriteLine("Customer added successfully");
                Console.WriteLine("Press any key to return to the main menu");
            }
            else
            {
                Console.WriteLine("Oops! Something went wrong. New Customer was not added to the database. Please try again.");
                Console.WriteLine("Press any key to return to the main menu");
            }

            Console.ReadKey();
        }

        public void ViewCustomer()
        {
            Console.Clear();
            KomodoLogo();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("=+= View Customer =+=");
            Console.WriteLine("Enter customer's full name (First Last)");
            string fullName = Console.ReadLine();

            Console.Clear();
            KomodoLogo();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("=+= View Customer =+=");
            Customer customer = new Customer();
            customer = _repo.GetCustomerByFullName(fullName);
            if (customer != null)
            {
                Console.WriteLine("First Name:              " + customer.FirstName);
                Console.WriteLine("Last Name:               " + customer.LastName);
                Console.WriteLine("Customer Type:           " + customer.Type);
                Console.WriteLine("Email Message Preview:   " + customer.Email);
                Console.WriteLine("Press any key to return to main menu.");
            }
            else
            {
                Console.WriteLine("Customer not found");
                Console.WriteLine("Press any key to return to main menu.");
            }
            Console.ReadKey();
        }

        public void UpdateCustomer()
        {
            Customer oldCustomer = new Customer();
            Customer newCustomer = new Customer();
            bool looper = true;
            Console.Clear();
            KomodoLogo();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("=+= Update Customer =+=");
            Console.WriteLine("Enter Full Name of Customer to update:");
            string fullName = Console.ReadLine();
            oldCustomer = _repo.GetCustomerByFullName(fullName);
            if (oldCustomer != null)
            {
                while (looper)
                {
                    Console.Clear();
                    KomodoLogo();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=+= Current Customer Information =+=");
                    Console.WriteLine("First Name:      " + oldCustomer.FirstName);
                    Console.WriteLine("Last Name:       " + oldCustomer.LastName);
                    Console.WriteLine("Customer Type:   " + oldCustomer.Type);
                    Console.WriteLine();
                    Console.WriteLine("=+= New Customer Info =+=");
                    Console.WriteLine("Enter Customer First Name:");
                    newCustomer.FirstName = Console.ReadLine();
                    Console.WriteLine("Enter Customer Last Name:");
                    newCustomer.LastName = Console.ReadLine();
                    bool typeLoop = true;
                    Console.WriteLine("Customer Types");
                    Console.WriteLine("1> Potential");
                    Console.WriteLine("2> Current");
                    Console.WriteLine("3> Past");
                    Console.WriteLine("Please enter number for customer type.");
                    string type = "1";
                    while (typeLoop)
                    {
                        type = Console.ReadLine();
                        if (type == "1" || type == "2" || type == "3")
                        {
                            typeLoop = false;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid selection (1,2, or 3)");
                        }
                    }
                    newCustomer.Type = (CustomerType)int.Parse(type);
                    Console.Clear();
                    KomodoLogo();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("=+= Current Customer Information =+=");
                    Console.WriteLine("First Name:      " + oldCustomer.FirstName);
                    Console.WriteLine("Last Name:       " + oldCustomer.LastName);
                    Console.WriteLine("Customer Type:   " + oldCustomer.Type);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("=+= New Customer Info Preview =+=");
                    Console.WriteLine("First Name:      " + newCustomer.FirstName);
                    Console.WriteLine("Last Name:       " + newCustomer.LastName);
                    Console.WriteLine("Customer Type:   " + newCustomer.Type);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Is the preview correct? \nEnter Y to update this customer.\nEnter N to start over updating customer information.");
                    string isCorrect = Console.ReadLine();
                    if (isCorrect.ToLower() == "y")
                    {
                        looper = false;
                    }
                }
                bool wasUpdate = _repo.UpdateExistingCustomer(fullName, newCustomer);
                if (wasUpdate == true)
                {
                    Console.WriteLine("Customer updated successfully");
                    Console.WriteLine("Press any key to return to the main menu");
                }
                else
                {
                    Console.WriteLine("Oops! Something went wrong. Customer info was not updated. Please try again.");
                    Console.WriteLine("Press any key to return to the main menu");
                }

            }

            else
            {
                Console.WriteLine("Customer not found");
                Console.WriteLine("Press any key to return to main menu.");
            }
            Console.ReadKey();

        }

        public void DeleteCustomer()
        {
            Customer oldCustomer = new Customer();
            Console.Clear();
            KomodoLogo();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("=+= Delete Customer =+=");
            Console.WriteLine("Enter Full Name of Customer to update:");
            string fullName = Console.ReadLine();
            oldCustomer = _repo.GetCustomerByFullName(fullName);
            if (oldCustomer != null)
            {
                Console.Clear();
                KomodoLogo();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("=+= Customer to Delete =+=");
                Console.WriteLine("First Name:      " + oldCustomer.FirstName);
                Console.WriteLine("Last Name:       " + oldCustomer.LastName);
                Console.WriteLine("Customer Type:   " + oldCustomer.Type);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("!!!!! WARNING DELETE CAN NOT BE UNDONE !!!!!  \nDo you want to continue Deleting this item?");
                Console.WriteLine("Enter Y to continue deleting this Item. Enter N to return to the main menu.");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                string deleteConfirm = Console.ReadLine();
                if (deleteConfirm.ToLower() == "y")
                {
                    bool deleteResult = _repo.DeleteCustomer(oldCustomer);
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

            }
            else
            {
                Console.WriteLine("Customer not found. Press any key to return to the main menu");
            }
            Console.ReadKey();
        }

        public void ListView()
        {
            Console.Clear();
            KomodoLogo();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("=+= Viewing All Customer Entries =+=");
            Console.WriteLine();

            List<Customer> customers = _repo.GetAllCustomers();
            customers.OrderBy(x => x.LastName).ThenBy(x => x.FirstName);
            Console.WriteLine("First Name".PadRight(10) +"Last Name".PadLeft(15)+ "Type".PadLeft(15)  + "Email".PadLeft(10));
            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer.FirstName.PadRight(15) + customer.LastName.PadLeft(10) + customer.Type.ToString().PadLeft(15)+ "     " + customer.Email.PadLeft(10) );
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

        }


        private void KomodoLogo()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("██╗  ██╗ ██████╗ ███╗   ███╗ ██████╗ ██████╗  ██████╗ ");
            Console.WriteLine("██║ ██╔╝██╔═══██╗████╗ ████║██╔═══██╗██╔══██╗██╔═══██╗");
            Console.WriteLine("█████╔╝ ██║   ██║██╔████╔██║██║   ██║██║  ██║██║   ██║");
            Console.WriteLine("██╔═██╗ ██║   ██║██║╚██╔╝██║██║   ██║██║  ██║██║   ██║");
            Console.WriteLine("██║  ██╗╚██████╔╝██║ ╚═╝ ██║╚██████╔╝██████╔╝╚██████╔╝");
            Console.WriteLine("╚═╝  ╚═╝ ╚═════╝ ╚═╝     ╚═╝ ╚═════╝ ╚═════╝  ╚═════╝ ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("      -- Komodo Insurance Customer Email App --");
            Console.ResetColor();
            Console.WriteLine();
        }


    }
}
