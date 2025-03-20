using System;
using CSE422_HoaiNam_Lab5.LibraryManagementSystem.Database;
using CSE422_HoaiNam_Lab5.LibraryManagementSystem.Documents;
using CSE422_HoaiNam_Lab5.LibraryManagementSystem.LoanFees;
using CSE422_HoaiNam_Lab5.LibraryManagementSystem.Notifications;

class Program
{
    static void Main()
    {
        // Singleton Database Connection
        var db = DatabaseConnection.GetInstance();
        db.Connect();

        // Observer Pattern - Notifications
        var library = new Library();
        var user1 = new User("Nam");
        var user2 = new User("Duy");
        var user3 = new User("Vu");

        library.AddObserver(user1);
        library.AddObserver(user2);
        library.AddObserver(user3);

        var book1 = DocumentFactory.CreateDocument("book", "C# in Depth", "Jon Skeet");
        

        var magazine1 = DocumentFactory.CreateDocument("magazine", "Tech Weekly", "John Doe");
        

        var newspaper1 = DocumentFactory.CreateDocument("newspaper", "The Daily Times", "Editorial Team");
     
        Console.WriteLine("---------------------------------");
        library.AddDocument(book1);

        Console.WriteLine("---------------------------------");
        library.AddDocument(magazine1);

        Console.WriteLine("---------------------------------");
        library.AddDocument(newspaper1);
        Console.WriteLine("---------------------------------");
        // Strategy Pattern - Loan Fee Calculation
        var loanCalculator = new LoanFeeCalculator(new BookLoanFee());
        Console.WriteLine($"Book Loan Fee for 7 days: ${loanCalculator.GetLoanFee(10)}");

        loanCalculator.SetStrategy(new MagazineLoanFee());
        Console.WriteLine($"Magazine Loan Fee for 7 days: ${loanCalculator.GetLoanFee(10)}");

        loanCalculator.SetStrategy(new NewspaperLoanFee());
        Console.WriteLine($"Newspaper Loan Fee for 7 days: ${loanCalculator.GetLoanFee(10)}");

        Console.ReadKey();
    }

}

