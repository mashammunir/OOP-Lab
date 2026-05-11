using System;
using System.Collections.Generic;

class Shape
{
    public virtual double GetArea()
    {
        return 0;
    }

    public virtual string GetShapeType()
    {
        return "Shape";
    }
}

class Rectangle : Shape
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

    public override string GetShapeType()
    {
        return "Rectangle";
    }
}

class Square : Shape
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

    public override string GetShapeType()
    {
        return "Square";
    }
}

class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public override double GetArea()
    {
        return 3.14159 * radius * radius;
    }

    public override string GetShapeType()
    {
        return "Circle";
    }
}

class RectangleUI
{
    public Rectangle CreateShape()
    {
        Console.Write("Enter Width: ");
        double width = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Height: ");
        double height = Convert.ToDouble(Console.ReadLine());

        return new Rectangle(width, height);
    }
}

class SquareUI
{
    public Square CreateShape()
    {
        Console.Write("Enter Side: ");
        double side = Convert.ToDouble(Console.ReadLine());

        return new Square(side);
    }
}

class CircleUI
{
    public Circle CreateShape()
    {
        Console.Write("Enter Radius: ");
        double radius = Convert.ToDouble(Console.ReadLine());

        return new Circle(radius);
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        RectangleUI rectangleUI = new RectangleUI();
        SquareUI squareUI = new SquareUI();
        CircleUI circleUI = new CircleUI();

        shapes.Add(rectangleUI.CreateShape());
        shapes.Add(squareUI.CreateShape());
        shapes.Add(circleUI.CreateShape());

        Console.WriteLine("\nShapes Information:\n");

        foreach (Shape s in shapes)
        {
            Console.WriteLine("Shape Type: " + s.GetShapeType());
            Console.WriteLine("Area: " + s.GetArea());
            Console.WriteLine();
        }
    }
}