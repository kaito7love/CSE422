

using Example_Final.Notìication_System.Interfaces;
using Example_Final.Notìication_System.Models;

class Program
{
    static void Main()
    {
        INotification emailNoti = new Email();
        emailNoti.SendNotification("This is message from Mail");

        INotification smsNoti = new SMS();
        smsNoti.SendNotification("This is message from SMS");

        INotification pushNoti = new PushNotification();
        pushNoti.SendNotification("This is message from Push Notification");

        Console.ReadKey();
    }

}

class Employee
{
    private string EmployeeName { get; set; }
    private int Age { get; set; }
    private double Salary { get; set; }

    public Employee(string employeeName, int age, double salary)
    {
        EmployeeName = employeeName;
        Age = age;
        Salary = salary;
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"Employee: {EmployeeName}, Age: {Age}, Salary: {Salary}");
    }
}