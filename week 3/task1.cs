using System;

class Character
{
    public string Name;
    public int Health;
    public int Attack;

    public Character(string name, int health, int attack)
    {
        Name = name;
        Health = health;
        Attack = attack;
    }

    public Character(Character other)
    {
        Name = "Clone " + other.Name;
        Health = other.Health;
        Attack = other.Attack;
    }

    public bool IsAlive()
    {
        return Health > 0;
    }

    public void AttackTarget(Character target)
    {
        target.Health -= this.Attack;
        Console.WriteLine(this.Name + " attacks " + target.Name + " -> " + target.Name + " Health: " + target.Health);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Character warrior = new Character("Warrior", 100, 30);
        Character ninja = new Character("Ninja", 100, 20);

        Console.WriteLine("--- BATTLE STARTED ---");

        warrior.AttackTarget(ninja);
        ninja.AttackTarget(warrior);

        Character cloneWarrior = new Character(warrior);
        Console.WriteLine("Clone " + warrior.Name + " joins battle");

        int round = 2;

        while (ninja.IsAlive() && (warrior.IsAlive() || cloneWarrior.IsAlive()))
        {
            round++;
            Console.WriteLine("Round " + round);

            if (cloneWarrior.IsAlive() && ninja.IsAlive())
                cloneWarrior.AttackTarget(ninja);

            if (warrior.IsAlive() && ninja.IsAlive())
                warrior.AttackTarget(ninja);

            if (ninja.IsAlive())
            {
                if (cloneWarrior.IsAlive())
                    ninja.AttackTarget(cloneWarrior);
                else
                    ninja.AttackTarget(warrior);
            }

            if (!ninja.IsAlive())
                break;
        }

        Console.WriteLine();

        if (!ninja.IsAlive())
            Console.WriteLine(ninja.Name + " has been defeated!");
        else
            Console.WriteLine(warrior.Name + " has been defeated!");

        Console.WriteLine();

        if (!ninja.IsAlive())
            Console.WriteLine("Winner: " + warrior.Name);
        else
            Console.WriteLine("Winner: " + ninja.Name);
    }
}
