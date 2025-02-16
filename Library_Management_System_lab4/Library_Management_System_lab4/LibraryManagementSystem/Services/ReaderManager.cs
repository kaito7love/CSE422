using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System_lab4.LibraryManagementSystem.Interfaces;
using System.Collections.Generic;
using Library_Management_System_lab4.LibraryManagementSystem.Models;

namespace Library_Management_System_lab4.LibraryManagementSystem.Services
{

    public class ReaderManager : IReaderManager
    {
        private readonly List<Reader> _readers = new();

        public Reader GetReaderById(int id)
        {
            return _readers.Find(reader => reader.Id == id);
        }

        public IEnumerable<Reader> GetAllReaders()
        {
            return _readers;
        }

        public void AddReader(Reader reader)
        {
            _readers.Add(reader);
        }
    }

}
