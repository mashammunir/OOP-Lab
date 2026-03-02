using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2task4
{
    class Student
    {
        public string Name;
        public double Marks;

        public Student(string name, double marks)
        {
            Name = name;
            Marks = marks;
        }

        public double CalculateAggregate()
        {
            return Marks;
        }
    }

    internal class Program
    {
        static List<Student> students = new List<Student>();

        static void AddStudent()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Marks: ");
            double marks = double.Parse(Console.ReadLine());

            students.Add(new Student(name, marks));
        }

        static void ShowStudents()
        {
            foreach (Student s in students)
            {
                Console.WriteLine(s.Name + " - " + s.Marks);
            }
        }

        static void CalculateAggregate()
        {
            foreach (Student s in students)
            {
                Console.WriteLine(s.Name + " Aggregate: " + s.CalculateAggregate());
            }
        }

        static void TopStudents()
        {
            if (students.Count == 0) return;

            double max = students.Max(s => s.Marks);

            foreach (Student s in students)
            {
                if (s.Marks == max)
                {
                    Console.WriteLine("Top Student: " + s.Name + " - " + s.Marks);
                }
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Show Students");
                Console.WriteLine("3. Calculate Aggregate");
                Console.WriteLine("4. Top Students");
                Console.WriteLine("5. Exit");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1) AddStudent();
                else if (choice == 2) ShowStudents();
                else if (choice == 3) CalculateAggregate();
                else if (choice == 4) TopStudents();
                else if (choice == 5) break;
            }
        }
    }
}