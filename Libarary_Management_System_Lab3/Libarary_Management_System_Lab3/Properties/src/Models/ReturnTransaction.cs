using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libarary_Management_System_Lab3.Properties.src.Model
{
    public class ReturnTransaction : Transaction
    {
        public Book BookReturned { get; set; }

        // Constructor
        public ReturnTransaction(string transactionID, DateTime transactionDate, Member member, Book bookReturned)
            : base(transactionID, transactionDate, member)
        {
            BookReturned = bookReturned;
        }

        // Implement Execute method
        public override void Execute()
        {
            BookReturned.CopiesAvailable++;
            Console.WriteLine($"Book '{BookReturned.Title}' returned by {Member.Name} on {TransactionDate}.");
        }
    }
}
