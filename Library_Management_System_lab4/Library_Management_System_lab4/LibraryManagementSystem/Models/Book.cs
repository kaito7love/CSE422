using System;
using System.Collections.Generic;
using System.Linq;

namespace Library_Management_System_lab4.LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Category { get; private set; }
        public int Quantity { get; private set; }

        public Book(int id, string title, string author, string category, int quantity)
        {
            Id = id;
            Title = title;
            Author = author;
            Category = category;
            Quantity = quantity;
        }


        public bool IsAvailable() => Quantity > 0;

        public void Borrow() => Quantity--;

        public void Return() => Quantity++;
    }

}