using Libarary_Management_System_Lab3.Properties.src.Model;
using Libarary_Management_System_Lab3.Properties.src.Models;

class Program
{
    static void Main(string[] args)
    {// Create books
        var book1 = new Book
        {
            ISBN = "978-3-16-148410-0",
            Title = "C# Programming Essentials",
            Author = "John Doe",
            Year = 2021,
            CopiesAvailable = 3
        };

        var book2 = new Book
        {
            ISBN = "978-1-23-456789-7",
            Title = "Advanced C# Techniques",
            Author = "Jane Smith",
            Year = 2022,
            CopiesAvailable = 2
        };


        // Create members
        var member1 = new Member("M001", "Alice Johnson", "alice.johnson@example.com");
        var member2 = new Member("M002", "Bob Smith", "bob.smith@example.com");

        // Create a list of transactions
        var transactions = new List<Transaction>
        {
            new BorrowTransaction("T001", DateTime.Now, member1, book1),
            new ReturnTransaction("T002", DateTime.Now, member2, book2),
            new BorrowTransaction("T003", DateTime.Now, member2, book2)
        };

        // Iterate through the list and execute each transaction
        foreach (var transaction in transactions)
        {
            transaction.Execute();
        }

        // Display updated book details
        Console.WriteLine("\nUpdated Book Details:");
        book1.PrintDetails();
        Console.WriteLine();
        book2.PrintDetails();
        Console.WriteLine("--------------------------------------");
        // Create some books
        var books = new List<Book>
        {
            new Book
            {
                ISBN = "978-3-16-148410-0",
                Title = "C# Programming Essentials",
                Author = "John Doe",
                Year = 2021,
                CopiesAvailable = 5
            },
            new Book
            {
                ISBN = "978-1-23-456789-7",
                Title = "Advanced C# Techniques",
                Author = "Jane Smith",
                Year = 2022,
                CopiesAvailable = 3
            }
        };

        // Create a library using the parameterized constructor
        var library1 = new Library("City Library", books);
        library1.DisplayLibraryInfo();

        Console.WriteLine();

        // Create a library using the copy constructor
        var library2 = new Library(library1);
        library2.LibraryName = "New Branch Library";
        library2.DisplayLibraryInfo();

        Console.WriteLine();

        // Create a library using the parameterless constructor
        var library3 = new Library();
        library3.DisplayLibraryInfo();

        Console.WriteLine("------------------------------");

        // Create objects for both classes
        NotificationService notificationService = new NotificationService();
        AdvancedNotificationService advancedNotificationService = new AdvancedNotificationService();

        // Testing overloaded methods for NotificationService
        Console.WriteLine("NotificationService - Overloaded methods:");
        notificationService.SendNotification("Hello!");
        notificationService.SendNotification("Hello!", "Alice");
        notificationService.SendNotification("Hello!", new List<string> { "Alice", "Bob", "Charlie" });

        Console.WriteLine();

        // Testing overridden method in AdvancedNotificationService
        Console.WriteLine("AdvancedNotificationService - Overridden method:");
        advancedNotificationService.SendNotification("Hello!");
        Console.WriteLine("------------------------------");


        // Creating objects of BookClass and BookRecord
        BookClass bookClass1 = new BookClass("12345", "The Great Gatsby", "F. Scott Fitzgerald");
        BookClass bookClass2 = new BookClass("12345", "The Great Gatsby", "F. Scott Fitzgerald");

        BookRecord bookRecord1 = new BookRecord("12345", "The Great Gatsby", "F. Scott Fitzgerald");
        BookRecord bookRecord2 = new BookRecord("12345", "The Great Gatsby", "F. Scott Fitzgerald");

        // Comparing BookClass objects
        Console.WriteLine($"BookClass objects are equal: {bookClass1 == bookClass2}");

        // Comparing BookRecord objects
        Console.WriteLine($"BookRecord objects are equal: {bookRecord1 == bookRecord2}");

        // Using the 'with' expression to modify properties of BookRecord
        BookRecord bookRecord3 = bookRecord1 with { Title = "The Great Gatsby - Updated" };

        Console.WriteLine($"Original Title: {bookRecord1.Title}");
        Console.WriteLine($"Updated Title: {bookRecord3.Title}");

        Console.WriteLine("-----------------------------------------");
        // Create a library instance
        Library library = new Library("My Local Library");

        // Create some books and members
        //Book book1 = new Book("12345", "C# Programming", "John Smith", 2020, 5);
        //Book book2 = new Book("67890", "Learn C#", "Jane Doe", 2021, 3);
        //Member member1 = new Member("M001", "Alice Johnson", "alice.johnson@email.com");
        //Member member2 = new Member("M002", "Bob Brown", "bob.brown@email.com");

        // Add books and members to the library
        library.Books.Add(book1);
        library.Books.Add(book2);
        library.Members.Add(member1);
        library.Members.Add(member2);

        // Subscribe to the event (you can add multiple subscribers as needed)
        library.OnBookBorrowed += (book, member) =>
        {
            Console.WriteLine($"{member.Name} borrowed the book '{book.Title}'.");
        };
        // Borrow a book and execute the transaction
        library.BorrowBook(book1, member1);
        Console.WriteLine("-------------");
        library.BorrowBook(book2, member1);
        Console.WriteLine("-------------");
        library.BorrowBook(book1, member2);
        Console.WriteLine("-------------");
        library.BorrowBook(book2, member2);
    }
}
