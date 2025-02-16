using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Library_Management_System_lab4.LibraryManagementSystem.Models
{
   
    public class Reader
    {
        public int Id { get; }
        public string Name { get; }
        public List<BorrowRecord> BorrowedBooks { get; }

        public Reader(int id, string name)
        {
            Id = id;
            Name = name;
            BorrowedBooks = new List<BorrowRecord>();
        }

        public bool CanBorrowMoreBooks() => BorrowedBooks.Count < 3;

        public void BorrowBook(BorrowRecord record) => BorrowedBooks.Add(record);

        public void ReturnBook(int bookId) => BorrowedBooks.RemoveAll(r => r.BookId == bookId);
    }

}
