using Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_UI
{
    public class ProgramUI
    {
        //Menu Repo
        private MenuItem_Repo _menu = new MenuItem_Repo();


        //Methods
        public void Run()
        {
            //SeedItemMenu();
            MainMenu();
        }

        public void SeedItemMenu()
        {
            //Seed content for menu
        }

        public void MainMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Header();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("-- Main Menu --");
                Console.WriteLine("1> View Cafe Menu Items");
                Console.WriteLine("2> Add New Cafe Menu Item");
                Console.WriteLine("3> Update Existing Cafe Menu Item");
                Console.WriteLine("4> Delete Cafe Menu Item");
                Console.WriteLine("5> Exit Cafe Menu");
                Console.WriteLine("Please enter a number to proceed:");
                string menuSelection = Console.ReadLine();

                switch (menuSelection)
                {
                    case "1":
                    //ShowMenu();
                    //break;
                    case "2":
                    //AddNewItem();
                    //break;
                    case "3":
                    //UpdateMenuItem();
                    //break;
                    case "4":
                    //DeleteItem();
                    //break;
                    case "5":
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public void Header()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("+-++-++-++-++-++-+ +-++-++-++-+");
            Console.WriteLine("|K||o||m||o||d||o| |C||a||f||e|");
            Console.WriteLine("+-++-++-++-++-++-+ +-++-++-++-+");
            Console.ResetColor();

        }
    }
}
