using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBQ
{
    public class Party
    {
        public int BeefBurgerTickets { get; set; }
        public int VeggieBurgerTickets { get; set; }
        public int HotDogTickets { get; set; }
        public int IceCreamTickets { get; set; }
        public int PopcornTickets { get; set; }
        public int BurgerBoothTickets
        {
            get
            {
                return BeefBurgerTickets + VeggieBurgerTickets + HotDogTickets;
            }
        }
        public int IceCreamBoothTicket
        {
            get
            {
                return IceCreamTickets + PopcornTickets;
            }
        }
        public int IceCreamBoothCost
        {
            get
            {
                int costOfBurger = 3;
                return 0;
            }
        }

    }
}
