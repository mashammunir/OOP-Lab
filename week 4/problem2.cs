using System;
using System.Collections.Generic;

class Book
{
    public string title;
    public string author;
    public int pages;
    public List<string> chapters;
    public int bookMark;
    public int price;
    public bool isAvailable;

    public Book(string t, string a, int p, List<string> c, int bm, int pr, bool av)
    {
        title = t;
        author = a;
        pages = p;
        chapters = c;
        bookMark = bm;
        price = pr;
        isAvailable = av;
    }

    public bool IsBookAvailable()
    {
        return isAvailable;
    }

    public string GetChapter(int chapterNumber)
    {
        if (chapterNumber < 1 || chapterNumber > chapters.Count)
        {
            return "Invalid chapter number!";
        }
        return chapters[chapterNumber - 1];
    }

    public int GetBookMark()
    {
        return bookMark;
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Title:      " + title);
        Console.WriteLine("Author:     " + author);
        Console.WriteLine("Pages:      " + pages);
        Console.WriteLine("Price:      " + price);
        Console.WriteLine("BookMark:   Page " + bookMark);
        Console.WriteLine("Available:  " + (isAvailable ? "Yes" : "No"));
        Console.WriteLine("Chapters:   ");
        for (int i = 0; i < chapters.Count; i++)
        {
            Console.WriteLine("  " + (i + 1) + ". " + chapters[i]);
        }
    }
}

class Program
{
    static void Main()
    {
        List<string> chapters1 = new List<string>();
        chapters1.Add("Introduction to Programming");
        chapters1.Add("Variables and Data Types");
        chapters1.Add("Control Flow");
        chapters1.Add("Functions and Methods");
        chapters1.Add("Object Oriented Programming");

        Book b1 = new Book("C# For Beginners", "John Smith", 450, chapters1, 120, 1500, true);

        List<string> chapters2 = new List<string>();
        chapters2.Add("The Early Universe");
        chapters2.Add("Black Holes");
        chapters2.Add("Space and Time");
        chapters2.Add("The Future of the Cosmos");

        Book b2 = new Book("A Brief History of Time", "Stephen Hawking", 212, chapters2, 56, 800, false);

        Console.WriteLine("========== Book 1 ==========");
        b1.DisplayInfo();
        Console.WriteLine("--- Testing Functions ---");
        Console.WriteLine("Is Available:  " + (b1.IsBookAvailable() ? "Yes" : "No"));
        Console.WriteLine("BookMark:      Page " + b1.GetBookMark());
        Console.WriteLine("Chapter 3:     " + b1.GetChapter(3));
        Console.WriteLine("Chapter 10:    " + b1.GetChapter(10));

        Console.WriteLine();

        Console.WriteLine("========== Book 2 ==========");
        b2.DisplayInfo();
        Console.WriteLine("--- Testing Functions ---");
        Console.WriteLine("Is Available:  " + (b2.IsBookAvailable() ? "Yes" : "No"));
        Console.WriteLine("BookMark:      Page " + b2.GetBookMark());
        Console.WriteLine("Chapter 2:     " + b2.GetChapter(2));
        Console.WriteLine("Chapter 5:     " + b2.GetChapter(5));
    }
}
using System;

class Book
{
    public string title;
    public string[] authors;
    public int authorCount;
    public string publisher;
    public string isbn;
    public float price;
    public int stock;
    public int yearOfPublication;

    public Book()
    {
        title = "";
        authors = new string[4];
        authorCount = 0;
        publisher = "";
        isbn = "";
        price = 0;
        stock = 0;
        yearOfPublication = 0;
    }

    public Book(string t, string[] a, int ac, string pub, string ib, float pr, int st, int year)
    {
        title = t;
        authors = a;
        authorCount = ac;
        publisher = pub;
        isbn = ib;
        price = pr;
        stock = st;
        yearOfPublication = year;
    }

    public void SetTitle(string t)
    {
        title = t;
    }

    public string GetTitle()
    {
        return title;
    }

    public bool CheckTitle(string t)
    {
        return title.ToLower() == t.ToLower();
    }

    public void SetPublisher(string pub)
    {
        publisher = pub;
    }

    public string GetPublisher()
    {
        return publisher;
    }

    public void SetISBN(string ib)
    {
        isbn = ib;
    }

    public string GetISBN()
    {
        return isbn;
    }

    public bool CheckISBN(string ib)
    {
        return isbn == ib;
    }

    public void SetPrice(float pr)
    {
        price = pr;
    }

    public float GetPrice()
    {
        return price;
    }

    public void SetStock(int st)
    {
        stock = st;
    }

    public int GetStock()
    {
        return stock;
    }

    public void UpdateStock(int amount)
    {
        stock = stock + amount;
    }

