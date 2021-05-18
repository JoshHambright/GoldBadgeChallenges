using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {


        public static int FindMaxSum(List<int> list)
        {
            list.Sort();
            list.Reverse();
            int largest = list.Max();
            int second = list.Min();
            foreach (int i in list)
            {
                if (i > second && i != largest)
                {
                    second = i;
                }
            }
            return largest + second;
        }

        public static void Main(string[] args)
        {
            List<int> list = new List<int> { 5, 9, 7, 11 };
            Console.WriteLine(FindMaxSum(list));
            Console.ReadKey();
        }
    }
}
