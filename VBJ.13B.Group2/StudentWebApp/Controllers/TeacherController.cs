using Microsoft.AspNetCore.Mvc;
using Students.Model;

namespace StudentWebApp.Controllers
{
    public class TeacherController : Controller
    {
        private ITeacherManager teacherManager;
        private IEncryptionService encryptionService;
        private IAuthenticationService authenticationService;

        public TeacherController(ITeacherManager teacherManager, IEncryptionService encryptionService, IAuthenticationService authenticationService)
        {
            this.teacherManager = teacherManager;
            this.encryptionService = encryptionService;
            this.authenticationService = authenticationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterTeachers()
        {
            return View();
        }

        // http://url/Teacher/Login -> API URL
        public IActionResult TeacherLogin()
        {
            return View();
        }

        // Form beküldésea weboldalról
        public IActionResult RegisterTeacher(Teacher teacher)
        {
            teacher.Password = encryptionService.HashPassword(teacher.Password);
            teacherManager.Add(teacher);
            return RedirectToAction("Index");
        }

        public IActionResult Login(string email, string password)
        {
            if (authenticationService.TryLogIn(email, password))
            {
                // Sikerült a bejelentkezés
                return RedirectToAction("Index");
            }

            // Nem sikerült a bejelentkezés
            return RedirectToAction("TeacherLogin");
        }
    }
}
