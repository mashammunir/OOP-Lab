using System;
using System.Reflection;

class Astronaut
{
    public string Name;
    public int Oxygen;
    public int Stamina;
    public bool IsConscious;

    public Astronaut(string name)
    {
        Name = name;
        Oxygen = 100;
        Stamina = 60;
        IsConscious = true;
    }

    public void ApplyEvent(int eventCode)
    {
        if (eventCode == 1)
        {
            Oxygen += 15;
            if (Oxygen > 100)
                Oxygen = 100;
            Console.WriteLine(Name + " refilled oxygen. Oxygen +15");
        }
        else if (eventCode == 2)
        {
            Oxygen -= 25;
            Console.WriteLine(Name + " hit by meteor. Oxygen -25");
        }
        else if (eventCode == 3)
        {
            Stamina += 10;
            Console.WriteLine(Name + " took break. Stamina +10");
        }
        else if (eventCode == 4)
        {
            Stamina -= 15;
            Console.WriteLine(Name + " equipment failure. Stamina -15");
        }
        else if (eventCode == 5)
        {
            Console.WriteLine(Name + " smooth cycle. No change");
        }

        if (Oxygen <= 0)
        {
            Oxygen = 0;
            IsConscious = false;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Astronaut[] crew = new Astronaut[4];
        crew[0] = new Astronaut("Ali");
        crew[1] = new Astronaut("Sara");
        crew[2] = new Astronaut("Ahmed");
        crew[3] = new Astronaut("Zara");

        Random rand = new Random();

        Console.WriteLine("--- SPACE MISSION STARTED ---");

        for (int cycle = 1; cycle <= 10; cycle++)
        {
            int consciousCount = 0;
            foreach (Astronaut a in crew)
                if (a.IsConscious)
                    consciousCount++;

            if (consciousCount <= 1)
            {
                Console.WriteLine();
                Console.WriteLine("Mission ended early. Only one astronaut remains conscious.");
                break;
            }

            Console.WriteLine();
            Console.WriteLine("Cycle " + cycle);

            foreach (Astronaut a in crew)
            {
                if (!a.IsConscious)
                    continue;

                int eventCode = rand.Next(1, 6);
                a.ApplyEvent(eventCode);
            }
        }

        Console.WriteLine();
        Console.WriteLine("--- FINAL RESULTS ---");

        Astronaut winner = null;
        int totalConscious = 0;

        foreach (Astronaut a in crew)
        {
            string status = a.IsConscious ? "Conscious" : "Unconscious";
            Console.WriteLine(a.Name + " -> Oxygen: " + a.Oxygen + " Stamina: " + a.Stamina + " " + status);

            if (a.IsConscious)
            {
                totalConscious++;
                if (winner == null || a.Oxygen > winner.Oxygen)
                    winner = a;
            }
        }

        Console.WriteLine("Total Conscious Astronauts: " + totalConscious);

        if (winner != null)
            Console.WriteLine("Winner: " + winner.Name + " (Highest Oxygen)");
        else
            Console.WriteLine("No conscious astronauts remaining.");
    }
}
