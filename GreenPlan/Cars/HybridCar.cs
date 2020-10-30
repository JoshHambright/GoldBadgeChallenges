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


        public HybridCar() { }

        public HybridCar(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }
        public HybridCar(string make, string model, int year, VehicleType type, double range, double mpg)
        {
            Make = make;
            Model = model;
            Year = year;
            Type = type;
            AvgRange = range;
            AvgMPG = mpg;
        }
    }
}
