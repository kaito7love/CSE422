using CSE422_HoaiNam_Lab5.LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE422_HoaiNam_Lab5.LibraryManagementSystem.Notifications
{
    public class User : IObserver
    {
        public string Name { get; set; }

        public User(string name) => Name = name;

        public void Update(string message)
        {
            Console.WriteLine($"Notification for {Name}: {message}");
        }
    }
}
