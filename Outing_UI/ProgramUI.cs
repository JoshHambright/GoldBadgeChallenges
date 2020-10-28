using Outings;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outing_UI
{
    public class ProgramUI
    {

        //Repo
        private Outing_Repo _repo = new Outing_Repo();


        public void Run()
        {
            SeedOutings();
            MainMenu();

        }

        private void SeedOutings()
        {
            // Seed a few outings here
            Outing outing1 = new Outing(new DateTime(2020, 1, 30), EventType.Bowling, 50, 1500m);
            Outing outing2 = new Outing(new DateTime(2020, 2, 27), EventType.Bowling, 15, 500m);
            Outing outing3 = new Outing(new DateTime(2020, 2, 11), EventType.AmusementPark, 15, 3000m);
            Outing outing4 = new Outing(new DateTime(2020, 4, 04), EventType.AmusementPark, 15, 3000m);
            Outing outing5 = new Outing(new DateTime(2020, 7, 17), EventType.AmusementPark, 15, 3000m);
            Outing outing6 = new Outing(new DateTime(2020, 8, 15), EventType.Concert, 25, 3000m);
            Outing outing7 = new Outing(new DateTime(2020, 8, 20), EventType.Concert, 70, 5000m);
            Outing outing8 = new Outing(new DateTime(2020, 9, 01), EventType.Golf, 10, 600m);
            Outing outing9 = new Outing(new DateTime(2020, 10, 12), EventType.Golf, 7, 200m);
            Outing outing10 = new Outing(new DateTime(2020, 10, 22), EventType.Golf, 20, 1200m);
            _repo.AddOuting(outing1);
            _repo.AddOuting(outing2);
            _repo.AddOuting(outing3);
            _repo.AddOuting(outing4);
            _repo.AddOuting(outing5);
            _repo.AddOuting(outing6);
            _repo.AddOuting(outing7);
            _repo.AddOuting(outing8);
            _repo.AddOuting(outing9);
            _repo.AddOuting(outing10);

        }

        private void MainMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {

                Console.Clear();
                KomodoLogo();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("             Company Outings Database");
                Console.ResetColor();
                Console.WriteLine("1> Display All Outings"); // Call a Method to print all outings on the screen all pretty like
                Console.WriteLine("2> Add an Outing"); // Call a method to add an outing to the repo
                Console.WriteLine("3> Reporting"); //Call a method to select which report to run
                Console.WriteLine("4. Exit");
                string menuSelection = Console.ReadLine();

                switch (menuSelection)
                {
                    case "1":
                        ShowAllOutings();
                        break;
                    case "2":
                        AddOuting();
                        break;
                    case "3":
                        Reporting();
                        break;
                    case "4":
                        continueToRun = false;
                        break;

                }
            }
        }

        private void Reporting()
        {

            Console.Clear();
            KomodoLogo();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("             Outing Reporting");
            Console.ResetColor();



            Console.ForegroundColor = ConsoleColor.White;
            decimal totalOutingCost = 0;
            decimal totalGolfCost = 0;
            decimal totalAmusementCost = 0;
            decimal totalBowlingCost = 0;
            decimal totalConcertCost = 0;
            List<Outing> listOfOutings = _repo.GetAllOutings();
            foreach(Outing outing in listOfOutings)         // Loop to calculate total costs of all events in the repo.
            {
                totalOutingCost += outing.CostOfEvent;
                if (outing.Type == EventType.AmusementPark)
                {
                    totalAmusementCost += outing.CostOfEvent;
                }
                else if (outing.Type == EventType.Golf)
                {
                    totalGolfCost += outing.CostOfEvent;
                }
                else if (outing.Type == EventType.Concert)
                {
                    totalConcertCost += outing.CostOfEvent;
                }
                else if (outing.Type == EventType.Bowling)
                {
                    totalBowlingCost += outing.CostOfEvent;
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Total Spending on Outings:                 $" + totalOutingCost);
            Console.WriteLine("Total Spending on Golf Outings:            $" + totalGolfCost);
            Console.WriteLine("Total Spending on Amusement Park Outings:  $" + totalAmusementCost);
            Console.WriteLine("Total Spending on Concert Outings:         $" + totalConcertCost);
            Console.WriteLine("Total Spending on Bowling Outings:         $" + totalBowlingCost);



            Console.ResetColor();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

        }

        private void AddOuting()
        {
            Outing newOuting = new Outing();
            bool looper = true;
            while (looper)
            {
                // Method for event team to add an outing event
                Console.Clear();
                KomodoLogo();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("             Add New Outing Event");
                Console.ResetColor();

                DateTime date = new DateTime();
                bool dateLoop = false;
                while (!dateLoop)
                {
                    Console.WriteLine("Please Enter the Event Date (MMMM dd, YYYY):");
                    string dateString = Console.ReadLine();
                    dateLoop = DateTime.TryParse(dateString, out date);

                }
                newOuting.EventDate = date;
                Console.Clear();
                KomodoLogo();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("             Add New Outing Event");
                Console.ResetColor();
                Console.WriteLine("Date: " + newOuting.EventDate.ToString("MMMM dd,yyyy"));
                Console.WriteLine("Event Type");
                Console.WriteLine("1> Golf");
                Console.WriteLine("2> Bowling");
                Console.WriteLine("3> Amusement Park");
                Console.WriteLine("4> Concert");
                Console.WriteLine("Please enter the number for the event type:");
                bool eventSelect = true;
                string eventType = "1";
                while (eventSelect)
                {
                    eventType = Console.ReadLine();
                    if (eventType == "1" || eventType == "2" || eventType == "3" || eventType == "4")
                    {
                        eventSelect = false;

                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid selection 1, 2, 3, or 4");
                    }
                }
                newOuting.Type = (EventType)int.Parse(eventType);

                Console.Clear();
                KomodoLogo();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("             Add New Outing Event");
                Console.ResetColor();
                Console.WriteLine("Date: " + newOuting.EventDate.ToString("MMMM dd,yyyy"));
                Console.WriteLine("Event Type: " + newOuting.Type);
                Console.WriteLine("Please enter the attendance number for this event:");
                string attendance = Console.ReadLine();
                newOuting.Attendance = Convert.ToInt32(attendance);
                Console.WriteLine("Enter cost for this event: ");
                string cost = Console.ReadLine();
                newOuting.CostOfEvent = Decimal.Parse(cost);


                Console.Clear();
                KomodoLogo();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("             Add New Outing Event");
                Console.ResetColor();
                Console.WriteLine("Date: " + newOuting.EventDate.ToString("MMMM dd,yyyy"));
                Console.WriteLine("Event Type: " + newOuting.Type);
                Console.WriteLine("Event Attendance: " + newOuting.Attendance);
                Console.WriteLine("Event Cost: " + newOuting.CostOfEvent);
                Console.WriteLine();
                Console.WriteLine("Does all of this look correct? \nEnter Y to commit this event. \nEnter N to start over entering this event.");
                string correct = Console.ReadLine();
                if (correct.ToLower() == "y")
                {
                    looper = false;
                }
            }
            bool wasAdded = _repo.AddOuting(newOuting);
            if (wasAdded == true)
            {
                Console.WriteLine("Your Content was added to the database.");
                Console.WriteLine("Press any key to Continue.");
            }
            else
            {
                Console.WriteLine("Oops. Something went wrong. Your content was not added.  Please Try Again");
                Console.WriteLine("Press any key to continue.");
            }

            Console.ReadKey();

        }
        private void ShowAllOutings()
        {
            Console.Clear();
            KomodoLogo();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("------Showing All Outings-------");
            Console.ResetColor();
            Console.WriteLine("                Date                 Type           Attendance         Cost of Event     Cost Per Person");
            List<Outing> listOfOutings = _repo.GetAllOutings();
            listOfOutings.Sort((x, y) => x.EventDate.CompareTo(y.EventDate));
            foreach (Outing outing in listOfOutings)
            {
                Console.WriteLine($"{outing.EventDate.ToString("MMMM dd,yyyy"),20} {outing.Type,20} {outing.Attendance,20} {outing.CostOfEvent,20} {outing.CostPerPerson,20}");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private void KomodoLogo()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("██╗  ██╗ ██████╗ ███╗   ███╗ ██████╗ ██████╗  ██████╗ ");
            Console.WriteLine("██║ ██╔╝██╔═══██╗████╗ ████║██╔═══██╗██╔══██╗██╔═══██╗");
            Console.WriteLine("█████╔╝ ██║   ██║██╔████╔██║██║   ██║██║  ██║██║   ██║");
            Console.WriteLine("██╔═██╗ ██║   ██║██║╚██╔╝██║██║   ██║██║  ██║██║   ██║");
            Console.WriteLine("██║  ██╗╚██████╔╝██║ ╚═╝ ██║╚██████╔╝██████╔╝╚██████╔╝");
            Console.WriteLine("╚═╝  ╚═╝ ╚═════╝ ╚═╝     ╚═╝ ╚═════╝ ╚═════╝  ╚═════╝ ");
            Console.ResetColor();



        }
    }
}
