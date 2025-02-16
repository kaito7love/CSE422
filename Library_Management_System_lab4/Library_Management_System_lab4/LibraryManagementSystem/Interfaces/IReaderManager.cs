using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Library_Management_System_lab4.LibraryManagementSystem.Models;

namespace Library_Management_System_lab4.LibraryManagementSystem.Interfaces
{
    
    public interface IReaderManager
    {
        Reader GetReaderById(int id);
        IEnumerable<Reader> GetAllReaders();
        void AddReader(Reader reader1);
    }

}
