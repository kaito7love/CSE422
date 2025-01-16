using Libarary_Management_System_Lab3.Properties.src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libarary_Management_System_Lab3.Properties.src.Interface
{
    internal interface IMemberActions
    {
        void BorrowBook(Book book);
        void ReturnBook(Book book);
    }
}
