using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2task5
{
    class Product
    {
        public int ID;
        public string Name;
        public double Price;
        public string Category;
        public string Brand;
        public string Country;

        public Product(int id, string name, double price, string category, string brand, string country)
        {
            ID = id;
            Name = name;
            Price = price;
            Category = category;
            Brand = brand;
            Country = country;
        }
    }

    internal class Program
    {
        static List<Product> products = new List<Product>();

        static void AddProduct()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter Category: ");
            string category = Console.ReadLine();

            Console.Write("Enter Brand: ");
            string brand = Console.ReadLine();

            Console.Write("Enter Country: ");
            string country = Console.ReadLine();

            products.Add(new Product(id, name, price, category, brand, country));
        }

        static void ShowProducts()
        {
            foreach (Product p in products)
            {
                Console.WriteLine(p.ID + " | " + p.Name + " | " + p.Price + " | " + p.Category + " | " + p.Brand + " | " + p.Country);
            }
        }

        static void TotalStoreWorth()
        {
            double total = 0;
            foreach (Product p in products)
            {
                total += p.Price;
            }
            Console.WriteLine("Total Store Worth: " + total);
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Show Products");
                Console.WriteLine("3. Total Store Worth");
                Console.WriteLine("4. Exit");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1) AddProduct();
                else if (choice == 2) ShowProducts();
                else if (choice == 3) TotalStoreWorth();
                else if (choice == 4) break;
            }
        }
    }
}