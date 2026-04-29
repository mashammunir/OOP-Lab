using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w8c3
{
    class Person
    {
        protected string name;
        protected string address;

        public Person(string name, string address)
        {
            this.name = name;
            this.address = address;
        }

        public string getName()
        {
            return name;
        }

        public string getAddress()
        {
            return address;
        }

        public void setAddress(string address)
        {
            this.address = address;
        }

        public override string ToString()
        {
            return "Person[name=" + name + ",address=" + address + "]";
        }
    }

    class Student : Person
    {
        protected string program;
        protected int year;
        protected double fee;

        public Student(string name, string address, string program, int year, double fee)
            : base(name, address)
        {
            this.program = program;
            this.year = year;
            this.fee = fee;
        }

        public string getProgram()
        {
            return program;
        }

        public void setProgram(string program)
        {
            this.program = program;
        }

        public int getYear()
        {
            return year;
        }

        public void setYear(int year)
        {
            this.year = year;
        }

        public double getFee()
        {
            return fee;
        }

        public void setFee(double fee)
        {
            this.fee = fee;
        }
    }

    class Staff : Person
    {
        protected string school;
        protected double pay;

        public Staff(string name, string address, string school, double pay)
            : base(name, address)
        {
            this.school = school;
            this.pay = pay;
        }

        public string getSchool()
        {
            return school;
        }

        public void setSchool(string school)
        {
            this.school = school;
        }

        public double getPay()
        {
            return pay;
        }

        public void setPay(double pay)
        {
            this.pay = pay;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Ali", "Lahore");
            Console.WriteLine(p1.ToString());
            Console.WriteLine("Name: " + p1.getName());
            Console.WriteLine("Address: " + p1.getAddress());

            Student s1 = new Student("Ahmed", "Karachi", "Computer Science", 2, 50000.0);
            Console.WriteLine(s1.ToString());
            Console.WriteLine("Program: " + s1.getProgram());
            Console.WriteLine("Year: " + s1.getYear());
            Console.WriteLine("Fee: " + s1.getFee());

            Staff st1 = new Staff("Sara", "Islamabad", "Engineering", 80000.0);
            Console.WriteLine(st1.ToString());
            Console.WriteLine("School: " + st1.getSchool());
            Console.WriteLine("Pay: " + st1.getPay());
        }
    }
}