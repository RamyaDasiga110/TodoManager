using Microsoft.AspNetCore.Mvc;
using TodoWebApplication.Models;
using System.Collections.Generic;
using System.Linq;

namespace TodoWebApplication.Controllers
{
    public class TaskController : Controller
    {
        private static List<TodoWebApplication.Models.Task> tasks = new();
        private static int nextId = 1;
        public IActionResult Index()
        {
            return View(tasks);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TodoWebApplication.Models.Task task)
        {
            if (string.IsNullOrWhiteSpace(task.Title))
            {
                ModelState.AddModelError("Title", "Title is required.");
            }
            if (string.IsNullOrWhiteSpace(task.Description))
            {
                ModelState.AddModelError("Description", "Description is required.");
            }
            // Priority is an enum, so it will always have a value unless you want to check for a default.

            if (!ModelState.IsValid)
            {
                return View(task);
            }

            task.Id = nextId++;
            tasks.Add(task);
            return RedirectToAction("Index");
        }
        public IActionResult Complete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null) task.IsCompleted = true;
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null) tasks.Remove(task);
            return RedirectToAction("Index");
        }
    }
}
