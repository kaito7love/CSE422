using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libarary_Management_System_Lab3.Properties.src.Interface;

namespace Libarary_Management_System_Lab3.Properties.src.Model
{
    public class Book : IPrintable
    {

        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        private int year;
        public int Year
        {
            get => year;
            set
            {
                if (value < 0) throw new ArgumentException("Year cannot be less than 0.");
                year = value;
            }
        }

        private int copiesAvailable;
        public int CopiesAvailable
        {
            get => copiesAvailable;
            set
            {
                if (value < 0) throw new ArgumentException("CopiesAvailable cannot be less than 0.");
                copiesAvailable = value;
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"ISBN: {ISBN}, Title: {Title}, Author: {Author}, Year: {Year}, CopiesAvailable: {CopiesAvailable}");
        }
        public void PrintDetails()
        {
            Console.WriteLine($"Book Details:");
            Console.WriteLine($"ISBN: {ISBN}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Year: {Year}");
            Console.WriteLine($"Copies Available: {CopiesAvailable}");
        }
    }

}
