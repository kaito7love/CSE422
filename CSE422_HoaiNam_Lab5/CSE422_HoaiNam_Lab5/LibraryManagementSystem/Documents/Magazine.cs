using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE422_HoaiNam_Lab5.LibraryManagementSystem.Documents
{
    public class Magazine : Document
    {
        public Magazine(string title, string author) : base(title, author) { }
        public override string GetDocumentType()
        {
            return "Magazine";
        }
        public override void Display()
        {
            Console.WriteLine($"Magazine: {Title} by {Author}");
        }
    }
}
