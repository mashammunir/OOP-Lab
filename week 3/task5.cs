using System;
using System.Collections.Generic;

class Book
{
    public string Title;
    public string Author;
    public string Genre;
    public float Rating;

    public Book(string title, string author, string genre, float rating)
    {
        Title = title;
        Author = author;
        Genre = genre;
        Rating = rating;
    }

    public Book(Book other)
    {
        Title = other.Title;
        Author = other.Author;
        Genre = other.Genre;
        Rating = other.Rating;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Book> library = new List<Book>
        {
            new Book("Atomic Habits",  "James Clear",    "Self Help",   4.8f),
            new Book("Deep Work",      "Cal Newport",    "Productivity", 4.7f),
            new Book("Mindset",        "Carol Dweck",    "Self Help",   4.3f),
            new Book("The Alchemist",  "Paulo Coelho",   "Fiction",     4.2f),
            new Book("Clean Code",     "Robert Martin",  "Technology",  4.6f)
        };

        Console.WriteLine("--- LIBRARY SYSTEM STARTED ---");
        Console.WriteLine();

        Console.WriteLine("Top Rated Books:");
        foreach (Book b in library)
        {
            if (b.Rating > 4.5f)
                Console.WriteLine(b.Title + " (Rating: " + b.Rating + ")");
        }

        Console.WriteLine();

        string searchGenre = "Self Help";
        Console.WriteLine("Search Genre: " + searchGenre);
        Console.WriteLine("Results:");
        foreach (Book b in library)
        {
            if (b.Genre == searchGenre)
                Console.WriteLine(b.Title);
        }

        Console.WriteLine();

        Book highestRated = null;
        foreach (Book b in library)
        {
            if (highestRated == null || b.Rating > highestRated.Rating)
                highestRated = b;
        }

        List<Book> recommended = new List<Book>();

        if (highestRated != null)
        {
            Book copy = new Book(highestRated);
            recommended.Add(copy);
            Console.WriteLine("Recommended Book Added:");
            Console.WriteLine(copy.Title);
        }

        Console.WriteLine();
        Console.WriteLine("--- LIBRARY REPORT COMPLETE ---");
    }
}
