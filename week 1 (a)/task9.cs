using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2task9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str;
        
            Console.WriteLine("Enter Floating point value:");
            str = Console.ReadLine();
            Console.WriteLine(str);
            float num = float.Parse(str);
            Console.WriteLine("The Floating Value is:");
            Console.WriteLine(num);
            Console.ReadKey();
        }
    }
}
