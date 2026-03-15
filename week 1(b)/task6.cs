using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3task6
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            double savedMoney = 0;
            int toyCount = 0;
            int evenCount = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    evenCount++;
                    savedMoney += evenCount * 10;
                }
                else
                {
                    toyCount++;
                }
            }

            savedMoney -= evenCount;
            savedMoney += toyCount * toyPrice;

            double difference = savedMoney - washingMachinePrice;

            if (difference >= 0)
            {
                Console.WriteLine("Yes! {0:F2}", difference);
            }
            else
            {
                Console.WriteLine("No! {0:F2}", Math.Abs(difference));
            }
        }
    
    }
}
