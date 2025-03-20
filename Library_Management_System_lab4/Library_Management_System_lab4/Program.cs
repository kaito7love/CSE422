using Library_Management_System_lab4.LibraryManagementSystem.Interfaces;
using Library_Management_System_lab4.LibraryManagementSystem.Models;
using Library_Management_System_lab4.LibraryManagementSystem.Services;
using System;
using System.Collections.Generic;

class Program
{
    public static class SampleData
    {
        public static List<Book> GetBooks() => new List<Book>
        {
            new Book(1, "The Great Gatsby", "F. Scott Fitzgerald", "Fiction", 5),
            new Book(2, "1984", "George Orwell", "Dystopian", 3),
            new Book(3, "To Kill a Mockingbird", "Harper Lee", "Fiction", 4)
        };

        public static List<Reader> GetReaders() => new List<Reader>
        {
            new Reader(1, "Alice"),
            new Reader(2, "Bob"),
            new Reader(3, "Charlie")
        };
    }

    static void Main(string[] args)
    {
        IBookManager bookManager = new BookManager();
        IReaderManager readerManager = new ReaderManager();
        IReportService reportService = new ReportService(readerManager);

        foreach (var book in SampleData.GetBooks())
            bookManager.AddBook(book);

        foreach (var reader in SampleData.GetReaders())
            readerManager.AddReader(reader);

        while (true)
        {
            Console.WriteLine("\nLibrary Management System");
            Console.WriteLine("1. Search for a book");
            Console.WriteLine("2. Lend a book");
            Console.WriteLine("3. Return a book");
            Console.WriteLine("4. Generate report");
            Console.WriteLine("5. Add new book");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter book title: ");
                    string title = Console.ReadLine();
                    var books = bookManager.SearchBooks(title, "");
                    foreach (var book in books)
                        Console.WriteLine($"{book.Title} by {book.Author} ({book.Quantity} available)");
                    break;

                case "2":
                    Console.Write("Enter Reader ID: ");
                    int readerId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Book ID: ");
                    int bookId = int.Parse(Console.ReadLine());

                    var reader = readerManager.GetReaderById(readerId);
                    if (reader != null && bookManager.LendBook(bookId, reader))
                        Console.WriteLine("Book borrowed successfully!");
                    else
                        Console.WriteLine("Borrowing failed!");
                    break;

                case "3":
                    Console.Write("Enter Reader ID: ");
                    readerId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Book ID: ");
                    bookId = int.Parse(Console.ReadLine());

                    reader = readerManager.GetReaderById(readerId);
                    if (reader != null)
                    {
                        bookManager.ReturnBook(bookId, reader);
                        Console.WriteLine("Book returned successfully!");
                    }
                    else
                        Console.WriteLine("Invalid reader ID!");
                    break;

                case "4":
                    reportService.GenerateReaderReport();
                    break;

                case "5":
                    Console.Write("Enter Book ID: ");
                    int newBookId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Title: ");
                    string newTitle = Console.ReadLine();
                    Console.Write("Enter Author: ");
                    string newAuthor = Console.ReadLine();
                    Console.Write("Enter Category: ");
                    string newCategory = Console.ReadLine();
                    Console.Write("Enter Quantity: ");
                    int newQuantity = int.Parse(Console.ReadLine());

                    Book newBook = new Book(newBookId, newTitle, newAuthor, newCategory, newQuantity);
                    bookManager.AddBook(newBook);
                    Console.WriteLine("Book added successfully!");
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}
