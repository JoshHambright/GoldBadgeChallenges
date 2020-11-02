using GreenPlan;
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
            //SeedCars();
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
                    //UpdateCar();
                    //break;
                    case "3":
                    //DeleteCar();
                    //break;
                    case "4":
                    //ViewCar();
                    //break;
                    case "5":
                    //ViewAllCars();
                    //break;
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
                car.Make = Console.ReadLine();
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

                Console.WriteLine($"Vehicle Type: {carClassType}");
                Console.WriteLine($"Car Make: {car.Make}");
                Console.WriteLine($"Car Model: {car.Model}");
                Console.WriteLine($"Car class: {car.Type.ToString()}");
                Console.WriteLine($"Average fuel range: {car.AvgRange} miles");
                if (car is GasCar)
                {
                    Console.WriteLine($"Average combined MPG: {((GasCar)car).AvgMPG}");
                }
                else if (car is HybridCar)
                {
                    Console.WriteLine($"Average combined MPG: {((HybridCar)car).AvgMPG}");
                    Console.WriteLine($"Battery capacity: {((HybridCar)car).BatteryCapacity}");
                }
                else if (car is ElectricCar)
                {
                    Console.WriteLine($"Average charge time (@ 220v): {((ElectricCar)car).ChargeTime}");
                    Console.WriteLine($"Battery capacity: {((ElectricCar)car).BatteryCapacity}");
                }
                Console.WriteLine("Does all of this look correct? \nEnter Y to commit this event. \nEnter N to start over entering this event.");
                string correct = Console.ReadLine();
                if (correct.ToLower() == "y")
                {
                    looper = false;
                }
            }
            bool wasAdded = _repo.AddCar(car);
            if (wasAdded == true)
            {
                Console.WriteLine("Your Content was added to the database.");
                Console.WriteLine("Press any key to Continue.");
            }
            else
            {
                Console.WriteLine("Oops. Something went wrong. Your content was not added.  Please Try Again");
                Console.WriteLine("Press any key to continue.");
            }

            Console.ReadKey();

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
