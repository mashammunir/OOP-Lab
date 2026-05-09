using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w9c2
{
    class Circle
    {
        protected double radius = 1.0;
        protected string color = "red";

        public Circle()
        {
        }

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public Circle(double radius, string color)
        {
            this.radius = radius;
            this.color = color;
        }

        public double getRadius()
        {
            return radius;
        }

        public void setRadius(double radius)
        {
            this.radius = radius;
        }

        public string getColor()
        {
            return color;
        }

        public void setColor(string color)
        {
            this.color = color;
        }

        public double getArea()
        {
            return Math.PI * radius * radius;
        }

        public override string ToString()
        {
            return "Circle[radius=" + radius + ",color=" + color + "]";
        }
    }

    class Cylinder : Circle
    {
        protected double height = 1.0;

        public Cylinder()
        {
        }

        public Cylinder(double radius) : base(radius)
        {
        }

        public Cylinder(double radius, double height) : base(radius)
        {
            this.height = height;
        }

        public Cylinder(double radius, double height, string color) : base(radius, color)
        {
            this.height = height;
        }

        public double getHeight()
        {
            return height;
        }

        public void setHeight(double height)
        {
            this.height = height;
        }

        public double getVolume()
        {
            return getArea() * height;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle();
            Console.WriteLine(c1.ToString());
            Console.WriteLine("Area: " + c1.getArea());

            Circle c2 = new Circle(5.0);
            Console.WriteLine(c2.ToString());
            Console.WriteLine("Area: " + c2.getArea());

            Circle c3 = new Circle(3.0, "blue");
            Console.WriteLine(c3.ToString());
            Console.WriteLine("Area: " + c3.getArea());

            Cylinder cy1 = new Cylinder();
            Console.WriteLine("Height: " + cy1.getHeight());
            Console.WriteLine("Volume: " + cy1.getVolume());

            Cylinder cy2 = new Cylinder(5.0);
            Console.WriteLine("Height: " + cy2.getHeight());
            Console.WriteLine("Volume: " + cy2.getVolume());

            Cylinder cy3 = new Cylinder(5.0, 10.0);
            Console.WriteLine("Height: " + cy3.getHeight());
            Console.WriteLine("Volume: " + cy3.getVolume());

            Cylinder cy4 = new Cylinder(5.0, 10.0, "green");
            Console.WriteLine("Height: " + cy4.getHeight());
            Console.WriteLine("Volume: " + cy4.getVolume());
        }
    }
}
}