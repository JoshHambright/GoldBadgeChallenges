using Badges;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_UI
{
    public class ProgramUI
    {
        //Repo Field
        private Badge_Repo _repo = new Badge_Repo();

        public void Run()
        {
            SeedBadges();
            Menu();
        }

        public void SeedBadges()
        {
            Badge badge1 = new Badge(12345, new List<string> { "A7" });
            Badge badge2 = new Badge(22345, new List<string> { "A1", "A4", "B1", "B2" });
            Badge badge3 = new Badge(32345, new List<string> { "A4", "A5" });
            _repo.AddBadge(badge1);
            _repo.AddBadge(badge2);
            _repo.AddBadge(badge3);
        }

        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Header();
                Console.WriteLine("=-=-=-=- Main Menu -=-=-=-=");
                Console.WriteLine("1> Add a Badge");
                Console.WriteLine("2> Edit a Badge");
                Console.WriteLine("3> Delete a Badge");
                Console.WriteLine("4> View all Badges");
                Console.WriteLine("5> Exit Badge Program");
                Console.WriteLine("Please enter a number to proceed");
                string menuSelection = Console.ReadLine();

                switch (menuSelection)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        //EditBadge();
                        break;
                    case "3":
                        //DeleteBadge();
                        break;
                    case "4":
                        //ViewAll();
                        break;
                    case "5":
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public void AddBadge()
        {
            
            Console.Clear();
            Header();
            Console.WriteLine("=-=-=-=- Add a Badge -=-=-=-=");
            Console.WriteLine("What is the number on the Badge:");
            int badgeNum = Convert.ToInt32(Console.ReadLine());
            Badge newBadge = new Badge(badgeNum);
            bool looper = true;
            List<string> doors = new List<string>();
            while (looper)
            {
                Console.WriteLine("Enter a door that Badge#" + badgeNum + " needs access to: ");
                doors.Add(Console.ReadLine());
                Console.WriteLine("Any other doors (y/n)?");
                string moreDoors = Console.ReadLine();
                if (moreDoors.ToLower() == "n")
                {
                    looper = false;
                }
            }
            newBadge.Doors = doors;

            bool wasAdded = _repo.AddBadge(newBadge);
            if (wasAdded == true)
            {
                Console.WriteLine($"Badge #{newBadge.BadgeID} added Successfully with access to Doors: {newBadge.Doors}");
                
            }
            else
            {
                Console.WriteLine($"Oops! Something went wrong adding Badge #{newBadge.BadgeID}. Please try again.");
            }
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }




        public void Header()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                        ");
            Console.WriteLine("         ██╗  ██╗ ██████╗ ███╗   ███╗ ██████╗ ██████╗  ██████╗          ");
            Console.WriteLine("         ██║ ██╔╝██╔═══██╗████╗ ████║██╔═══██╗██╔══██╗██╔═══██╗         ");
            Console.WriteLine("         █████╔╝ ██║   ██║██╔████╔██║██║   ██║██║  ██║██║   ██║         ");
            Console.WriteLine("         ██╔═██╗ ██║   ██║██║╚██╔╝██║██║   ██║██║  ██║██║   ██║         ");
            Console.WriteLine("         ██║  ██╗╚██████╔╝██║ ╚═╝ ██║╚██████╔╝██████╔╝╚██████╔╝         ");
            Console.WriteLine("         ╚═╝  ╚═╝ ╚═════╝ ╚═╝     ╚═╝ ╚═════╝ ╚═════╝  ╚═════╝          ");
            Console.WriteLine("                                                                        ");
            Console.WriteLine("     ███████╗███████╗ ██████╗██╗   ██╗██████╗ ██╗████████╗██╗   ██╗     ");
            Console.WriteLine("     ██╔════╝██╔════╝██╔════╝██║   ██║██╔══██╗██║╚══██╔══╝╚██╗ ██╔╝     ");
            Console.WriteLine("     ███████╗█████╗  ██║     ██║   ██║██████╔╝██║   ██║    ╚████╔╝      ");
            Console.WriteLine("     ╚════██║██╔══╝  ██║     ██║   ██║██╔══██╗██║   ██║     ╚██╔╝       ");
            Console.WriteLine("     ███████║███████╗╚██████╗╚██████╔╝██║  ██║██║   ██║      ██║        ");
            Console.WriteLine("     ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝   ╚═╝      ╚═╝        ");
            Console.WriteLine("                            BADGING SYSTEM                              ");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;


        }
    }
}
