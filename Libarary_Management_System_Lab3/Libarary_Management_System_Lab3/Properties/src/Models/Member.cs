using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libarary_Management_System_Lab3.Properties.src.Interface;

namespace Libarary_Management_System_Lab3.Properties.src.Model
{
    // Base class: Member
    public class Member : IPrintable, IMemberActions
    {
        // Properties
        public string MemberID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Book> BorrowedBooks { get; private set; }

        // Constructor
        public Member(string memberID, string name, string email)
        {
            MemberID = memberID;
            Name = name;
            Email = email;
            BorrowedBooks = new List<Book>();
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"MemberID: {MemberID}, Name: {Name}, Email: {Email}");
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Member ID: {MemberID}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Email: {Email}");
        }



        public virtual void BorrowBook(Book book)
        {
            if (book.CopiesAvailable > 0)
            {
                BorrowedBooks.Add(book);
                book.CopiesAvailable--;
                Console.WriteLine($"{Name} borrowed the book '{book.Title}'.");
            }
            else
            {
                Console.WriteLine($"The book '{book.Title}' is not available for borrowing.");
            }
        }

        public virtual void ReturnBook(Book book)
        {
            if (BorrowedBooks.Contains(book))
            {
                BorrowedBooks.Remove(book);
                book.CopiesAvailable++;
                Console.WriteLine($"{Name} returned the book '{book.Title}'.");
            }
            else
            {
                Console.WriteLine($"{Name} cannot return the book '{book.Title}' because it was not borrowed.");
            }
        }
    }

    // Derived class: PremiumMember
    public class PremiumMember : Member
    {
        // Additional properties
        public DateTime MembershipExpiry { get; set; }
        public int MaxBooksAllowed { get; set; }

        // Constructor (calls base class constructor)
        public PremiumMember(string memberID, string name, string email, DateTime membershipExpiry, int maxBooksAllowed)
            : base(memberID, name, email)
        {
            MembershipExpiry = membershipExpiry;
            MaxBooksAllowed = maxBooksAllowed;
        }

        public override void BorrowBook(Book book)
        {
            if (BorrowedBooks.Count >= MaxBooksAllowed)
            {
                Console.WriteLine($"{Name} has already borrowed the maximum allowed books ({MaxBooksAllowed}).");
                return;
            }

            base.BorrowBook(book);
        }

        public override void ReturnBook(Book book)
        {
            // Ensure the base class logic is invoked first
            if (BorrowedBooks.Contains(book))
            {
                base.ReturnBook(book);
            }
            else
            {
                Console.WriteLine($"{Name} cannot return the book '{book.Title}' because it was not borrowed.");
            }
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"MembershipExpiry: {MembershipExpiry}, MaxBooksAllowed: {MaxBooksAllowed}");
        }
        public void PrintDetails()
        {
            Console.WriteLine($"Membership Expiry: {MembershipExpiry.ToShortDateString()}");
            Console.WriteLine($"Max Books Allowed: {MaxBooksAllowed}");
        }
    }

}
