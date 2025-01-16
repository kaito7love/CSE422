using DeviceManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; // Required for SelectList
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DeviceController : Controller
{

    // Static data for devices
    public static List<Device> Devices = new List<Device>
    {
        new Device { Id = 1, Name = "Laptop", Code = "D001", CategoryId = 1, Status = "In use", DateOfEntry = new DateTime(2023, 1, 1) },
        new Device { Id = 2, Name = "Desktop", Code = "D002", CategoryId = 1, Status = "Under maintenance", DateOfEntry = new DateTime(2023, 3, 15) },
        new Device { Id = 3, Name = "Laser Printer", Code = "D003", CategoryId = 2, Status = "Broken", DateOfEntry = new DateTime(2023, 5, 20) },
        new Device { Id = 4, Name = "Mobile Phone", Code = "D004", CategoryId = 3, Status = "In use", DateOfEntry = new DateTime(2023, 7, 10) },
        new Device { Id = 5, Name = "Scanner Printer", Code = "D005", CategoryId = 2, Status = "In use", DateOfEntry = new DateTime(2023, 9, 5) }
    };

    public IActionResult Index(int? categoryId, string searchTerm, string statusFilter)
    {
        // Start with all devices
        var filteredDevices = Devices.AsQueryable();

        //// Filter by category if provided
        if (categoryId.HasValue && categoryId.Value != 0)
        {
            filteredDevices = filteredDevices.Where(d => d.CategoryId == categoryId.Value);
        }
        if (!string.IsNullOrEmpty(statusFilter))
        {
            filteredDevices = filteredDevices.Where(d => d.Status.Equals(statusFilter, StringComparison.OrdinalIgnoreCase));
        }

        // Search by device name or code if searchTerm is provided
        if (!string.IsNullOrEmpty(searchTerm))
        {
            filteredDevices = filteredDevices.Where(d =>
                d.Name.StartsWith(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                d.Code.StartsWith(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        // Prepare category list for the dropdown in the view
        ViewBag.Categories = new SelectList(DeviceCategoryController.GetCategories(), "Id", "Name");

        ViewBag.Statuses = Devices.Select(d => d.Status).Distinct().ToList();
        // Return the filtered list of devices to the view
        return View(filteredDevices.ToList());
    }



    // Create action to show the form
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(DeviceCategoryController.GetCategories(), "Id", "Name");
        return View();
    }

    // Create action to handle form submission
    [HttpPost]
    public IActionResult Create(Device device)
    {
        // Simulate adding the device to the "database"
        device.Id = Devices.Max(d => d.Id) + 1; // Auto-increment ID
        Devices.Add(device);
        return RedirectToAction("Index");
    }

    // Delete action
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var device = Devices.FirstOrDefault(d => d.Id == id);
        if (device != null)
        {
            Devices.Remove(device);
        }
        return RedirectToAction("Index");
    }


    // Edit action to show the form
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var device = Devices.FirstOrDefault(d => d.Id == id);
        if (device == null)
        {
            return NotFound();
        }

        ViewBag.Categories = new SelectList(DeviceCategoryController.GetCategories(), "Id", "Name", device.CategoryId);
        return View(device);
    }

    // Edit action to handle form submission
    [HttpPost]
    public IActionResult Edit(Device device)
    {
        var existingDevice = Devices.FirstOrDefault(d => d.Id == device.Id);
        if (existingDevice == null)
        {
            return NotFound();
        }

        existingDevice.Name = device.Name;
        existingDevice.Code = device.Code;
        existingDevice.CategoryId = device.CategoryId;
        existingDevice.Status = device.Status;
        existingDevice.DateOfEntry = device.DateOfEntry;

        return RedirectToAction("Index");
    }



}
