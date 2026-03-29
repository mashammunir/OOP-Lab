using System;
using System.Collections.Generic;

class Book
{
    public string title, publisher, isbn;
    public string[] authors = new string[4];
    public int authorCount, stock, year;
    public float price;

    public Book() { }

    public Book(string t, string a, string pub, string ib, float pr, int st, int y)
    {
        title = t; authors[0] = a; authorCount = 1;
        publisher = pub; isbn = ib; price = pr; stock = st; year = y;
    }

    public bool CheckTitle(string t) { return title.ToLower() == t.ToLower(); }
    public bool CheckISBN(string ib) { return isbn == ib; }
    public void UpdateStock(int amount) { stock += amount; }

    public void Display()
    {
        Console.WriteLine("Title: " + title + " | Author: " + authors[0] +
            " | ISBN: " + isbn + " | Price: $" + price +
            " | Stock: " + stock + " | Year: " + year);
    }
}

class Member
{
    public string name;
    public int memberID;
    public List<string> booksBought = new List<string>();
    public int numberOfBooksBought;
    public float moneyInBank, amountSpent;
    public bool isMember;
    public float last10BooksTotal;

    public Member() { }

    public Member(string n, int id, float money)
    {
        name = n;
        memberID = id;
        moneyInBank = money;
        isMember = (id != 0);
        numberOfBooksBought = 0;
        amountSpent = 0;
        last10BooksTotal = 0;
    }

    public float BuyBook(string bookTitle, float bookPrice, int quantity)
    {
        float discount = 0;
        float totalCost = bookPrice * quantity;

        if (isMember)
        {
            discount = totalCost * 0.05f;
            totalCost -= discount;

            for (int q = 0; q < quantity; q++)
            {
                numberOfBooksBought++;
                last10BooksTotal += bookPrice;

                if (numberOfBooksBought % 11 == 0)
                {
                    float avgDiscount = last10BooksTotal / 10;
                    Console.WriteLine("  ** Every 11th book bonus! Discount applied: $" + avgDiscount.ToString("F2"));
                    totalCost -= avgDiscount;
                    last10BooksTotal = 0;
                    amountSpent = 0;
                }

                booksBought.Add(bookTitle);
            }
        }
        else
        {
            numberOfBooksBought += quantity;
            for (int q = 0; q < quantity; q++)
                booksBought.Add(bookTitle);
        }

        amountSpent += totalCost;
        moneyInBank -= totalCost;

        Console.WriteLine("  Discount: $" + discount.ToString("F2"));
        Console.WriteLine("  Total Paid: $" + totalCost.ToString("F2"));
        Console.WriteLine("  Remaining Balance: $" + moneyInBank.ToString("F2"));

        return totalCost;
    }

    public void Display()
    {
        Console.WriteLine("Name:          " + name);
        Console.WriteLine("Member ID:     " + (isMember ? memberID.ToString() : "Non-Member"));
        Console.WriteLine("Money in Bank: $" + moneyInBank.ToString("F2"));
        Console.WriteLine("Amount Spent:  $" + amountSpent.ToString("F2"));
        Console.WriteLine("Books Bought:  " + numberOfBooksBought);
        for (int i = 0; i < booksBought.Count; i++)
            Console.WriteLine("  " + (i + 1) + ". " + booksBought[i]);
    }
}

class Program
{
    static Book[] books = new Book[100];
    static int bookCount = 0;

    static Member[] members = new Member[100];
    static int memberCount = 0;

    static float totalSales = 0;
    static float totalMembershipFees = 0;
    static int totalMembersAdded = 0;

    static Book FindBookByTitle(string t)
    {
        for (int i = 0; i < bookCount; i++)
            if (books[i].CheckTitle(t)) return books[i];
        return null;
    }

    static Book FindBookByISBN(string ib)
    {
        for (int i = 0; i < bookCount; i++)
            if (books[i].CheckISBN(ib)) return books[i];
        return null;
    }

