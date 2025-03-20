using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE422_HoaiNam_Lab5.LibraryManagementSystem.Documents
{
    public  class DocumentFactory
    {
        public static Document CreateDocument(string type, string title, string author)
        {
            return type.ToLower() switch
            {
                "book" => new Book(title, author),
                "magazine" => new Magazine(title, author),
                "newspaper" => new Newspaper(title, author),
                _ => throw new ArgumentException("Invalid document type")
            };
        }
    }
}

