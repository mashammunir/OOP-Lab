using System;

namespace lab3task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int marks;
            Console.WriteLine("Enter your marks:");
            marks = int.Parse(Console.ReadLine());

            if (marks > 50)
            {
                Console.WriteLine("You are Passed");
            }
            else
            {
                Console.WriteLine("You are Failed");
            }
            Console.Read();
        }
    }
}