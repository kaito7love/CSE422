using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE422_HoaiNam_Lab5.LibraryManagementSystem.Database
{
    public class DatabaseConnection
    {
        private static DatabaseConnection? _instance;
        private static readonly object _lock = new object();

        private DatabaseConnection()
        {
            Console.WriteLine("Database connection established.");
        }

        public static DatabaseConnection GetInstance()
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new DatabaseConnection();
                }
            }
            return _instance;
        }

        public void Connect() => Console.WriteLine("Connected to Database.");
    }
}
