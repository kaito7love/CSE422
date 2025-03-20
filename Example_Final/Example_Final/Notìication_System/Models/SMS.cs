using Example_Final.Notìication_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_Final.Notìication_System.Models
{
    public class SMS : INotification
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"Message from SMS: {message}");
        }
    }
}
