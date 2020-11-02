using GreenPlan.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPlan
{
    public class Car_Repo
    {
        private List<Car> _repo = new List<Car>();

        //Create
        public bool AddCar(Car car)
        {
            int startingCount = _repo.Count;
            _repo.Add(car);
            bool wasAdded = (_repo.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Read

        //Get All Cars
        public List<Car> GetAllCars()
        {
            return _repo;
        }
        //Get IndividualCar
        public Car GetCarByID(string ID)
        {
            foreach (Car car in _repo)
            {
                if(car.CarID == ID)
                { return car; }
            }
            return null;
        }


        //Update Car in Repo
        public bool UpdateExistingCar(string id, Car newCar)
        {
            var oldCar = GetCarByID(id);
            if (oldCar != null)
            { //Check type of Car object. //Implemented in other repos.
                if (oldCar is HybridCar)
                {
                    //Hybrid car stuff
                    ((HybridCar)oldCar).AvgMPG = ((HybridCar)newCar).AvgMPG;
                    ((HybridCar)oldCar).BatteryCapacity = ((HybridCar)newCar).BatteryCapacity;

                }
                else if (oldCar is GasCar)
                {
                    ((GasCar)oldCar).AvgMPG = ((GasCar)newCar).AvgMPG;
                }
                else if (oldCar is ElectricCar)
                {
                    ((ElectricCar)oldCar).BatteryCapacity = ((ElectricCar)newCar).BatteryCapacity;
                    ((ElectricCar)oldCar).ChargeTime = ((ElectricCar)newCar).ChargeTime;


                }

                // Rest of properties here
                oldCar.Make = newCar.Make;
                oldCar.Model = newCar.Model;
                oldCar.Year = newCar.Year;
                oldCar.Type = newCar.Type;
                oldCar.AvgRange = newCar.AvgRange;

                return true;

            }

            else { return false; }
        }


        //Delete CAr
        public bool DeleteCar(Car car)
        {
            bool deleteCar = _repo.Remove(car);
            return deleteCar;
        }

    }
}
