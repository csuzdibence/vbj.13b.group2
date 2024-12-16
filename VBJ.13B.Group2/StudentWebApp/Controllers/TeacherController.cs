using Microsoft.AspNetCore.Mvc;
using Students.Model;

namespace StudentWebApp.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        // Form beküldésea weboldalról
        public IActionResult RegisterTeacher(Teacher teacher)
        {
            return RedirectToAction("Index");
        }
    }
}
