using Libarary_Management_System_Lab3.Properties.src.Model;
using System;
using System.Collections.Generic;

public class NotificationService
{
    // Overloaded methods for sending notifications
    public virtual void SendNotification(string message)
    {
        Console.WriteLine($"Sending notification: {message}");
    }

    public virtual void SendNotification(string message, string recipient)
    {
        Console.WriteLine($"Sending notification to {recipient}: {message}");
    }

    public virtual void SendNotification(string message, List<string> recipients)
    {
        foreach (var recipient in recipients)
        {
            Console.WriteLine($"Sending notification to {recipient}: {message}");
        }
    }
    public void NotifyBookBorrowed(Book book, Member member)
    {
        Console.WriteLine($"Notification: {member.Name} borrowed '{book.Title}' by {book.Author}.");
    }
}
public class AdvancedNotificationService : NotificationService
{
    // Overriding the method to add a timestamp
    public override void SendNotification(string message)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Console.WriteLine($"[{timestamp}] Sending notification: {message}");
    }
}
