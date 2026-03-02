using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2task2
{
    class Calculator
    {
        public double Num1;
        public double Num2;

        public Calculator(double n1, double n2)
        {
            Num1 = n1;
            Num2 = n2;
        }

        public double Add()
        {
            return Num1 + Num2;
        }

        public double Subtract()
        {
            return Num1 - Num2;
        }

        public double Multiply()
        {
            return Num1 * Num2;
        }

        public double Divide()
        {
            return Num1 / Num2;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator c = new Calculator(20, 5);

            Console.WriteLine("Add: " + c.Add());
            Console.WriteLine("Subtract: " + c.Subtract());
            Console.WriteLine("Multiply: " + c.Multiply());
            Console.WriteLine("Divide: " + c.Divide());
        }
    }
}