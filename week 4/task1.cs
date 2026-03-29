using System;
using System.Collections.Generic;

class Product
{
    public string name;
    public double price;

    public Product(string n, double p)
    {
        name = n;
        price = p;
    }

    public double calculateTax()
    {
        return price * 0.1; // 10% tax
    }

    public double getFinalPrice()
    {
        return price + calculateTax();
    }
}

class Customer
{
    public string name;
    List<Product> products = new List<Product>();

    public Customer(string n)
    {
        name = n;
    }

    public void addProduct(Product p)
    {
        products.Add(p);
    }

    public double calculateBill()
    {
        double total = 0;

        foreach (Product p in products)
        {
            total += p.getFinalPrice();
        }

        return total;
    }

    public void showBill()
    {
        Console.WriteLine("Customer: " + name);
        Console.WriteLine("Products:");

        foreach (Product p in products)
        {
            Console.WriteLine(p.name + " - " + p.price);
        }

        Console.WriteLine("Total Bill (with tax): " + calculateBill());
    }
}

class Program
{
    static void Main()
    {
        Customer c1 = new Customer("Ali");

        Product p1 = new Product("Laptop", 100000);
        Product p2 = new Product("Mouse", 2000);

        c1.addProduct(p1);
        c1.addProduct(p2);

        c1.showBill();
    }
}