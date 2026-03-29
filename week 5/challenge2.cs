using System;
using System.Collections.Generic;
using System.IO;

class Product
{
    public string name;
    public string category;
    public float price;
    public int stock;
    public int threshold;

    public Product(string n, string c, float p, int s, int t)
    {
        name = n; category = c; price = p; stock = s; threshold = t;
    }

    public float GetSalesTax()
    {
        if (category.ToLower() == "grocery") return price * 0.10f;
        if (category.ToLower() == "fruit") return price * 0.05f;
        return price * 0.15f;
    }

    public float GetPriceWithTax()
    {
        return price + GetSalesTax();
    }

    public bool NeedsOrder()
    {
        return stock < threshold;
    }

    public void Display()
    {
        Console.WriteLine("Name: " + name + " | Category: " + category +
            " | Price: $" + price.ToString("F2") + " | Stock: " + stock +
            " | Threshold: " + threshold);
    }
}

class Customer
{
    public string name;
    public List<Product> cart = new List<Product>();
    public List<int> quantities = new List<int>();

    public Customer(string n) { name = n; }

    public void BuyProduct(Product p, int qty)
    {
        if (qty > p.stock)
        {
            Console.WriteLine("Not enough stock. Available: " + p.stock);
            return;
        }
        p.stock -= qty;
        cart.Add(p);
        quantities.Add(qty);
        Console.WriteLine(qty + "x " + p.name + " added to cart.");
    }

    public void GenerateInvoice()
    {
        if (cart.Count == 0) { Console.WriteLine("Cart is empty."); return; }

        Console.WriteLine("\n====== INVOICE ======");
        Console.WriteLine("Customer: " + name);
        Console.WriteLine("---------------------");

        float total = 0;
        for (int i = 0; i < cart.Count; i++)
        {
            float lineTotal = cart[i].GetPriceWithTax() * quantities[i];
            Console.WriteLine(cart[i].name + " x" + quantities[i] +
                " | Unit Price: $" + cart[i].price.ToString("F2") +
                " | Tax: $" + cart[i].GetSalesTax().ToString("F2") +
                " | Total: $" + lineTotal.ToString("F2"));
            total += lineTotal;
        }

        Console.WriteLine("---------------------");
        Console.WriteLine("Grand Total: $" + total.ToString("F2"));
        Console.WriteLine("=====================");

        cart.Clear();
        quantities.Clear();
    }
}

class MUser
{
    public string username;
    public string password;
    public string role;

    public MUser(string u, string p, string r)
    {
        username = u; password = p; role = r;
    }
}

class Program
{
    static List<MUser> users = new List<MUser>();
    static List<Product> products = new List<Product>();
    static string usersFile = "users.txt";

