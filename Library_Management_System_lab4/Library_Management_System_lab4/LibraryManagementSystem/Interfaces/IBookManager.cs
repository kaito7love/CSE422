using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Library_Management_System_lab4.LibraryManagementSystem.Models;

namespace Library_Management_System_lab4.LibraryManagementSystem.Interfaces
{
    
    public interface IBookManager
    {
        void AddBook(Book book);
        IEnumerable<Book> SearchBooks(string title, string category);
        bool LendBook(int bookId, Reader reader);
        void ReturnBook(int bookId, Reader reader);
    }

}
