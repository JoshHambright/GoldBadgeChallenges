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
                Console.WriteLine("3> Delete all Doors from a Badge");
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
                        EditBadge();
                        break;
                    case "3":
                        DeleteAllDoorsOnBadge();
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
                Console.WriteLine("Enter a door that Badge #" + badgeNum + " needs access to: ");
                doors.Add(Console.ReadLine());
                Console.WriteLine("Any other doors (y/n)?");
                string moreDoors = Console.ReadLine();
                if (moreDoors.ToLower() == "n")
                {
                    looper = false;
                }
            }
            newBadge.Doors = doors;
            string doorResult = string.Join(",", doors);
            bool wasAdded = _repo.AddBadge(newBadge);
            if (wasAdded == true)
            {
                Console.WriteLine($"Badge #{newBadge.BadgeID} added Successfully with access to Doors: {doorResult}.");

            }
            else
            {
                Console.WriteLine($"Oops! Something went wrong adding Badge #{newBadge.BadgeID}. Please try again.");
            }
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }

        public void EditBadge()
        {
            Console.Clear();
            Header();
            Console.WriteLine("=-=-=-=- Update a Badge -=-=-=-=");
            Console.WriteLine("What is the badge number to update:");
            int badgeNum = Convert.ToInt32(Console.ReadLine());
            Badge badgeToUpdate = _repo.GetABadgeByID(badgeNum);
            List<string> doorsOnBadge = new List<string>();
            doorsOnBadge = badgeToUpdate.Doors;
            if (badgeToUpdate != null)
            {
                bool looper = true;
                while (looper)
                {

                    Console.Clear();
                    Header();
                    Console.WriteLine("=-=-=-=- Update a Badge -=-=-=-=");
                    string doorsResult = string.Join(",", badgeToUpdate.Doors);
                    Console.WriteLine($"Badge #{badgeToUpdate.BadgeID} has access to doors: {doorsResult}.");
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("     1> Remove a door");
                    Console.WriteLine("     2> Add a door");
                    Console.WriteLine("     3> Finish Updating Badge");
                    string menuSelect = Console.ReadLine();
                    switch (menuSelect)
                    {
                        case "1":
                            Console.WriteLine("Which door would you like to remove?");
                            string doorToRemove = Console.ReadLine();
                            doorsOnBadge.Remove(doorToRemove);
                            badgeToUpdate.Doors = doorsOnBadge;
                            Console.WriteLine("Door Removed");
                            doorsResult = string.Join(",", badgeToUpdate.Doors);
                            Console.WriteLine($"Badge #{badgeToUpdate.BadgeID} has access to doors: {doorsResult}.");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;
                        case "2":
                            Console.WriteLine("Which door would you like to add?");
                            string doorToAdd = Console.ReadLine();
                            doorsOnBadge.Add(doorToAdd);
                            badgeToUpdate.Doors = doorsOnBadge;
                            Console.WriteLine("Door Added");
                            doorsResult = string.Join(",", badgeToUpdate.Doors);
                            Console.WriteLine($"Badge #{badgeToUpdate.BadgeID} has access to doors: {doorsResult}.");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;
                        case "3":
                            looper = false;
                            break;
                    }

                }
                bool wasUpdate = _repo.UpdateExistingBadge(badgeNum, badgeToUpdate);
                if (wasUpdate == true)
                {
                    Console.WriteLine("Badge updated successfully");
                }
                else
                {
                    Console.WriteLine("Oops! Something went wrong.  Please try update again.");
                }

            }
            else
            {
                Console.WriteLine("Badge ID not found.");

            }
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();

        }

        public void DeleteAllDoorsOnBadge()
        {
            Console.Clear();
            Header();
            Console.WriteLine("=-=-=-=- Delete All Doors From Badge -=-=-=-=");
            Console.WriteLine("What is the badge number to update:");
            int badgeNum = Convert.ToInt32(Console.ReadLine());
            Badge badgeToUpdate = _repo.GetABadgeByID(badgeNum);
            List<string> doorsOnBadge = new List<string>();
            if (badgeToUpdate != null)
            {
                string doorsResult = string.Join(",", badgeToUpdate.Doors);
                Console.WriteLine($"Badge #{badgeToUpdate.BadgeID} has access to doors: {doorsResult}.");
                Console.WriteLine($"Do you want to clear all doors from Badge #{badgeToUpdate.BadgeID}? (y/n)");
                string deleteAll = Console.ReadLine();
                if (deleteAll.ToLower() == "y")
                {
                    badgeToUpdate.Doors.Clear();
                    bool wasUpdate = _repo.UpdateExistingBadge(badgeNum, badgeToUpdate);
                    if (wasUpdate == true)
                    {
                        Console.WriteLine($"All Doors Deleted from Badge #{badgeNum}");
                    }
                    else
                    {
                        Console.WriteLine("Oops! Something went wrong.  Please try update again.");
                    }

                }
                else
                {
                    Console.WriteLine("Canceled.");
                }
            }
            else
            {
                Console.WriteLine("Badge ID not found.");

            }
            Console.WriteLine("Press any key to return to the main menu");
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
