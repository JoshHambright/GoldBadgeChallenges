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
        public bool UpdateExistingCar(string id)
        {
            var oldCar = GetCarByID(id);
            if (oldCar != null)
            { //Check type of Car object.
                if (oldCar is HybridCar)
                {
                    //Hybrid car stuff
                }
                else if (oldCar is GasCar)
                {
                    //Gas Car Stuff
                }
                else if (oldCar is ElectricCar)
                {
                    //Electric car properties
                }

                // Rest of properties here
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
