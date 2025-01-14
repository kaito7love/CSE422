using DeviceManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

public class UserController : Controller
{
    // Static list to simulate a database for users
    private static List<User> Users = new List<User>
    {
        new User { Id = 1, FullName = "John Doe", Email = "john.doe@example.com", PhoneNumber = "1234567890" },
        new User { Id = 2, FullName = "Jane Smith", Email = "jane.smith@example.com", PhoneNumber = "0987654321" }
    };

    // Index action to display users
    public IActionResult Index()
    {
        return View(Users);
    }

    // Create action to show the form
    public IActionResult Create()
    {
        return View();
    }

    // Create action to handle form submission
    [HttpPost]
    public IActionResult Create(User user)
    {
        if (ModelState.IsValid)
        {
            // Auto-increment the user ID
            user.Id = Users.Max(u => u.Id) + 1;
            Users.Add(user);
            return RedirectToAction("Index");
        }
        return View(user);
    }

    // Edit action to show the form with current data
    public IActionResult Edit(int id)
    {
        var user = Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    // Edit action to handle form submission
    [HttpPost]
    public IActionResult Edit(User user)
    {
        var existingUser = Users.FirstOrDefault(u => u.Id == user.Id);
        if (existingUser == null)
        {
            return NotFound();
        }

        existingUser.FullName = user.FullName;
        existingUser.Email = user.Email;
        existingUser.PhoneNumber = user.PhoneNumber;

        return RedirectToAction("Index");
    }

    // Delete action
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var user = Users.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            Users.Remove(user);
        }
        return RedirectToAction("Index");
    }
}
