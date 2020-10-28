using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outings
{
    public enum EventType { Golf=1, Bowling, AmusementPark, Concert }
    public class Outing
    {
        public DateTime EventDate { get; set; }
        public EventType Type { get; set; }

        public int Attendance { get; set; }

        public decimal CostOfEvent { get; set; } //x.ym

        public decimal CostPerPerson
        {
            get
            {
                decimal cpp = CostOfEvent / Attendance;
                cpp = Decimal.Round(cpp, 2);
                return cpp;
            }
        }

        public Outing() { }

        public Outing(DateTime eventDate, EventType type, int attendance, decimal costofevent)
        {
            EventDate = eventDate;
            Type = type;
            Attendance = attendance;
            CostOfEvent = costofevent;
        }
    }
}
