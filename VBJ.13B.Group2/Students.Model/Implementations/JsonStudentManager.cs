
using System.Text.Json;

namespace Students.Model
{
    /// <summary>
    /// Ez egy json-be tárolós implementáció a student managernek.
    /// </summary>
    public class JsonStudentManager : IStudentManager
    {
        private const string jsonFileName = "student.json";

        IStudentValidator studentValidator;

        public JsonStudentManager(IStudentValidator studentValidator)
        {
            this.studentValidator = studentValidator;
        }

        public void AddStudent(Student student)
        {
            var students = ReadStudents();
            students.Add(student);
            var jsonString = JsonSerializer.Serialize<List<Student>>(students);
            File.WriteAllText(jsonFileName, jsonString);
        }

        public List<Student> ReadStudents()
        {
            try
            {
                var json = File.ReadAllText(jsonFileName);
                var students = JsonSerializer.Deserialize<List<Student>>(json);
                foreach (var student in students)
                {
                    student.IsValid = studentValidator.ValidateStudent(student);
                }
                return students;
            }
            catch (Exception)
            {
                return new List<Student>();
            }
        }

        public void RemoveStudent(Student student)
        {
            var students = ReadStudents();
            students.Remove(student);
            var jsonString = JsonSerializer.Serialize<List<Student>>(students);
            File.WriteAllText(jsonFileName, jsonString);
        }
    }
}
