using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE422_HoaiNam_Lab5.LibraryManagementSystem.Documents
{
    public class Newspaper : Document
    {
        public Newspaper(string title, string author) : base(title, author) { }
        public override string GetDocumentType()
        {
            return "Newspaper";
        }
        public override void Display()
        {
            Console.WriteLine($"Newspaper: {Title} by {Author}");
        }
    }
}
