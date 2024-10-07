using Microsoft.AspNetCore.Mvc;
using VBJ._13B.Group2.WebApp.Models;

namespace VBJ._13B.Group2.WebApp.Controllers
{
    public class ToDoController : Controller
    {
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

        public IActionResult Index()
        {
            return View(toDoItems);
        }
    }
}
