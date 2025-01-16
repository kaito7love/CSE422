using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libarary_Management_System_Lab3.Properties.src.Model
{

    // Abstract base class: Transaction
    public abstract class Transaction
    {
        // Properties
        public string TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public Member Member { get; set; }

        // Constructor
        public Transaction(string transactionID, DateTime transactionDate, Member member)
        {
            TransactionID = transactionID;
            TransactionDate = transactionDate;
            Member = member;
        }

        // Abstract method
        public abstract void Execute();
    }

}
