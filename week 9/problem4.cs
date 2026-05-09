using System;
using System.Collections.Generic;

namespace w9p4
{
    public class Shape
    {
        public virtual double GetArea()
        {
            return 0;
        }

        public override string ToString()
        {
            return "Shape";
        }
    }

    public class Rectangle : Shape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public override double GetArea()
        {
            return width * height;
        }

        public override string ToString()
        {
            return "Rectangle";
        }
    }

    public class Square : Shape
    {
        private double side;

        public Square(double side)
        {
            this.side = side;
        }

        public override double GetArea()
        {
            return side * side;
        }

        public override string ToString()
        {
            return "Square";
        }
    }

    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * radius * radius;
        }

        public override string ToString()
        {
            return "Circle";
        }
    }

    public class RectangleUI
    {
        public static Rectangle Create()
        {
            Console.Write("Enter Width: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Enter Height: ");
            double height = double.Parse(Console.ReadLine());
            return new Rectangle(width, height);
        }
    }

    public class SquareUI
    {
        public static Square Create()
        {
            Console.Write("Enter Side: ");
            double side = double.Parse(Console.ReadLine());
            return new Square(side);
        }
    }

    public class CircleUI
    {
        public static Circle Create()
        {
            Console.Write("Enter radius: ");
            double radius = double.Parse(Console.ReadLine());
            return new Circle(radius);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapeList = new List<Shape>();

            shapeList.Add(RectangleUI.Create());
            shapeList.Add(CircleUI.Create());
            shapeList.Add(SquareUI.Create());
            shapeList.Add(RectangleUI.Create());
            shapeList.Add(CircleUI.Create());

            Console.WriteLine();

            for (int i = 0; i < shapeList.Count; i++)
            {
                Console.WriteLine((i + 1) + ".The shape is " + shapeList[i].ToString() + " and its area is " + shapeList[i].GetArea());
            }
        }
    }
}