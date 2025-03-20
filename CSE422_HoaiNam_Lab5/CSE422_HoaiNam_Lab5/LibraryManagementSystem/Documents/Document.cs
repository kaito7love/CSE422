using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE422_HoaiNam_Lab5.LibraryManagementSystem.Documents
{
    public abstract class Document
    {
        public string Title { get; set; }
        public string Author { get; set; }

        protected Document(string title, string author)
        {
            Title = title;
            Author = author;
        }
        public abstract string GetDocumentType();
        public abstract void Display();
    }
}
