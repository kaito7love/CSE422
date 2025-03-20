using CSE422_HoaiNam_Lab5.LibraryManagementSystem.Documents;
using CSE422_HoaiNam_Lab5.LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE422_HoaiNam_Lab5.LibraryManagementSystem.Notifications
{
    public class Library
    {
        private List<IObserver> _observers = new List<IObserver>();
        private List<Document> _documents = new List<Document>();

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }
        private void NotifyObservers(string message)
        {
            foreach (var observer in _observers)
            {
                observer.Update(message);
            }
        }
        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void AddDocument(Document document)
        {
            _documents.Add(document);
            NotifyObservers($"New document added: {document.Title} by {document.Author}");
        }

      
    }
}
