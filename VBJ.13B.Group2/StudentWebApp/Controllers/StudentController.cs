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

        // Konstruktor injection
        // StudentController függ a StudentManagertől
        public StudentController(IStudentManager studentManager)
        {
            this.studentManager = studentManager;
        }

        // Root végpont -> /Student
        public IActionResult Index()
        {
            return View(studentManager.ReadStudents());
        }

        // /Student/Register nézet
        public IActionResult Register()
        {
            return View();
        }

        // RegisterStudent action -> beszúrunk a listába egy új studentet amit a formról kaptunk
        public IActionResult RegisterStudent(Student student)
        {
            var students = studentManager.ReadStudents();
            student.Id = students.Any() ? students.Last().Id + 1 : 1;
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
