using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_lab4.LibraryManagementSystem.Models
{
    public class BorrowRecord
    {
        public int BookId { get; }
        public string BookTitle { get; }

        public int CountBookBorrow { get; set; }

        public BorrowRecord(int bookId, string bookTitle)
        {
            BookId = bookId;
            BookTitle = bookTitle;
            //CountBookBorrow = countBookBorrow;
        }


    }

}