    static Member FindMemberByID(int id)
    {
        for (int i = 0; i < memberCount; i++)
            if (members[i].memberID == id) return members[i];
        return null;
    }

    static Member FindMemberByName(string n)
    {
        for (int i = 0; i < memberCount; i++)
            if (members[i].name.ToLower() == n.ToLower()) return members[i];
        return null;
    }

    static void AddBook()
    {
        Console.Write("Title: "); string t = Console.ReadLine();
        Console.Write("Author: "); string a = Console.ReadLine();
        Console.Write("Publisher: "); string pub = Console.ReadLine();
        Console.Write("ISBN: "); string ib = Console.ReadLine();
        Console.Write("Price: $"); float pr = float.Parse(Console.ReadLine());
        Console.Write("Stock: "); int st = int.Parse(Console.ReadLine());
        Console.Write("Year: "); int y = int.Parse(Console.ReadLine());
        books[bookCount++] = new Book(t, a, pub, ib, pr, st, y);
        Console.WriteLine("Book added!");
    }

    static void UpdateStock()
    {
        Console.Write("Enter title or ISBN: "); string input = Console.ReadLine();
        Book b = FindBookByTitle(input) ?? FindBookByISBN(input);
        if (b == null) { Console.WriteLine("Book not found."); return; }
        Console.Write("Amount to add (negative to reduce): ");
        b.UpdateStock(int.Parse(Console.ReadLine()));
        Console.WriteLine("Stock updated! New stock: " + b.stock);
    }

    static void AddMember()
    {
        Console.Write("Name: "); string n = Console.ReadLine();
        Console.Write("Member ID (0 = non-member): "); int id = int.Parse(Console.ReadLine());
        Console.Write("Money in Bank: $"); float money = float.Parse(Console.ReadLine());

        Member m = new Member(n, id, money);

        if (m.isMember)
        {
            m.moneyInBank -= 10;
            totalMembershipFees += 10;
            totalMembersAdded++;
            Console.WriteLine("$10 membership fee deducted. Remaining balance: $" + m.moneyInBank.ToString("F2"));
        }

        members[memberCount++] = m;
        Console.WriteLine("Member added!");
    }

    static void SearchMember()
    {
        Console.Write("Search by (1) Name  (2) ID: "); string choice = Console.ReadLine();
        Member m = null;

        if (choice == "1")
        {
            Console.Write("Enter name: ");
            m = FindMemberByName(Console.ReadLine());
        }
        else
        {
            Console.Write("Enter ID: ");
            m = FindMemberByID(int.Parse(Console.ReadLine()));
        }

        if (m == null) Console.WriteLine("Member not found.");
        else m.Display();
    }

