using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libarary_Management_System_Lab3.Properties.src.Model
{
    public class BorrowTransaction : Transaction
    {
        public Book BookBorrowed { get; set; }

        // Constructor
        public BorrowTransaction(string transactionID, DateTime transactionDate, Member member, Book bookBorrowed)
            : base(transactionID, transactionDate, member)
        {
            BookBorrowed = bookBorrowed;
        }

        // Implement Execute method
        public override void Execute()
        {
            if (BookBorrowed.CopiesAvailable > 0)
            {
                BookBorrowed.CopiesAvailable--;
                Console.WriteLine($"Book '{BookBorrowed.Title}' borrowed by {Member.Name} on {TransactionDate}.");
            }
            else
            {
                Console.WriteLine($"Book '{BookBorrowed.Title}' is not available for borrowing.");
            }
        }
    }

}