    public void AddAuthor(string a)
    {
        if (authorCount < 4)
        {
            authors[authorCount] = a;
            authorCount++;
        }
        else
        {
            Console.WriteLine("Cannot add more than 4 authors.");
        }
    }

    public void ShowAuthors()
    {
        for (int i = 0; i < authorCount; i++)
        {
            Console.WriteLine("  Author " + (i + 1) + ": " + authors[i]);
        }
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Title:       " + title);
        ShowAuthors();
        Console.WriteLine("Publisher:   " + publisher);
        Console.WriteLine("ISBN:        " + isbn);
        Console.WriteLine("Price:       " + price);
        Console.WriteLine("Stock:       " + stock);
        Console.WriteLine("Year:        " + yearOfPublication);
    }
}

class Program
{
    static Book[] books = new Book[100];
    static int bookCount = 0;

    static void AddBook()
    {
        if (bookCount >= 100)
        {
            Console.WriteLine("Library is full!");
            return;
        }

        Book b = new Book();

        Console.Write("Enter Title: ");
        b.SetTitle(Console.ReadLine());

        Console.Write("How many authors? (max 4): ");
        int ac = int.Parse(Console.ReadLine());

        b.authors = new string[4];
        for (int i = 0; i < ac; i++)
        {
            Console.Write("Enter Author " + (i + 1) + ": ");
            b.AddAuthor(Console.ReadLine());
        }

        Console.Write("Enter Publisher: ");
        b.SetPublisher(Console.ReadLine());

        Console.Write("Enter ISBN: ");
        b.SetISBN(Console.ReadLine());

        Console.Write("Enter Price: ");
        b.SetPrice(float.Parse(Console.ReadLine()));

        Console.Write("Enter Stock: ");
        b.SetStock(int.Parse(Console.ReadLine()));

        Console.Write("Enter Year of Publication: ");
        b.yearOfPublication = int.Parse(Console.ReadLine());

        books[bookCount] = b;
        bookCount++;

        Console.WriteLine("Book added successfully!");
    }

    static void SearchByTitle()
    {
        Console.Write("Enter title to search: ");
        string t = Console.ReadLine();

        bool found = false;
        for (int i = 0; i < bookCount; i++)
        {
            if (books[i].CheckTitle(t))
            {
                Console.WriteLine("--- Book Found ---");
                books[i].DisplayInfo();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No book found with that title.");
        }
    }

    static void SearchByISBN()
    {
        Console.Write("Enter ISBN to search: ");
        string ib = Console.ReadLine();

        bool found = false;
        for (int i = 0; i < bookCount; i++)
        {
            if (books[i].CheckISBN(ib))
            {
                Console.WriteLine("--- Book Found ---");
                books[i].DisplayInfo();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No book found with that ISBN.");
        }
    }

    static void UpdateStock()
    {
        Console.Write("Enter ISBN of book to update stock: ");
        string ib = Console.ReadLine();

        bool found = false;
        for (int i = 0; i < bookCount; i++)
        {
            if (books[i].CheckISBN(ib))
            {
                Console.WriteLine("Current stock: " + books[i].GetStock());
                Console.Write("Enter amount to add (use negative to reduce): ");
                int amount = int.Parse(Console.ReadLine());
                books[i].UpdateStock(amount);
                Console.WriteLine("Stock updated! New stock: " + books[i].GetStock());
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No book found with that ISBN.");
        }
    }

    static void DisplayAllBooks()
    {
        if (bookCount == 0)
        {
            Console.WriteLine("No books in the library.");
            return;
        }

        for (int i = 0; i < bookCount; i++)
        {
            Console.WriteLine("========== Book " + (i + 1) + " ==========");
            books[i].DisplayInfo();
        }
    }

    static void Main()
    {
        string[] authors1 = { "Robert Lafore" };
        books[bookCount++] = new Book("OOP in C++", authors1, 1, "Pearson", "978-0-13-468681-8", 2500, 10, 2002);

        string[] authors2 = { "Herbert Schildt", "James Holmes" };
        books[bookCount++] = new Book("C# Complete Reference", authors2, 2, "McGraw Hill", "978-0-07-174111-7", 3200, 5, 2018);

        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine();
            Console.WriteLine("===== Library Menu =====");
            Console.WriteLine("1. Add a Book");
            Console.WriteLine("2. Search by Title");
            Console.WriteLine("3. Search by ISBN");
            Console.WriteLine("4. Update Stock");
            Console.WriteLine("5. Display All Books");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            choice = int.Parse(Console.ReadLine());

            Console.WriteLine();

            if (choice == 1)
            {
                AddBook();
            }
            else if (choice == 2)
            {
                SearchByTitle();
            }
            else if (choice == 3)
            {
                SearchByISBN();
            }
            else if (choice == 4)
            {
                UpdateStock();
            }
            else if (choice == 5)
            {
                DisplayAllBooks();
            }
            else if (choice == 6)
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }
}