using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System_lab4.LibraryManagementSystem.Interfaces;
using Library_Management_System_lab4.LibraryManagementSystem.Models;

namespace Library_Management_System_lab4.LibraryManagementSystem.Services
{


    public class ReportService : IReportService
    {
        private readonly IReaderManager _readerManager;

        public ReportService(IReaderManager readerManager)
        {
            _readerManager = readerManager;
        }

        public void GenerateReaderReport()
        {
            var readers = _readerManager.GetAllReaders();
            Console.WriteLine("All Reader Report:");
            foreach (var reader in readers)
            {
                Console.WriteLine($"Reader: {reader.Name}");
                foreach (var record in reader.BorrowedBooks)
                {
                    Console.WriteLine($"- {record.BookTitle}");
                }
            }
        }
    }

}