    static void UpdateMember()
    {
        Console.Write("Search by (1) Name  (2) ID: "); string choice = Console.ReadLine();
        Member m = null;

        if (choice == "1")
        {
            Console.Write("Enter name: ");
            m = FindMemberByName(Console.ReadLine());
        }
        else
        {
            Console.Write("Enter ID: ");
            m = FindMemberByID(int.Parse(Console.ReadLine()));
        }

        if (m == null) { Console.WriteLine("Member not found."); return; }

        Console.WriteLine("Update: (1) Name  (2) ID  (3) Both");
        string opt = Console.ReadLine();

        if (opt == "1" || opt == "3")
        {
            Console.Write("New name: ");
            m.name = Console.ReadLine();
        }
        if (opt == "2" || opt == "3")
        {
            Console.Write("New ID: ");
            m.memberID = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Member updated!");
    }

    static void PurchaseBook()
    {
        Console.Write("Enter your name: "); string name = Console.ReadLine();
        Console.Write("Member ID (0 if non-member): "); int id = int.Parse(Console.ReadLine());

        Member m = (id == 0) ? FindMemberByName(name) : FindMemberByID(id);

        if (m == null)
        {
            Console.WriteLine("Member not found. Creating a guest entry.");
            m = new Member(name, 0, 99999);
            members[memberCount++] = m;
        }

        Console.Write("Enter book title or ISBN: "); string input = Console.ReadLine();
        Book b = FindBookByTitle(input) ?? FindBookByISBN(input);

        if (b == null) { Console.WriteLine("Book not found."); return; }
        if (b.stock <= 0) { Console.WriteLine("Book out of stock."); return; }

        Console.Write("Quantity: "); int qty = int.Parse(Console.ReadLine());

        if (qty > b.stock) { Console.WriteLine("Not enough stock. Available: " + b.stock); return; }

        float paid = m.BuyBook(b.title, b.price, qty);
        b.UpdateStock(-qty);
        totalSales += paid;
    }

    static void ShowStats()
    {
        Console.WriteLine("Total Sales:         $" + totalSales.ToString("F2"));
        Console.WriteLine("Total Members:       " + totalMembersAdded);
        Console.WriteLine("Membership Fees:     $" + totalMembershipFees.ToString("F2"));
    }

    static void Main()
    {
        books[bookCount++] = new Book("Clean Code", "Robert Martin", "Prentice Hall", "ISBN-001", 30, 20, 2008);
        books[bookCount++] = new Book("OOP in C++", "Robert Lafore", "Pearson", "ISBN-002", 25, 15, 2002);

        members[memberCount++] = new Member("Ali", 1001, 5000);
        totalMembershipFees += 10; totalMembersAdded++;
        members[0].moneyInBank -= 10;

        members[memberCount++] = new Member("Sara", 0, 3000);

        int choice;
        do
        {
            Console.WriteLine("\n========== Bookstore Menu ==========");
            Console.WriteLine("1. Add a Book");
            Console.WriteLine("2. Search Book by Title");
            Console.WriteLine("3. Search Book by ISBN");
            Console.WriteLine("4. Update Stock");
            Console.WriteLine("5. Add a Member");
            Console.WriteLine("6. Search a Member");
            Console.WriteLine("7. Update Member Info");
            Console.WriteLine("8. Purchase a Book");
            Console.WriteLine("9. Show Sales & Membership Stats");
            Console.WriteLine("10. Exit");
            Console.Write("Choice: ");
            choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (choice == 1) AddBook();
            else if (choice == 2) { Console.Write("Title: "); Book b = FindBookByTitle(Console.ReadLine()); if (b == null) Console.WriteLine("Not found."); else b.Display(); }
            else if (choice == 3) { Console.Write("ISBN: "); Book b = FindBookByISBN(Console.ReadLine()); if (b == null) Console.WriteLine("Not found."); else b.Display(); }
            else if (choice == 4) UpdateStock();
            else if (choice == 5) AddMember();
            else if (choice == 6) SearchMember();
            else if (choice == 7) UpdateMember();
            else if (choice == 8) PurchaseBook();
            else if (choice == 9) ShowStats();
            else if (choice == 10) Console.WriteLine("Goodbye!");
            else Console.WriteLine("Invalid choice.");

        } while (choice != 10);
    }
}
using System;
using System.Collections.Generic;

class Subject
{
    public int code;
    public string type;
    public int creditHours;
    public float fees;

    public Subject(int c, string t, int ch, float f)
    {
        code = c; type = t; creditHours = ch; fees = f;
    }

    public void Display()
    {
        Console.WriteLine("  Code: " + code + " | Type: " + type +
            " | Credit Hours: " + creditHours + " | Fees: " + fees);
    }
}

class DegreeProgram
{
    public string name;
    public int duration;
    public int seats;
    public int seatsLeft;
    public List<Subject> subjects = new List<Subject>();

    public DegreeProgram(string n, int d, int s)
    {
        name = n; duration = d; seats = s; seatsLeft = s;
    }

    public void AddSubject(Subject s) { subjects.Add(s); }

    public float GetTotalFees()
    {
        float total = 0;
        foreach (Subject s in subjects) total += s.fees;
        return total;
    }

