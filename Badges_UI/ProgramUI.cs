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
            Badge badge1 = new Badge(12345, new List<string>{ "A7"});
            Badge badge2 = new Badge(22345, new List<string>{ "A1", "A4", "B1", "B2"});
            Badge badge3 = new Badge(32345, new List<string>{ "A4", "A5"});
            _repo.AddBadge(badge1);
            _repo.AddBadge(badge2);
            _repo.AddBadge(badge3);
        }

        public void Menu()
        {
            Console.Clear();
            Header();


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
            Console.WriteLine("                                                                        ");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;


        }
    }
}
