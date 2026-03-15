using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str;
            str = Console.ReadLine();
            Console.WriteLine("You have inputted:");
            Console.WriteLine(str);
            int num = int.Parse(str);
            Console.WriteLine(num);
            Console.ReadKey();
        }
    }
}
