using Library_Management_System_lab4.LibraryManagementSystem.Interfaces;
using Library_Management_System_lab4.LibraryManagementSystem.Models;
using Library_Management_System_lab4.LibraryManagementSystem.Services;
using System;
using System.Collections.Generic;

class Program
{

    public static class SampleData
    {
        public static List<Book> GetBooks()
        {
            return new List<Book>
        {
            new Book(1, "The Great Gatsby 1", "F. Scott Fitzgerald", "Fiction1", 5),
            new Book(2, "1984", "George Orwell 1", "Dystopian", 3),
            new Book(3, "To Kill a Mockingbird 2", "Harper Lee", "Fiction", 4),
            new Book(4, "The Great Gatsby 2", "F. Scott Fitzgerald", "Fiction", 5),
            new Book(5, "1984", "George Orwell 2", "Dystopian", 3),
            new Book(6, "To Kill a Mockingbird 2", "Harper Lee", "Fiction", 4),
        };
        }

        public static List<Reader> GetReaders()
        {
            return new List<Reader>
        {
            new Reader(1, "Alice"),
            new Reader(2, "Bob"),
            new Reader(3, "Charlie")
        };
        }
    }

    static void Main(string[] args)
    {
        // Initialize managers and services
        IBookManager bookManager = new BookManager();
        IReaderManager readerManager = new ReaderManager();
        IReportService reportService = new ReportService(readerManager);

        // Add sample data
        foreach (var book in SampleData.GetBooks())
        {
            bookManager.AddBook(book);
        }

        foreach (var readerTest in SampleData.GetReaders())
        {
            readerManager.AddReader(readerTest);
        }

        // Search for books
        Console.WriteLine("Search Results:");
        foreach (var book in bookManager.SearchBooks("1984", ""))
        {
            Console.WriteLine($"{book.Title} by {book.Author}");
        }

        // Lend a book
        var reader = readerManager.GetReaderById(1);
        var reader2 = readerManager.GetReaderById(2);
        if (bookManager.LendBook(1, reader))
        {
            Console.WriteLine("Book borrowed successfully!");
        }
        if (bookManager.LendBook(3, reader))
        {
            Console.WriteLine("Book borrowed successfully!");
        }
        if (bookManager.LendBook(3, reader2))
        {
            Console.WriteLine("Book borrowed successfully!");
        }
       
        // Generate reports
        reportService.GenerateReaderReport();
        Console.WriteLine("----------------");
        // Reuturn a book
        bookManager.ReturnBook(1, reader);

        reportService.GenerateReaderReport();

    }
}
