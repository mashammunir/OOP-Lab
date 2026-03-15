using System;
using System.Collections.Generic;

class Product
{
    public string Name;
    public double Price;
    public int Stock;
    public double TaxRate;

    public Product(string name, double price, int stock, double taxRate)
    {
        Name = name;
        Price = price;
        Stock = stock;
        TaxRate = taxRate;
    }

    public double CalculateTax()
    {
        return Price * TaxRate;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Product> products = new List<Product>
        {
            new Product("Laptop",     120000, 15,  0.10),
            new Product("Milk",       150,     5,  0.05),
            new Product("Bread",      80,      8,  0.03),
            new Product("Headphones", 5000,   20,  0.08),
            new Product("Keyboard",   3500,    0,  0.07)
        };

        Console.WriteLine("--- STORE SYSTEM STARTED ---");
        Console.WriteLine();

        double totalTax = 0;
        foreach (Product p in products)
        {
            if (p.Stock > 0)
                totalTax += p.CalculateTax();
        }

        Console.WriteLine("Total Store Tax: " + totalTax);
        Console.WriteLine();

        Console.WriteLine("Low Stock Products:");
        foreach (Product p in products)
        {
            if (p.Stock > 0 && p.Stock < 10)
                Console.WriteLine(p.Name + " (Stock: " + p.Stock + ")");
        }

        Console.WriteLine();

        Product mostExpensive = null;
        foreach (Product p in products)
        {
            if (p.Stock > 0)
            {
                if (mostExpensive == null || p.Price > mostExpensive.Price)
                    mostExpensive = p;
            }
        }

        Console.WriteLine("Most Expensive Product:");
        if (mostExpensive != null)
            Console.WriteLine(mostExpensive.Name + " -> Price: " + mostExpensive.Price);

        Console.WriteLine();
        Console.WriteLine("--- STORE REPORT GENERATED ---");
    }
}
