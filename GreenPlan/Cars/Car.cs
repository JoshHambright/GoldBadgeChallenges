using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPlan.Cars
{
    public enum VehicleType { Sedan = 1, SUV, PickupTruck, Coupe, SportsCar, Wagon, HatchBack, Convertible, Minivan, }
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public VehicleType Type { get; set; }

        public double AvgRange { get; set; }

        public string CarID
        {
            get
            {
                string ID = Year + Make + Model;
                return ID;
            }
        }

        public Car() { }

        public Car(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public Car(string make, string model, int year, VehicleType type,double range)
        {
            Make = make;
            Model = model;
            Year = year;
            Type = type;
            AvgRange = range;
        }

    }
}
