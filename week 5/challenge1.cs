using System;

class MyPoint
{
    public int x;
    public int y;

    public MyPoint() { x = 0; y = 0; }
    public MyPoint(int x, int y) { this.x = x; this.y = y; }

    public int GetX() { return x; }
    public int GetY() { return y; }
    public void SetX(int x) { this.x = x; }
    public void SetY(int y) { this.y = y; }
    public void SetXY(int x, int y) { this.x = x; this.y = y; }

    public double DistanceWithCords(int x, int y)
    {
        return Math.Sqrt(Math.Pow(this.x - x, 2) + Math.Pow(this.y - y, 2));
    }

    public double DistanceWithObject(MyPoint another)
    {
        return Math.Sqrt(Math.Pow(this.x - another.x, 2) + Math.Pow(this.y - another.y, 2));
    }

    public double DistanceFromZero()
    {
        return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
    }
}

class MyLine
{
    public MyPoint begin;
    public MyPoint end;

    public MyLine(MyPoint begin, MyPoint end) { this.begin = begin; this.end = end; }

    public MyPoint GetBegin() { return begin; }
    public MyPoint GetEnd() { return end; }
    public void SetBegin(MyPoint begin) { this.begin = begin; }
    public void SetEnd(MyPoint end) { this.end = end; }

    public double GetLength()
    {
        return begin.DistanceWithObject(end);
    }

    public double GetGradient()
    {
        int dx = end.x - begin.x;
        int dy = end.y - begin.y;
        if (dx == 0) { Console.WriteLine("Vertical line - gradient undefined."); return double.NaN; }
        return (double)dy / dx;
    }
}

class Program
{
    static void Main()
    {
        MyLine line = null;
        int choice;

        do
        {
            Console.WriteLine("\n1. Make a Line");
            Console.WriteLine("2. Update the begin point");
            Console.WriteLine("3. Update the end point");
            Console.WriteLine("4. Show the begin point");
            Console.WriteLine("5. Show the end point");
            Console.WriteLine("6. Get the Length of the line");
            Console.WriteLine("7. Get the Gradient of the Line");
            Console.WriteLine("8. Find the distance of begin point from zero");
            Console.WriteLine("9. Find the distance of end point from zero");
            Console.WriteLine("10. Exit");
            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Enter begin point x: "); int x1 = int.Parse(Console.ReadLine());
                Console.Write("Enter begin point y: "); int y1 = int.Parse(Console.ReadLine());
                Console.Write("Enter end point x: "); int x2 = int.Parse(Console.ReadLine());
                Console.Write("Enter end point y: "); int y2 = int.Parse(Console.ReadLine());
                line = new MyLine(new MyPoint(x1, y1), new MyPoint(x2, y2));
                Console.WriteLine("Line created!");
            }
            else if (line == null)
            {
                Console.WriteLine("Please create a line first (option 1).");
            }
            else if (choice == 2)
            {
                Console.Write("Enter new begin x: "); int x = int.Parse(Console.ReadLine());
                Console.Write("Enter new begin y: "); int y = int.Parse(Console.ReadLine());
                line.begin.SetXY(x, y);
                Console.WriteLine("Begin point updated!");
            }
            else if (choice == 3)
            {
                Console.Write("Enter new end x: "); int x = int.Parse(Console.ReadLine());
                Console.Write("Enter new end y: "); int y = int.Parse(Console.ReadLine());
                line.end.SetXY(x, y);
                Console.WriteLine("End point updated!");
            }
            else if (choice == 4)
            {
                Console.WriteLine("Begin point: (" + line.begin.x + ", " + line.begin.y + ")");
            }
            else if (choice == 5)
            {
                Console.WriteLine("End point: (" + line.end.x + ", " + line.end.y + ")");
            }
            else if (choice == 6)
            {
                Console.WriteLine("Length of line: " + line.GetLength().ToString("F2"));
            }
            else if (choice == 7)
            {
                Console.WriteLine("Gradient of line: " + line.GetGradient().ToString("F2"));
            }
            else if (choice == 8)
            {
                Console.WriteLine("Distance of begin from origin: " + line.begin.DistanceFromZero().ToString("F2"));
            }
            else if (choice == 9)
            {
                Console.WriteLine("Distance of end from origin: " + line.end.DistanceFromZero().ToString("F2"));
            }
            else if (choice == 10)
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }

        } while (choice != 10);
    }
}
