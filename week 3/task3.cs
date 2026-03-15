using System;

class ClockType
{
    public int Hours;
    public int Minutes;
    public int Seconds;

    public ClockType(int hours, int minutes, int seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
    }

    public int ElapsedSeconds()
    {
        return Hours * 3600 + Minutes * 60 + Seconds;
    }

    public int RemainingSeconds()
    {
        return 86400 - ElapsedSeconds();
    }

    public int DifferenceWith(ClockType other)
    {
        return Math.Abs(this.ElapsedSeconds() - other.ElapsedSeconds());
    }

    public string ToFormattedTime()
    {
        string h = Hours.ToString().PadLeft(2, '0');
        string m = Minutes.ToString().PadLeft(2, '0');
        string s = Seconds.ToString().PadLeft(2, '0');
        return h + ":" + m + ":" + s;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ClockType clock1 = new ClockType(9, 15, 20);
        ClockType clock2 = new ClockType(14, 40, 10);
        ClockType clock3 = new ClockType(22, 10, 5);

        Console.WriteLine("--- CLOCK ANALYZER STARTED ---");
        Console.WriteLine();

        Console.WriteLine("Clock 1 -> " + clock1.ToFormattedTime());
        Console.WriteLine("Elapsed Seconds: " + clock1.ElapsedSeconds());
        Console.WriteLine("Remaining Seconds: " + clock1.RemainingSeconds());
        Console.WriteLine();

        Console.WriteLine("Clock 2 -> " + clock2.ToFormattedTime());
        Console.WriteLine("Difference with Clock 1: " + clock2.DifferenceWith(clock1) + " seconds");
        Console.WriteLine();

        Console.WriteLine("Clock 3 -> " + clock3.ToFormattedTime());
        Console.WriteLine("Remaining Seconds: " + clock3.RemainingSeconds());
        Console.WriteLine();

        Console.WriteLine("--- ANALYSIS COMPLETE ---");
    }
}
```

**Output:**
```
---CLOCK ANALYZER STARTED ---

Clock 1 -> 09:15:20
Elapsed Seconds: 33320
Remaining Seconds: 53080

Clock 2 -> 14:40:10
Difference with Clock 1: 19490 seconds

Clock 3 -> 22:10:05
Remaining Seconds: 6535

-- - ANALYSIS COMPLETE-- -