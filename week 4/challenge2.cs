using System;
using System.Collections.Generic;

class Member
{
    string name;
    int memberID;
    List<string> booksBought = new List<string>();
    int numberOfBooksBought;
    float moneyInBank;
    float amountSpent;

    public Member() { }

    public Member(string n, int id, float money)
    {
        name = n;
        memberID = id;
        moneyInBank = money;
        numberOfBooksBought = 0;
        amountSpent = 0;
    }

    public void SetName(string n) { name = n; }
    public string GetName() { return name; }

    public void SetMemberID(int id) { memberID = id; }
    public int GetMemberID() { return memberID; }

    public void SetMoneyInBank(float money) { moneyInBank = money; }
    public float GetMoneyInBank() { return moneyInBank; }

    public void BuyBook(string bookTitle, float bookPrice)
    {
        if (moneyInBank >= bookPrice)
        {
            booksBought.Add(bookTitle);
            numberOfBooksBought++;
            moneyInBank -= bookPrice;
            amountSpent += bookPrice;
            Console.WriteLine(name + " successfully bought: " + bookTitle);
        }
        else
        {
            Console.WriteLine("Insufficient balance to buy: " + bookTitle);
        }
    }

    public void ShowBooksBought()
    {
        if (numberOfBooksBought == 0)
        {
            Console.WriteLine("No books bought yet.");
            return;
        }
        for (int i = 0; i < booksBought.Count; i++)
            Console.WriteLine("  " + (i + 1) + ". " + booksBought[i]);
    }

    public void Display()
    {
        Console.WriteLine("Name:           " + name);
        Console.WriteLine("Member ID:      " + memberID);
        Console.WriteLine("Money in Bank:  " + moneyInBank);
        Console.WriteLine("Amount Spent:   " + amountSpent);
        Console.WriteLine("Books Bought:   " + numberOfBooksBought);
        ShowBooksBought();
    }
}

class Program
{
    static Member[] members = new Member[100];
    static int count = 0;

    static Member FindMember(int id)
    {
        for (int i = 0; i < count; i++)
            if (members[i].GetMemberID() == id) return members[i];
        return null;
    }

    static void Main()
    {
        members[count++] = new Member("Ali", 1001, 5000);
        members[count++] = new Member("Sara", 1002, 8000);

        int choice;
        do
        {
            Console.WriteLine("\n1.Add Member  2.Buy Book  3.Show Member  4.Update Name  5.Show All  6.Exit");
            Console.Write("Choice: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Name: "); string n = Console.ReadLine();
                Console.Write("Member ID: "); int id = int.Parse(Console.ReadLine());
                Console.Write("Money in Bank: "); float money = float.Parse(Console.ReadLine());
                members[count++] = new Member(n, id, money);
                Console.WriteLine("Member added!");
            }
            else if (choice == 2)
            {
                Console.Write("Enter Member ID: "); int id = int.Parse(Console.ReadLine());
                Member m = FindMember(id);
                if (m == null) { Console.WriteLine("Member not found."); continue; }
                Console.Write("Book Title: "); string title = Console.ReadLine();
                Console.Write("Book Price: "); float price = float.Parse(Console.ReadLine());
                m.BuyBook(title, price);
            }
            else if (choice == 3)
            {
                Console.Write("Enter Member ID: "); int id = int.Parse(Console.ReadLine());
                Member m = FindMember(id);
                if (m == null) Console.WriteLine("Member not found.");
                else m.Display();
            }
            else if (choice == 4)
            {
                Console.Write("Enter Member ID: "); int id = int.Parse(Console.ReadLine());
                Member m = FindMember(id);
                if (m == null) { Console.WriteLine("Member not found."); continue; }
                Console.Write("New Name: "); m.SetName(Console.ReadLine());
                Console.WriteLine("Name updated!");
            }
            else if (choice == 5)
            {
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine("------");
                    members[i].Display();
                }
            }

        } while (choice != 6);

        Console.WriteLine("Goodbye!");
    }
}