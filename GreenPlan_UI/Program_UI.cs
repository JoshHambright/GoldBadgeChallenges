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
            while (looper)
            {


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