    static void LoadUsers()
    {
        if (!File.Exists(usersFile)) return;
        string[] lines = File.ReadAllLines(usersFile);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 3)
                users.Add(new MUser(parts[0], parts[1], parts[2]));
        }
    }

    static void SaveUsers()
    {
        List<string> lines = new List<string>();
        foreach (MUser u in users)
            lines.Add(u.username + "," + u.password + "," + u.role);
        File.WriteAllLines(usersFile, lines);
    }

    static MUser Login(string username, string password)
    {
        foreach (MUser u in users)
            if (u.username == username && u.password == password) return u;
        return null;
    }

    static void SignUp()
    {
        Console.Write("Enter Username: "); string u = Console.ReadLine();
        Console.Write("Enter Password: "); string p = Console.ReadLine();
        Console.Write("Enter Role (admin/customer): "); string r = Console.ReadLine().ToLower();

        foreach (MUser existing in users)
            if (existing.username == u) { Console.WriteLine("Username already exists."); return; }

        users.Add(new MUser(u, p, r));
        SaveUsers();
        Console.WriteLine("Account created successfully!");
    }

    static void AdminMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("\n===== ADMIN MENU =====");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View All Products");
            Console.WriteLine("3. Find Product with Highest Unit Price");
            Console.WriteLine("4. View Sales Tax of All Products");
            Console.WriteLine("5. Products to be Ordered");
            Console.WriteLine("6. Exit");
            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Product Name: "); string n = Console.ReadLine();
                Console.Write("Category (grocery/fruit/other): "); string c = Console.ReadLine();
                Console.Write("Price: $"); float p = float.Parse(Console.ReadLine());
                Console.Write("Stock Quantity: "); int s = int.Parse(Console.ReadLine());
                Console.Write("Min Threshold: "); int t = int.Parse(Console.ReadLine());
                products.Add(new Product(n, c, p, s, t));
                Console.WriteLine("Product added!");
            }
            else if (choice == 2)
            {
                if (products.Count == 0) { Console.WriteLine("No products."); continue; }
                foreach (Product p in products) p.Display();
            }
            else if (choice == 3)
            {
                if (products.Count == 0) { Console.WriteLine("No products."); continue; }
                Product highest = products[0];
                foreach (Product p in products)
                    if (p.price > highest.price) highest = p;
                Console.WriteLine("Highest priced product:");
                highest.Display();
            }
            else if (choice == 4)
            {
                if (products.Count == 0) { Console.WriteLine("No products."); continue; }
                foreach (Product p in products)
                    Console.WriteLine(p.name + " | Tax Rate: " +
                        (p.category.ToLower() == "grocery" ? "10%" :
                         p.category.ToLower() == "fruit" ? "5%" : "15%") +
                        " | Tax Amount: $" + p.GetSalesTax().ToString("F2"));
            }
            else if (choice == 5)
            {
                bool any = false;
                foreach (Product p in products)
                    if (p.NeedsOrder()) { p.Display(); any = true; }
                if (!any) Console.WriteLine("All products are sufficiently stocked.");
            }
            else if (choice == 6)
            {
                Console.WriteLine("Logged out.");
            }

        } while (choice != 6);
    }

    static void CustomerMenu(string username)
    {
        Customer customer = new Customer(username);
        int choice;
        do
        {
            Console.WriteLine("\n===== CUSTOMER MENU =====");
            Console.WriteLine("1. View All Products");
            Console.WriteLine("2. Buy Products");
            Console.WriteLine("3. Generate Invoice");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                if (products.Count == 0) { Console.WriteLine("No products available."); continue; }
                foreach (Product p in products) p.Display();
            }
            else if (choice == 2)
            {
                if (products.Count == 0) { Console.WriteLine("No products available."); continue; }

                Console.Write("Enter product name: "); string name = Console.ReadLine();
                Product found = null;
                foreach (Product p in products)
                    if (p.name.ToLower() == name.ToLower()) { found = p; break; }

                if (found == null) { Console.WriteLine("Product not found."); continue; }

                Console.Write("Enter quantity: "); int qty = int.Parse(Console.ReadLine());
                customer.BuyProduct(found, qty);
            }
            else if (choice == 3)
            {
                customer.GenerateInvoice();
            }
            else if (choice == 4)
            {
                Console.WriteLine("Logged out.");
            }

        } while (choice != 4);
    }

    static void Main()
    {
        LoadUsers();

        if (users.Count == 0)
        {
            users.Add(new MUser("admin", "admin123", "admin"));
            users.Add(new MUser("customer1", "pass1", "customer"));
            SaveUsers();
        }

        products.Add(new Product("Rice", "grocery", 5.00f, 50, 10));
        products.Add(new Product("Apple", "fruit", 3.00f, 3, 10));
        products.Add(new Product("Shampoo", "other", 8.00f, 20, 5));

        int choice;
        do
        {
            Console.WriteLine("\n************************************");
            Console.WriteLine("         DEPARTMENTAL STORE         ");
            Console.WriteLine("************************************");
            Console.WriteLine("1. Sign In");
            Console.WriteLine("2. Sign Up");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Enter Username: "); string u = Console.ReadLine();
                Console.Write("Enter Password: "); string p = Console.ReadLine();

                MUser user = Login(u, p);
                if (user == null)
                {
                    Console.WriteLine("Invalid credentials.");
                }
                else if (user.role == "admin")
                {
                    Console.WriteLine("Welcome Admin " + user.username + "!");
                    AdminMenu();
                }
                else
                {
                    Console.WriteLine("Welcome " + user.username + "!");
                    CustomerMenu(user.username);
                }
            }
            else if (choice == 2)
            {
                SignUp();
            }
            else if (choice == 3)
            {
                Console.WriteLine("Goodbye!");
            }

        } while (choice != 3);
    }
}
