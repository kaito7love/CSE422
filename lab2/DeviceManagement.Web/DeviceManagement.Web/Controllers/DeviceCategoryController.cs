using Microsoft.AspNetCore.Mvc;
using DeviceManagement.Web.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

public class DeviceCategoryController : Controller
{
    // Static data for device categories
    private static List<DeviceCategory> Categories = new List<DeviceCategory>
    {
        new DeviceCategory { Id = 1, Name = "Computer" },
        new DeviceCategory { Id = 2, Name = "Printer" },
        new DeviceCategory { Id = 3, Name = "Phone" }
    };
    public static List<DeviceCategory> GetCategories() => Categories;
    // Index action to display device categories
    public IActionResult Index()
    {
        return View(Categories);
    }


    // Create action to show the form
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(DeviceCategoryController.GetCategories(), "Id", "Name");
        return View();
    }

    // Create action to handle form submission
    [HttpPost]
    public IActionResult Create(DeviceCategory category)
    {
        // Kiểm tra dữ liệu đầu vào
        System.Diagnostics.Debug.WriteLine($"Category Name: {category?.Name}");

        // Thêm dữ liệu
        category.Id = Categories.Any() ? Categories.Max(c => c.Id) + 1 : 1;
        Categories.Add(category);

        return RedirectToAction("Index");
    }




    // Delete action
    [HttpPost]
    public IActionResult Delete(int id)
    {
        // Tìm danh mục cần xóa
        var category = Categories.FirstOrDefault(c => c.Id == id);
        if (category != null)
        {
            //// Xóa tất cả thiết bị có CategoryId tương ứng
            //DeviceController.Devices.RemoveAll(d => d.CategoryId == id);

            // Xóa danh mục
            Categories.Remove(category);
        }
        return RedirectToAction("Index");

    }

    //public IActionResult Edit()
    //{
    //    return View();
    //}
    // Edit action to show the form
    public IActionResult Edit(int id)
    {
        // Tìm danh mục cần chỉnh sửa
        var category = Categories.FirstOrDefault(c => c.Id == id);
        if (category == null)
        {
            return NotFound($"Category with ID {id} does not exist.");
        }

        // Trả về view với thông tin danh mục
        return View(category);
    }

    // Edit action to handle form submission
    [HttpPost]
    public IActionResult Edit(DeviceCategory category)
    {
        // Tìm danh mục hiện tại trong danh sách
        var existingCategory = Categories.FirstOrDefault(c => c.Id == category.Id);
        if (existingCategory == null)
        {
            return NotFound($"Category with ID {category.Id} does not exist.");
        }

        // Cập nhật dữ liệu danh mục
        existingCategory.Name = category.Name;

        // Chuyển hướng về trang Index sau khi chỉnh sửa
        return RedirectToAction("Index");
    }

}
