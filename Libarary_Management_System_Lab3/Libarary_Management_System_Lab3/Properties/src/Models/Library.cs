using Libarary_Management_System_Lab3.Properties.src.Model;
using System;
using System.Collections.Generic;

public class Library
{
    // Properties
    public string LibraryName { get; set; }
    public List<Book> Books { get; set; }
    public List<Member> Members { get; set; }

    public event Action<Book, Member> OnBookBorrowed;

    // Parameterless Constructor
    public Library()
    {
        LibraryName = "Default Library";
        Books = new List<Book>();
        Members = new List<Member>();
    }

    // Parameterized Constructor
    public Library(string libraryName, List<Book> books)
    {
        LibraryName = libraryName;
        Books = new List<Book>(books); // Create a copy of the list
        Members = new List<Member>(); // Initialize an empty list for members
    }

    public Library(string libraryName)
    {
        LibraryName = libraryName;
        Books = new List<Book>(); // Create a copy of the list
        Members = new List<Member>(); // Initialize an empty list for members
    }
    // Copy Constructor
    public Library(Library existingLibrary)
    {
        LibraryName = existingLibrary.LibraryName;
        Books = new List<Book>(existingLibrary.Books); // Copy the list of books
        Members = new List<Member>(existingLibrary.Members); // Copy the list of members
    }

    // Method to add a new book
    public void AddBook(Book book)
    {
        Books.Add(book);
        Console.WriteLine($"Book '{book.Title}' added to the library.");
    }

    // Method to add a new member
    public void AddMember(Member member)
    {
        Members.Add(member);
        Console.WriteLine($"Member '{member.Name}' added to the library.");
    }

    // Method to display library information
    public void DisplayLibraryInfo()
    {
        Console.WriteLine($"Library Name: {LibraryName}");
        Console.WriteLine($"Number of Books: {Books.Count}");
        Console.WriteLine($"Number of Members: {Members.Count}");
    }
    public void BorrowBook(Book book, Member member)
    {
        // Create a new BorrowTransaction
        var borrowTransaction = new BorrowTransaction(
            transactionID: Guid.NewGuid().ToString(),
            transactionDate: DateTime.Now,
            member: member,
            bookBorrowed: book
        );

        // Execute the borrow transaction (this will check availability and update the book count)
        borrowTransaction.Execute();

        // Trigger the event after a successful borrow
        OnBookBorrowed?.Invoke(book, member);
    }
}
