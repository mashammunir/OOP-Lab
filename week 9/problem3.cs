using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w9p3
{
    public class Animal
    {
        protected string name;

        public Animal(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return "Animal[name=" + name + "]";
        }
    }

    public class Mammal : Animal
    {
        public Mammal(string name) : base(name) { }

        public override string ToString()
        {
            return "Mammal[Animal[name=" + name + "]]";
        }
    }

    public class Cat : Mammal
    {
        public Cat(string name) : base(name) { }

        public void Greets()
        {
            Console.WriteLine("Meow");
        }

        public override string ToString()
        {
            return "Cat[Mammal[Animal[name=" + name + "]]]";
        }
    }

    public class Dog : Mammal
    {
        public Dog(string name) : base(name) { }

        public void Greets()
        {
            Console.WriteLine("Woof");
        }

        public void Greets(Dog another)
        {
            Console.WriteLine("Woooof");
        }

        public override string ToString()
        {
            return "Dog[Mammal[Animal[name=" + name + "]]]";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Cat c1 = new Cat("Kitty");
            Cat c2 = new Cat("Whiskers");

            Dog d1 = new Dog("Buddy");
            Dog d2 = new Dog("Max");

            Console.WriteLine("====== CATS ======");
            Console.WriteLine();

            c1.Greets();
            Console.WriteLine(c1.ToString());
            Console.WriteLine();

            c2.Greets();
            Console.WriteLine(c2.ToString());
            Console.WriteLine();

            Console.WriteLine("====== DOGS ======");
            Console.WriteLine();

            d1.Greets();
            Console.WriteLine(d1.ToString());
            Console.WriteLine();

            d2.Greets();
            Console.WriteLine(d2.ToString());
            Console.WriteLine();

            Console.WriteLine("====== DOG GREETS DOG ======");
            Console.WriteLine();

            d1.Greets(d2);
            Console.WriteLine(d1.ToString() + " greets " + d2.ToString());
            Console.WriteLine();

            Console.WriteLine("====== POLYMORPHISM DEMO (No IF) ======");
            Console.WriteLine();

            Animal[] animals = { c1, c2, d1, d2 };

            foreach (Animal a in animals)
            {
                Console.WriteLine(a.ToString());
            }
        }
    }
}