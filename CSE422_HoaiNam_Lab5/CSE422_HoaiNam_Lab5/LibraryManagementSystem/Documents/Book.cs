using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE422_HoaiNam_Lab5.LibraryManagementSystem.Documents
{
    public class Book : Document
    {
        public Book(string title, string author) : base(title, author) { }

        public override string GetDocumentType()
        {
            return "Book";
        }
        public override void Display()
        {
            Console.WriteLine($"Book: {Title} by {Author}");
        }
    }
}
