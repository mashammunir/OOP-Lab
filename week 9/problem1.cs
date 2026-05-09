using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w9p1
{
    public class Circle
    {
        protected double radius;
        protected string color;

        public Circle()
        {
            this.radius = 1.0;
            this.color = "red";
        }

        public Circle(double radius)
        {
            this.radius = radius;
            this.color = "red";
        }

        public Circle(double radius, string color)
        {
            this.radius = radius;
            this.color = color;
        }

        public double GetRadius()
        { 
            return radius;
        }
        public void SetRadius(double radius)
        {
            this.radius = radius; 
        }
        public string GetColor()
        { 
            return color;
        }
        public void SetColor(string color) 
        { 
            this.color = color; 
        }

        public virtual double GetArea()
        {
            return Math.PI * radius * radius;
        }

        public override string ToString()
        {
            return "Circle[radius=" + radius + ",color=" + color + "]";
        }
    }

    public class Cylinder : Circle
    {
        private double height = 1.0;

        public Cylinder() { }

        public Cylinder(double radius) : base(radius) { }

        public Cylinder(double radius, double height) : base(radius)
        {
            this.height = height;
        }

        public Cylinder(double radius, double height, string color) : base(radius, color)
        {
            this.height = height;
        }

        public double GetHeight() 
        { 
            return height;
        }
        public void SetHeight(double height)
        {
            this.height = height; 
        }

        public override double GetArea()
        {
            return 2 * Math.PI * radius * (radius + height);
        }

        public double GetVolume()
        {
            return Math.PI * radius * radius * height;
        }

        public override string ToString()
        {
            return "Cylinder[radius=" + radius + ",color=" + color + ",height=" + height + "]";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====== POLYMORPHISM DEMO ======");
            Console.WriteLine();

            Circle shape1 = new Cylinder();
            Circle shape2 = new Cylinder(3.0, 7.0);
            Circle shape3 = new Cylinder(4.0, 10.0, "blue");

            Circle[] shapes = { shape1, shape2, shape3 };

            Console.WriteLine("--- Before Setting Height ---");
            Console.WriteLine();

            foreach (Circle s in shapes)
            {
                Console.WriteLine(s.ToString());
                Console.WriteLine("Area (Polymorphic): " + s.GetArea());
                Console.WriteLine();
            }

            Console.WriteLine("--- After Setting Height ---");
            Console.WriteLine();

            ((Cylinder)shape1).SetHeight(5.0);

            foreach (Circle s in shapes)
            {
                Cylinder c = (Cylinder)s;
                Console.WriteLine(c.ToString());
                Console.WriteLine("Height : " + c.GetHeight());
                Console.WriteLine("Volume : " + c.GetVolume());
                Console.WriteLine("Area   : " + c.GetArea());
                Console.WriteLine();
            }

            Console.WriteLine("====== OBJECT TYPE CHECK ======");
            Console.WriteLine();

            foreach (Circle s in shapes)
            {
                if (s is Cylinder)
                {
                    Console.WriteLine(s.ToString() + " => IS a Cylinder");
                }
            }
        }
    }
}