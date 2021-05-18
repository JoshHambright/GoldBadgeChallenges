﻿using GreenPlan;
using GreenPlan.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPlan_UI
{
    public class Program_UI
    {
        private Car_Repo _repo = new Car_Repo();
        public void Run()
        {
            SeedCars();
            Menu();
        }


        public void SeedCars()
        {
            GasCar car = new GasCar("Ford", "Mustang", 2020, VehicleType.SportsCar, 100, 19);
            GasCar car2 = new GasCar("Toyota", "Camry", 2019, VehicleType.Sedan, 624, 32);
            HybridCar car3 = new HybridCar("Toyota", "Prius", 2020, VehicleType.Sedan, 655, 52, 8.8);
            HybridCar car4 = new HybridCar("Honda", "Accord Hybrd", 2020, VehicleType.Sedan, 614.4, 48, 1.3);
            ElectricCar car5 = new ElectricCar("Tesla", "ModelS", 2020, VehicleType.Sedan, 322, 75, 10);
            ElectricCar car6 = new ElectricCar("Hyundai", "Kona", 2020, VehicleType.HatchBack, 258, 64, 9);
            _repo.AddCar(car);
            _repo.AddCar(car2);
            _repo.AddCar(car3);
            _repo.AddCar(car4);
            _repo.AddCar(car5);
            _repo.AddCar(car6);

        }
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                KomodoLogo();
                Console.WriteLine("<<<<<<<< Main Menu >>>>>>>");
                Console.WriteLine("1> Add a car to the database");
                Console.WriteLine("2> Update a car");
                Console.WriteLine("3> Delete a car");
                Console.WriteLine("4> View Details on a car");
                Console.WriteLine("5> View all Cars or specific type of car");
                Console.WriteLine("6> Exit");
                string menuSelect = Console.ReadLine();

                switch (menuSelect)
                {
                    case "1":
                        AddCar();
                        break;
                    case "2":
                        UpdateCar();
                        break;
                    case "3":
                        DeleteCar();
                        break;
                    case "4":
                        ViewCar();
                        break;
                    case "5":
                        ViewMenu();
                        break;
                    case "6":
                        keepRunning = false;
                        break;
                    default:
                        break;

                }

            }
        }

        public void AddCar()
        {
            //Method to create new car in the database
            bool looper = true;
            Car car = new Car();
            while (looper)
            {
                Console.Clear();
                KomodoLogo();
                Console.WriteLine("<<<<<<<< Adding Car >>>>>>>");
                Console.WriteLine("What Category is the car:");
                Console.WriteLine("1> Gar Car");
                Console.WriteLine("2> Hybrid Car");
                Console.WriteLine("3> Electric Car");
                bool classTypeLoop = true;
                string carClassType = "";

                while (classTypeLoop)
                {
                    carClassType = Console.ReadLine();
                    switch (carClassType)
                    {
                        case "1":
                            car = new GasCar();
                            classTypeLoop = false;
                            carClassType = "Gas Car";
                            break;
                        case "2":
                            car = new HybridCar();
                            classTypeLoop = false;
                            carClassType = "Hybrid Car";
                            break;
                        case "3":
                            car = new ElectricCar();
                            classTypeLoop = false;
                            carClassType = "Electric Car";
                            break;
                        default:
                            Console.WriteLine("Please enter a valid selection. (1,2,3)");
                            break;

                    }
                }
                Console.WriteLine("Enter Make:");
                car.Make = Console.ReadLine();
                Console.WriteLine("Enter Model:");
                car.Model = Console.ReadLine();
                Console.WriteLine("Enter Model Year:");
                car.Year = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please Select Vehicle Type:");
                //Sedan = 1, SUV, PickupTruck, Coupe, SportsCar, Wagon, HatchBack, Convertible, Minivan
                Console.WriteLine("1> Sedan");
                Console.WriteLine("2> SUV");
                Console.WriteLine("3> Pickup Truck");
                Console.WriteLine("4> Coupe");
                Console.WriteLine("5> Sports Car");
                Console.WriteLine("6> Wagon");
                Console.WriteLine("7> Hatch Back");
                Console.WriteLine("8> Convertible");
                Console.WriteLine("9> Minivan");
                bool vehicleTypeLoop = true;
                string vehicleType = "";
                while (vehicleTypeLoop)
                {
                    vehicleType = Console.ReadLine();
                    if (vehicleType == "1" || vehicleType == "2" || vehicleType == "3" || vehicleType == "4" || vehicleType == "5" || vehicleType == "6" || vehicleType == "7" || vehicleType == "8" || vehicleType == "9")
                    {
                        vehicleTypeLoop = false;
                    }
                    else { Console.WriteLine("Please enter a valid selection. (1,2,3,4,5,6,7,8 or 9"); }
                }
                car.Type = (VehicleType)int.Parse(vehicleType);
                Console.WriteLine("Enter avg fuel range:");
                car.AvgRange = Convert.ToDouble(Console.ReadLine());
                //if (car is HybridCar || car is GasCar)
                //{
                //    Console.WriteLine("Enter combined average MPG");
                //    // code to set the avg mpg
                //}
                //if (car is HybridCar || car is ElectricCar)
                //{
                //    Console.WriteLine("Enter battery capacity(kWh):");
                //    //code to set battery capacity
                //}
                if (car is GasCar)
                {
                    Console.WriteLine("Enter combined average MPG:");
                    ((GasCar)car).AvgMPG = Convert.ToDouble(Console.ReadLine());
                }
                else if (car is ElectricCar)
                {
                    Console.WriteLine("Enter battery capacity (kWh):");
                    ((ElectricCar)car).BatteryCapacity = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter charge time (220v):");
                    ((ElectricCar)car).ChargeTime = Convert.ToDouble(Console.ReadLine());
                }
                else if (car is HybridCar)
                {
                    Console.WriteLine("Enter combined average MPG:");
                    ((HybridCar)car).AvgMPG = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter battery capacity (kWh):");
                    ((HybridCar)car).BatteryCapacity = Convert.ToDouble(Console.ReadLine());
                }
                Console.Clear();
                KomodoLogo();
                Console.WriteLine("<<<<<<<< Adding Car >>>>>>>");

                //Console.WriteLine($"Vehicle Type: {carClassType}");
                //Console.WriteLine($"Car Make: {car.Make}");
                //Console.WriteLine($"Car Model: {car.Model}");
                //Console.WriteLine($"Car class: {car.Type.ToString()}");
                //Console.WriteLine($"Average fuel range: {car.AvgRange} miles");
                //if (car is GasCar)
                //{
                //    Console.WriteLine($"Average combined MPG: {((GasCar)car).AvgMPG}");
                //}
                //else if (car is HybridCar)
                //{
                //    Console.WriteLine($"Average combined MPG: {((HybridCar)car).AvgMPG}");
                //    Console.WriteLine($"Battery capacity: {((HybridCar)car).BatteryCapacity}");
                //}
                //else if (car is ElectricCar)
                //{
                //    Console.WriteLine($"Average charge time (@ 220v): {((ElectricCar)car).ChargeTime}");
                //    Console.WriteLine($"Battery capacity: {((ElectricCar)car).BatteryCapacity}");
                //}
                DisplayCar(car);
                Console.WriteLine("Does all of this look correct? \nEnter Y to add this car. \nEnter N to start over entering this car.");
                string correct = Console.ReadLine();
                if (correct.ToLower() == "y")
                {
                    looper = false;
                }
            }
            bool wasAdded = _repo.AddCar(car);
            if (wasAdded == true)
            {
                Console.WriteLine("Your car was added to the database.");
                Console.WriteLine("Press any key to Continue.");
            }
            else
            {
                Console.WriteLine("Oops. Something went wrong. Your car was not added.  Please Try Again");
                Console.WriteLine("Press any key to continue.");
            }

            Console.ReadKey();

        }

        public void DisplayCar(Car car)
        {
            string carClassType = "";
            if (car is HybridCar)
            {
                carClassType = "Hybrid Car";
            }
            else if (car is GasCar)
            {
                carClassType = "Gas Car";
            }
            else if (car is ElectricCar)
            {
                carClassType = "Electric Car";
            }
            Console.WriteLine($"Vehicle Type:                   {carClassType}");
            Console.WriteLine($"Car Make:                       {car.Make}");
            Console.WriteLine($"Car Model:                      {car.Model}");
            Console.WriteLine($"Car class:                      {car.Type.ToString()}");
            Console.WriteLine($"Average fuel range:             {car.AvgRange} miles");
            if (car is GasCar)
            {
                Console.WriteLine($"Average combined MPG:           {((GasCar)car).AvgMPG}");
            }
            else if (car is HybridCar)
            {
                Console.WriteLine($"Average combined MPG:           {((HybridCar)car).AvgMPG}");
                Console.WriteLine($"Battery capacity:               {((HybridCar)car).BatteryCapacity}kWh");
            }
            else if (car is ElectricCar)
            {
                Console.WriteLine($"Average charge time (@ 220v):   {((ElectricCar)car).ChargeTime}");
                Console.WriteLine($"Battery capacity:               {((ElectricCar)car).BatteryCapacity}kWh");
            }
        }
        public void ViewCar()
        {
            Console.Clear();
            KomodoLogo();
            Console.WriteLine("<<<<<<<< View Car >>>>>>>");
            Console.WriteLine("Enter Make:");
            string make = Console.ReadLine();
            Console.WriteLine("Enter Model:");
            string model = Console.ReadLine();
            Console.WriteLine("Enter Year:");
            string year = Console.ReadLine();
            string carID = year.ToString() + make.ToLower() + model.ToLower();
            Car car = _repo.GetCarByID(carID);
            if (car != null)
            {
                DisplayCar(car);
            }
            else
            {
                Console.WriteLine("Car not found. \nPress any key to return to main menu.");
            }

            Console.ReadKey();
        }

        public void UpdateCar()
        {
            Console.Clear();
            KomodoLogo();
            Console.WriteLine("<<<<<<<< Update Car >>>>>>>");
            Console.WriteLine("Enter Make:");
            string make = Console.ReadLine();
            Console.WriteLine("Enter Model:");
            string model = Console.ReadLine();
            Console.WriteLine("Enter Year:");
            string year = Console.ReadLine();
            string oldCarID = year.ToString() + make.ToLower() + model.ToLower();
            Car oldCar = _repo.GetCarByID(oldCarID);
            if (oldCar != null)
            {
                Console.Clear();
                KomodoLogo();
                Console.WriteLine("<<<<<<<< Update Car >>>>>>>");
                DisplayCar(oldCar);
                Console.WriteLine();
                Console.WriteLine("---------------------------");
                bool looper = true;
                Car car = new Car();
                while (looper)
                {
                    Console.WriteLine("<<<<<<<< Updating >>>>>>>");
                    //Set car type
                    if (oldCar is GasCar) { car = new GasCar(); }
                    if (oldCar is HybridCar) { car = new HybridCar(); }
                    if (oldCar is ElectricCar) { car = new ElectricCar(); }
                    Console.WriteLine("Enter Make:");
                    car.Make = Console.ReadLine();
                    Console.WriteLine("Enter Model:");
                    car.Model = Console.ReadLine();
                    Console.WriteLine("Enter Model Year:");
                    car.Year = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please Select Vehicle Type:");
                    //Sedan = 1, SUV, PickupTruck, Coupe, SportsCar, Wagon, HatchBack, Convertible, Minivan
                    Console.WriteLine("1> Sedan");
                    Console.WriteLine("2> SUV");
                    Console.WriteLine("3> Pickup Truck");
                    Console.WriteLine("4> Coupe");
                    Console.WriteLine("5> Sports Car");
                    Console.WriteLine("6> Wagon");
                    Console.WriteLine("7> Hatch Back");
                    Console.WriteLine("8> Convertible");
                    Console.WriteLine("9> Minivan");
                    bool vehicleTypeLoop = true;
                    string vehicleType = "";
                    while (vehicleTypeLoop)
                    {
                        vehicleType = Console.ReadLine();
                        if (vehicleType == "1" || vehicleType == "2" || vehicleType == "3" || vehicleType == "4" || vehicleType == "5" || vehicleType == "6" || vehicleType == "7" || vehicleType == "8" || vehicleType == "9")
                        {
                            vehicleTypeLoop = false;
                        }
                        else { Console.WriteLine("Please enter a valid selection. (1,2,3,4,5,6,7,8 or 9"); }
                    }
                    car.Type = (VehicleType)int.Parse(vehicleType);
                    Console.WriteLine("Enter avg fuel range:");
                    car.AvgRange = Convert.ToDouble(Console.ReadLine());
                    if (car is GasCar)
                    {
                        Console.WriteLine("Enter combined average MPG:");
                        ((GasCar)car).AvgMPG = Convert.ToDouble(Console.ReadLine());
                    }
                    else if (car is ElectricCar)
                    {
                        Console.WriteLine("Enter battery capacity (kWh):");
                        ((ElectricCar)car).BatteryCapacity = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter charge time (220v):");
                        ((ElectricCar)car).ChargeTime = Convert.ToDouble(Console.ReadLine());
                    }
                    else if (car is HybridCar)
                    {
                        Console.WriteLine("Enter combined average MPG:");
                        ((HybridCar)car).AvgMPG = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter battery capacity (kWh):");
                        ((HybridCar)car).BatteryCapacity = Convert.ToDouble(Console.ReadLine());
                    }
                    Console.Clear();
                    KomodoLogo();
                    Console.WriteLine("<<<<<<< Updating Car >>>>>>>");
                    Console.WriteLine("     <<    Old Car   >>");
                    DisplayCar(oldCar);
                    Console.WriteLine();
                    Console.WriteLine("     <<    New Car   >>");
                    DisplayCar(car);
                    Console.WriteLine("Does all of this look correct? \nEnter Y to add this car. \nEnter N to start over entering this car.");
                    string correct = Console.ReadLine();
                    if (correct.ToLower() == "y")
                    {
                        looper = false;
                    }
                }
                bool wasUpdated = _repo.UpdateExistingCar(oldCarID, car);
                if (wasUpdated == true)
                {
                    Console.WriteLine("Your car was update in the database.");
                    Console.WriteLine("Press any key to Continue.");
                }
                else
                {
                    Console.WriteLine("Oops. Something went wrong. Your car was not Updated.  Please Try Again");
                    Console.WriteLine("Press any key to continue.");
                }
            }
            else
            {
                Console.WriteLine("Car not found. \nPress any key to return to main menu.");
            }
            Console.ReadKey();
        }

        public void DeleteCar()
        {
            Console.Clear();
            KomodoLogo();
            Console.WriteLine("<<<<<<<< Update Car >>>>>>>");
            Console.WriteLine("Enter Make:");
            string make = Console.ReadLine();
            Console.WriteLine("Enter Model:");
            string model = Console.ReadLine();
            Console.WriteLine("Enter Year:");
            string year = Console.ReadLine();
            string oldCarID = year.ToString() + make.ToLower() + model.ToLower();
            Car oldCar = _repo.GetCarByID(oldCarID);
            if (oldCar != null)
            {
                Console.Clear();
                KomodoLogo();
                Console.WriteLine("<<<<<<<< Delete Car >>>>>>>");
                DisplayCar(oldCar);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("!!!!! WARNING DELETE CAN NOT BE UNDONE !!!!!  \nDo you want to continue Deleting this item?");
                Console.WriteLine("Enter Y to continue deleting this car. Enter N to return to the main menu.");
                Console.ResetColor();
                string deleteConfirm = Console.ReadLine();
                if (deleteConfirm.ToLower() == "y")
                {
                    bool deleteResult = _repo.DeleteCar(oldCar);
                    if (deleteResult == true)
                    {
                        Console.WriteLine("Car deleted Successfully.");
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
                Console.WriteLine("Car not found. \nPress any key to return to main menu.");
            }
            Console.ReadKey();


        }

        public void ViewMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                KomodoLogo();
                Console.WriteLine("<<<<<<<< View Menu >>>>>>>");
                Console.WriteLine("1> View All Cars");
                Console.WriteLine("2> View Gas Cars");
                Console.WriteLine("3> View Hybrid Cars");
                Console.WriteLine("4> View Electric Cars");
                Console.WriteLine("5> Return to main menu");
                string menuSelection = Console.ReadLine();
                List<Car> cars = _repo.GetAllCars();

                switch (menuSelection)
                {
                    case "1":
                        Console.Clear();
                        KomodoLogo();
                        Console.WriteLine("<<<<<<<< View All Cars>>>>>>>");
                        Console.WriteLine("");

                        Console.WriteLine("{0,-10} {1,15}    {2,-6}  {3,-12} {4,10} {5,10}", "Make", "Model", "Year", "Type", "Class", "Avg Range");
                        foreach (Car car in cars)
                        {
                            string carClassType = "";
                            if (car is HybridCar)
                            {
                                carClassType = "Hybrid Car";
                            }
                            else if (car is GasCar)
                            {
                                carClassType = "Gas Car";
                            }
                            else if (car is ElectricCar)
                            {
                                carClassType = "Electric Car";
                            }
                            Console.WriteLine("{0,-10} {1,15}    {2,-6}  {3,-12:N2} {4,10} {5,8}mi", car.Make, car.Model, car.Year, carClassType, car.Type.ToString(), car.AvgRange);

                        }
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        KomodoLogo();
                        Console.WriteLine("<<<<<<<< View All Gas Cars >>>>>>>");
                        Console.WriteLine("");

                        Console.WriteLine("{0,-10} {1,15}    {2,-6}  {3,-12} {4,10} {5,10} {6,8}", "Make", "Model", "Year", "Type", "Class", "Avg Range", "Avg MPG");
                        foreach (Car car in cars)
                        {
                            string carClassType = "";
                            if (car is GasCar)
                            {
                                carClassType = "Gas Car";
                                Console.WriteLine("{0,-10} {1,15}    {2,-6}  {3,-12:N2} {4,10} {5,8}mi {6,8}", car.Make, car.Model, car.Year, carClassType, car.Type.ToString(), car.AvgRange, ((GasCar)car).AvgMPG);

                            }

                        }
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        KomodoLogo();
                        Console.WriteLine("<<<<<<<< View All Hybrid Cars >>>>>>>");
                        Console.WriteLine("");

                        Console.WriteLine("{0,-10} {1,15}    {2,-6}  {3,-12} {4,10} {5,10} {6,8} {7,18}", "Make", "Model", "Year", "Type", "Class", "Avg Range", "Avg MPG", "Battery Capacity");
                        foreach (Car car in cars)
                        {
                            string carClassType = "";
                            if (car is HybridCar)
                            {
                                carClassType = "Hybrid";
                                Console.WriteLine("{0,-10} {1,15}    {2,-6}  {3,-12:N2} {4,10} {5,8}mi {6,8} {7,15}kWh", car.Make, car.Model, car.Year, carClassType, car.Type.ToString(), car.AvgRange, ((HybridCar)car).AvgMPG, ((HybridCar)car).BatteryCapacity);

                            }

                        }
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        KomodoLogo();
                        Console.WriteLine("<<<<<<<< View All Electric Cars >>>>>>>");
                        Console.WriteLine("");

                        Console.WriteLine("{0,-10} {1,15}    {2,-6}  {3,-12} {4,10} {5,10} {6,13} {7,18}", "Make", "Model", "Year", "Type", "Class", "Avg Range", "Charge Time", "Battery Capacity");
                        foreach (Car car in cars)
                        {
                            string carClassType = "";
                            if (car is ElectricCar)
                            {
                                carClassType = "Electric";
                                Console.WriteLine("{0,-10} {1,15}    {2,-6}  {3,-12:N2} {4,10} {5,8}mi {6,11}hr {7,15}kWh", car.Make, car.Model, car.Year, carClassType, car.Type.ToString(), car.AvgRange, ((ElectricCar)car).ChargeTime, ((ElectricCar)car).BatteryCapacity);

                            }

                        }
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case "5":
                        keepRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public void KomodoLogo()
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
            Console.WriteLine("         -- Green Plan Car Data System --");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
