using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week8_task5_
{
    class car
    {
        protected string model;
        protected string color;
        protected double price;

        public car(string model, string color, double price)
        {
            this.model = model;
            this.color = color;
            this.price = price;
        }

        public void setModel(string model)
        {
            this.model = model;
        }

        public string getModel()
        {
            return this.model;
        }

        public void setColor(string color)
        {
            this.color = color;
        }

        public string getColor()
        {
            return this.color;
        }

        public void setPrice(double price)
        {
            this.price = price;
        }

        public double getPrice()
        {
            return this.price;
        }

        public virtual double calculateFuel(double distance)
        {
            return distance * 1.0;
        }

        public string toString()
        {
            return "Model: " + model +
                   "\nColor: " + color +
                   "\nPrice: " + price;
        }
    }

    class bmw : car
    {
        public bmw(string model, string color, double price)
            : base(model, color, price)
        {
        }

        public override double calculateFuel(double distance)
        {
            return distance * 0.08;
        }
    }

    class audi : car
    {
        public audi(string model, string color, double price)
            : base(model, color, price)
        {
        }

        public override double calculateFuel(double distance)
        {
            return distance * 0.10;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            bmw c1 = new bmw("BMW X5", "Black", 15000000);
            Console.WriteLine(c1.toString());
            Console.WriteLine("Fuel Used: " + c1.calculateFuel(100));

            Console.WriteLine("----------------------");

            audi c2 = new audi("Audi A6", "White", 12000000);
            Console.WriteLine(c2.toString());
            Console.WriteLine("Fuel Used: " + c2.calculateFuel(100));
        }
    }
}