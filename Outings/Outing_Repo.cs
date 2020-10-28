using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Outings
{
    public class Outing_Repo
    {
        private List<Outing> _outings = new List<Outing>();


        //Create

        public bool AddOuting(Outing outing)
        {
            int startingCount = _outings.Count;

            _outings.Add(outing);
            bool wasAdded = (_outings.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Read

        public List<Outing> GetAllOutings() //Get All Outings in Repo
        {
            return _outings;
        }

        public Outing GetOutingByDate(DateTime datetime)  // Get individual outings by date
        {
            foreach (Outing outing in _outings)
            {
                if(outing.EventDate == datetime)
                {
                    return outing;
                }
            }
            return null;
        }


        //Update
        public bool UpdateExistingOuting(DateTime oldDate, Outing newOuting)
        {
            Outing oldOuting = GetOutingByDate(oldDate);

            if (oldOuting != null)
            {
                oldOuting.EventDate = newOuting.EventDate;
                oldOuting.Attendance = newOuting.Attendance;
                oldOuting.Type = newOuting.Type;
                oldOuting.CostOfEvent = newOuting.CostOfEvent;
                return true;
            }
            else { return false; }
        }



        //Delete

        public bool DeleteExistingOuting(Outing outing)
        {
            bool deleteOuting = _outings.Remove(outing);
            return deleteOuting;
        }
    }
}