    public void Display()
    {
        Console.WriteLine("Degree: " + name + " | Duration: " + duration +
            " years | Seats Left: " + seatsLeft);
        foreach (Subject s in subjects) s.Display();
    }
}

class Student
{
    public string name;
    public int age;
    public int fscMarks;
    public int ecatMarks;
    public List<string> preferences = new List<string>();
    public string admittedProgram = "";
    public List<Subject> registeredSubjects = new List<Subject>();

    public Student(string n, int a, int fsc, int ecat)
    {
        name = n; age = a; fscMarks = fsc; ecatMarks = ecat;
    }

    public float CalculateMerit()
    {
        return (fscMarks * 0.60f) + (ecatMarks * 0.40f);
    }

    public void AddPreference(string p) { preferences.Add(p); }

    public void RegisterSubject(Subject s)
    {
        foreach (Subject rs in registeredSubjects)
            if (rs.code == s.code) { Console.WriteLine("Subject already registered."); return; }
        registeredSubjects.Add(s);
        Console.WriteLine("Subject " + s.code + " registered for " + name);
    }

    public float CalculateFees()
    {
        float total = 0;
        foreach (Subject s in registeredSubjects) total += s.fees;
        return total;
    }

    public void Display()
    {
        Console.WriteLine(name.PadRight(10) + fscMarks.ToString().PadRight(10) +
            ecatMarks.ToString().PadRight(10) + age);
    }
}

class Program
{
    static List<DegreeProgram> programs = new List<DegreeProgram>();
    static List<Student> students = new List<Student>();
    static List<Student> registeredStudents = new List<Student>();

    static DegreeProgram FindProgram(string name)
    {
        foreach (DegreeProgram dp in programs)
            if (dp.name.ToLower() == name.ToLower()) return dp;
        return null;
    }

    static Student FindStudent(string name)
    {
        foreach (Student s in students)
            if (s.name.ToLower() == name.ToLower()) return s;
        return null;
    }

    static void AddDegreeProgram()
    {
        Console.Write("Enter Degree Name: "); string n = Console.ReadLine();
        Console.Write("Enter Degree Duration: "); int d = int.Parse(Console.ReadLine());
        Console.Write("Enter Seats for Degree: "); int seats = int.Parse(Console.ReadLine());

        DegreeProgram dp = new DegreeProgram(n, d, seats);

        Console.Write("Enter How many Subjects to Enter: ");
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Console.Write("Enter Subject Code: "); int code = int.Parse(Console.ReadLine());
            Console.Write("Enter Subject Type: "); string t = Console.ReadLine();
            Console.Write("Enter Subject Credit Hours: "); int ch = int.Parse(Console.ReadLine());
            Console.Write("Enter Subject Fees: "); float f = float.Parse(Console.ReadLine());
            dp.AddSubject(new Subject(code, t, ch, f));
        }

        programs.Add(dp);
        Console.WriteLine("Press any key to Continue..");
        Console.ReadKey();
    }

    static void AddStudent()
    {
        Console.Write("Enter Student Name: "); string n = Console.ReadLine();
        Console.Write("Enter Student Age: "); int age = int.Parse(Console.ReadLine());
        Console.Write("Enter Student FSc Marks: "); int fsc = int.Parse(Console.ReadLine());
        Console.Write("Enter Student Ecat Marks: "); int ecat = int.Parse(Console.ReadLine());

        Student s = new Student(n, age, fsc, ecat);

        Console.WriteLine("Available Degree Programs");
        foreach (DegreeProgram dp in programs) Console.WriteLine(dp.name);

        Console.Write("Enter how many preferences to Enter: ");
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string pref = Console.ReadLine();
            s.AddPreference(pref);
        }

