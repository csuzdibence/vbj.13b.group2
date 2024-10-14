using Microsoft.AspNetCore.Mvc;
using VBJ._13B.Group2.WebApp.Models;

namespace VBJ._13B.Group2.WebApp.Controllers
{
    public class ToDoController : Controller
    {
        // in memory "adatbázis"
        private static List<ToDoItem> toDoItems = new List<ToDoItem>();

        public ToDoController()
        {
            // ha még nincs benne elem
            if (!toDoItems.Any())
            {
                ToDoItem toDoItem = new ToDoItem()
                {
                    Id = 1,
                    Title = "Mosás",
                    HasCompleted = true
                };
                // rakok bele kamuelemeket
                toDoItems.Add(toDoItem);

                toDoItems.Add(new ToDoItem()
                {
                    Id = 2,
                    Title = "Főzés",
                    HasCompleted = false
                });                
            }
        }

        // /ToDo
        public IActionResult Index()
        {
            return View(toDoItems);
        }

        // /ToDo/Create
        public IActionResult Create()
        {
            return View();
        }

        // /ToDo/Edit
        public IActionResult Edit(int id)
        {
            ToDoItem foundItem = toDoItems.FirstOrDefault(x => x.Id == id);
            if (foundItem is null)
            {
                // nem találtuk meg az elemet
                return RedirectToAction("Index");
            }
            return View(foundItem);
        }

        public IActionResult AddToDo(ToDoItem createdItem)
        {
            // Ternary - (condition/feltétel) ? érték ha igaz : érték ha nem igaz
            createdItem.Id = toDoItems.Any() ? toDoItems.Last().Id + 1 : 1;
            toDoItems.Add(createdItem);
            return RedirectToAction("Index");
        }

        public IActionResult EditToDo(ToDoItem editedItem)
        {
            // Keressük meg az elemet Id alapján
            ToDoItem foundItem = toDoItems.FirstOrDefault(x => x.Id == editedItem.Id);
            if (foundItem != null)
            {
                // Ha nem null, akkor megtaláltuk az elemet
                foundItem.Title = editedItem.Title;
                foundItem.HasCompleted = editedItem.HasCompleted;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            ToDoItem? foundItem = toDoItems.FirstOrDefault(x => x.Id == id);
            if (foundItem != null)
            {
                // ha megtaláltuk az elemet
                toDoItems.Remove(foundItem);
            }
            // ha nem találtuk megaz elemet
            return RedirectToAction("Index");
        }
    }
}
