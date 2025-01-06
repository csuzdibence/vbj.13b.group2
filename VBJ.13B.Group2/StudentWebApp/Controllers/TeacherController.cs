using Microsoft.AspNetCore.Mvc;
using Students.Model;

namespace StudentWebApp.Controllers
{
    public class TeacherController : Controller
    {
        private ITeacherManager teacherManager;
        private IEncryptionService encryptionService;

        public TeacherController(ITeacherManager teacherManager, IEncryptionService encryptionService)
        {
            this.teacherManager = teacherManager;
            this.encryptionService = encryptionService;
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
    }
}
