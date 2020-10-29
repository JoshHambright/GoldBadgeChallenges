using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting
{
    public enum CustomerType { Potential = 1, Current, Past}
    public class Customer
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public CustomerType Type { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public string Email
        {
            get
            {
                if (Type == CustomerType.Current)
                {
                    return "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                }
                else if (Type == CustomerType.Potential)
                {
                    return "We currently have the lowest rates on Helicopter Insurance!";
                }
                else if (Type == CustomerType.Past)
                {
                    return "It's been a long time since we've heard from you, we want you back.";
                }
                else { return null; }
            }
        }
        public Customer() { }
        public Customer(string lastName, string firstName, CustomerType type) 
        {
            LastName = lastName;
            FirstName = firstName;
            Type = type;
        }
    }
}
