using Libarary_Management_System_Lab3.Properties.src.Model;
using System;

public class LibraryCard
{
    public string CardNumber { get; }
    public Member Owner { get; set; }

    public DateTime IssueDate { get; private set; }

    public LibraryCard(string cardNumber, Member owner)
    {
        CardNumber = cardNumber;
        Owner = owner;
        IssueDate = DateTime.Now; // Set the current date when card is issued
    }

    // Method to renew the card by updating the IssueDate
    public void RenewCard()
    {
        IssueDate = DateTime.Now; // Update the issue date to current date
        Console.WriteLine($"Card {CardNumber} has been renewed. New issue date: {IssueDate}");
    }

    // Display information about the library card
    public void DisplayCardInfo()
    {
        Console.WriteLine($"Card Number: {CardNumber}, Owner: {Owner.Name}, Issue Date: {IssueDate.ToString("yyyy-MM-dd")}");
    }
}

