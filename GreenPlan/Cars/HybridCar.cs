using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPlan.Cars
{
    public class HybridCar : Car
    {
        public double AvgMPG { get; set; }
        public double BatteryCapacity { get; set; }

        public string CarClassType
        {
            get
            {
                return "Hybrid Car";
            }
        }

        public HybridCar() { }

        public HybridCar(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }
        public HybridCar(string make, string model, int year, VehicleType type, double range, double mpg, double battery)
        {
            Make = make;
            Model = model;
            Year = year;
            Type = type;
            AvgRange = range;
            AvgMPG = mpg;
            BatteryCapacity = battery;

        }
    }
}
