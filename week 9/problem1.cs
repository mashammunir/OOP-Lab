using System;

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

    public double GetArea()
    {
        return 3.14159 * radius * radius;
    }

    public override string ToString()
    {
        return "Circle[radius=" + radius + ",color=" + color + "]";
    }
}

class Cylinder : Circle
{
    protected double height = 1.0;

    public Cylinder() : base()
    {
    }

    public Cylinder(double radius) : base(radius)
    {
    }

    public Cylinder(double radius, double height) : base(radius)
    {
        this.height = height;
    }

    public Cylinder(double radius, double height, string color)
        : base(radius, color)
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

    public double GetVolume()
    {
        return GetArea() * height;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Cylinder c1 = new Cylinder();

        Console.WriteLine(c1.ToString());
        Console.WriteLine("Height: " + c1.GetHeight());
        Console.WriteLine("Volume: " + c1.GetVolume());

        Console.WriteLine();

        Cylinder c2 = new Cylinder(5.0, 10.0, "blue");

        Console.WriteLine(c2.ToString());
        Console.WriteLine("Height: " + c2.GetHeight());
        Console.WriteLine("Volume: " + c2.GetVolume());
    }
}