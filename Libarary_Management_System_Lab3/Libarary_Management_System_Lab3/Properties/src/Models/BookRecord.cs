using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libarary_Management_System_Lab3.Properties.src.Models
{
    public record BookRecord
    {
        public string ISBN { get; init; }
        public string Title { get; init; }
        public string Author { get; init; }

        public BookRecord(string isbn, string title, string author)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
        }
    }

}
