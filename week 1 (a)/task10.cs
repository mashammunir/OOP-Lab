using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2task10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float length;
            float area;
            string str;
            Console.WriteLine("Enter the length :");
            str = Console.ReadLine();
            length = float.Parse(str);
            area = length * length;
            Console.WriteLine("The area of the square is : ");
            Console.Write(area);
            Console.ReadKey();
        }
    }
}
