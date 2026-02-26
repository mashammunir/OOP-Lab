using System;
using System.IO;

namespace lab4task5
{
    internal class Program
    {
        static void pizzaPoints(int minOrders, int minPrice)
        {
            string path = "Customers.txt";

            if (!File.Exists(path))
            {
                Console.WriteLine("File not found.");
                return;
            }

            StreamReader file = new StreamReader(path);
            string line;
            bool anyEligible = false;

            while ((line = file.ReadLine()) != null)
            {
                if (line.Trim() == "") continue;

                int firstSpace = line.IndexOf(' ');
                string name = line.Substring(0, firstSpace);

                int openBracket = line.IndexOf('(');
                int closeBracket = line.IndexOf(')');
                string pricesStr = line.Substring(openBracket + 1,
                                   closeBracket - openBracket - 1).Trim();
                string[] priceTokens = pricesStr.Split(' ');

                int qualifyingOrders = 0;
                for (int i = 0; i < priceTokens.Length; i++)
                {
                    if (priceTokens[i].Trim() == "") continue;

                    int price = int.Parse(priceTokens[i].Trim());
                    if (price >= minPrice)
                    {
                        qualifyingOrders++;
                    }
                }

                if (qualifyingOrders >= minOrders)
                {
                    Console.WriteLine(name);
                    anyEligible = true;
                }
            }

            file.Close();

            if (!anyEligible)
            {
                Console.WriteLine("\"\"");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("pizza_points(5, 20):");
            pizzaPoints(5, 20);

            Console.WriteLine("\npizza_points(3, 10):");
            pizzaPoints(3, 10);

            Console.WriteLine("\npizza_points(5, 100):");
            pizzaPoints(5, 100);

            Console.Read();
        }
    }
}