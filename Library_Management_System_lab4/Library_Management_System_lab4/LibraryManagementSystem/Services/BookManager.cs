using Library_Management_System_lab4.LibraryManagementSystem.Interfaces;
using Library_Management_System_lab4.LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library_Management_System_lab4.LibraryManagementSystem.Services
{


    public class BookManager : IBookManager
    {
        private readonly List<Book> _books = new();

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public IEnumerable<Book> SearchBooks(string title, string category)
        {

            return _books.Where(book =>
            (!string.IsNullOrEmpty(title) && book.Title.Contains(title, StringComparison.OrdinalIgnoreCase)) ||
            (!string.IsNullOrEmpty(category) && book.Category.Contains(category, StringComparison.OrdinalIgnoreCase)));

        }

        public bool LendBook(int bookId, Reader reader)
        {
            var book = _books.FirstOrDefault(b => b.Id == bookId);
            if (book == null || !book.IsAvailable() || !reader.CanBorrowMoreBooks())
            {
                return false;
            }

            book.Borrow();
            reader.BorrowBook(new BorrowRecord(book.Id, book.Title));
            return true;
        }

        public void ReturnBook(int bookId, Reader reader)
        {
            var book = _books.FirstOrDefault(b => b.Id == bookId);
            if (book != null)
            {
                book.Return();
                reader.ReturnBook(bookId);

            }
        }
    }

}