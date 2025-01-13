using Microsoft.AspNetCore.Mvc;
using Students.Model;

namespace StudentWebApp.Controllers
{
    /// <summary>
    /// Controller a tanulókhoz kapcsolódó végpontokhoz
    /// </summary>
    public class StudentController : Controller
    {
        IStudentManager studentManager;
        IStudentValidator studentValidator;
        IAuthenticationService authenticationService;
        ITeacherManager teacherManager;

        // Konstruktor injection
        // StudentController függ a StudentManagertől
        public StudentController(IStudentManager studentManager, IStudentValidator studentValidator, IAuthenticationService authenticationService, ITeacherManager teacherManager)
        {
            this.studentManager = studentManager;
            this.studentValidator = studentValidator;
            this.authenticationService = authenticationService;
            this.teacherManager = teacherManager;
        }

        // Root végpont -> /Student
        public IActionResult Index()
        {
            if (!authenticationService.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            Teacher teacher = teacherManager.GetAll().FirstOrDefault(x => x.EmailAddress == authenticationService.EmailAddress);
            return View(teacher.Students.ToList());
        }

        // /Student/Register nézet
        public IActionResult Register()
        {
            if (!authenticationService.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // RegisterStudent action -> beszúrunk a listába egy új studentet amit a formról kaptunk
        public IActionResult RegisterStudent(Student student)
        {
            // Get teacher by email address from SQL Database
            Teacher teacher = teacherManager.GetAll().FirstOrDefault(x => x.EmailAddress == authenticationService.EmailAddress);

            var students = studentManager.ReadStudents();
            student.Id = students.Any() ? students.Last().Id + 1 : 1;
            // FK <- PK
            student.TeacherId = teacher.Id;
            student.Password = Guid.NewGuid().ToString();
            student.IsValid = studentValidator.ValidateStudent(student);
            student.DateOfRegistry = DateTime.Now;
            studentManager.AddStudent(student);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var students = studentManager.ReadStudents();
            Student foundStudent = students.FirstOrDefault(x => x.Id == id);
            if (foundStudent != null)
            {
                studentManager.RemoveStudent(foundStudent);
            }
            return RedirectToAction("Index");
        }
    }
}