        students.Add(s);
        Console.WriteLine("Press any key to Continue..");
        Console.ReadKey();
    }

    static void GenerateMerit()
    {
        List<Student> sorted = new List<Student>(students);
        sorted.Sort((a, b) => b.CalculateMerit().CompareTo(a.CalculateMerit()));

        foreach (Student s in sorted)
        {
            bool admitted = false;
            foreach (string pref in s.preferences)
            {
                DegreeProgram dp = FindProgram(pref);
                if (dp != null && dp.seatsLeft > 0)
                {
                    dp.seatsLeft--;
                    s.admittedProgram = dp.name;
                    registeredStudents.Add(s);
                    Console.WriteLine(s.name + " got Admission in " + dp.name);
                    admitted = true;
                    break;
                }
            }
            if (!admitted) Console.WriteLine(s.name + " did not get Admission");
        }

        Console.WriteLine("Press any key to Continue..");
        Console.ReadKey();
    }

    static void ViewRegisteredStudents()
    {
        Console.WriteLine("Name".PadRight(10) + "FSC".PadRight(10) + "Ecat".PadRight(10) + "Age");
        foreach (Student s in registeredStudents) s.Display();
        Console.WriteLine("Press any key to Continue..");
        Console.ReadKey();
    }

    static void ViewStudentsOfProgram()
    {
        Console.Write("Enter Degree Name: "); string name = Console.ReadLine();
        Console.WriteLine("Name".PadRight(10) + "FSC".PadRight(10) + "Ecat".PadRight(10) + "Age");
        foreach (Student s in registeredStudents)
            if (s.admittedProgram.ToLower() == name.ToLower()) s.Display();
        Console.WriteLine("Press any key to Continue..");
        Console.ReadKey();
    }

    static void RegisterSubjects()
    {
        Console.Write("Enter Student Name: "); string name = Console.ReadLine();
        Student s = FindStudent(name);
        if (s == null || s.admittedProgram == "") { Console.WriteLine("Student not admitted."); return; }

        DegreeProgram dp = FindProgram(s.admittedProgram);
        if (dp == null) { Console.WriteLine("Program not found."); return; }

        Console.Write("Enter Subject Code: "); int code = int.Parse(Console.ReadLine());

        foreach (Subject sub in dp.subjects)
        {
            if (sub.code == code)
            {
                s.RegisterSubject(sub);
                Console.WriteLine("Press any key to Continue..");
                Console.ReadKey();
                return;
            }
        }
        Console.WriteLine("Subject not found in " + dp.name);
        Console.WriteLine("Press any key to Continue..");
        Console.ReadKey();
    }

    static void CalculateFeesAll()
    {
        foreach (Student s in registeredStudents)
        {
            float fees = s.CalculateFees();
            Console.WriteLine(s.name + " | Program: " + s.admittedProgram +
                " | Total Fees: $" + fees.ToString("F2"));
        }
        Console.WriteLine("Press any key to Continue..");
        Console.ReadKey();
    }

    static void Main()
    {
        int choice;
        do
        {
            Console.WriteLine("\n************************************");
            Console.WriteLine("                UAMS                ");
            Console.WriteLine("************************************");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Degree Program");
            Console.WriteLine("3. Generate Merit");
            Console.WriteLine("4. View Registered Students");
            Console.WriteLine("5. View Students of a Specific Program");
            Console.WriteLine("6. Register Subjects for a Specific Student");
            Console.WriteLine("7. Calculate Fees for all Registered Students");
            Console.WriteLine("8. Exit");
            Console.Write("Enter Option: ");
            choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (choice == 1) AddStudent();
            else if (choice == 2) AddDegreeProgram();
            else if (choice == 3) GenerateMerit();
            else if (choice == 4) ViewRegisteredStudents();
            else if (choice == 5) ViewStudentsOfProgram();
            else if (choice == 6) RegisterSubjects();
            else if (choice == 7) CalculateFeesAll();
            else if (choice == 8) Console.WriteLine("Goodbye!");
            else Console.WriteLine("Invalid option.");

        } while (choice != 8);
    }
}
