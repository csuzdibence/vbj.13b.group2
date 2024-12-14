using Microsoft.AspNetCore.Mvc;
using Students.Model;

namespace StudentWebApp.Controllers
{
    public class TeacherController : Controller
    {
        private ITeacherManager teacherManager;
        private ILogin loginService;

        public TeacherController(ITeacherManager teacherManager, ILogin loginService)
        {
            this.teacherManager = teacherManager;
            this.loginService = loginService;
        }

        public IActionResult Index()
        {
            return View(teacherManager.GetAll().ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            loginService.LogOut();
            return RedirectToAction("Login");
        }

        public IActionResult LoginTeacher(string email, string password)
        {
            if (loginService.TryLogIn(email, password))
            {
                return View("Index", teacherManager.GetAll().ToList());
            }
            return View("Login", "Authentication failed");
        }

        public IActionResult RegisterTeacher(Teacher teacher)
        {
            teacherManager.Add(teacher);
            return RedirectToAction("Index");
        }
    }
}
