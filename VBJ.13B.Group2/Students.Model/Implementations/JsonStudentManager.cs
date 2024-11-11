
using System.Text.Json;

namespace Students.Model
{
    /// <summary>
    /// Ez egy json-be tárolós implementáció a student managernek.
    /// </summary>
    public class JsonStudentManager : IStudentManager
    {
        private const string jsonFileName = "student.json";
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
                return JsonSerializer.Deserialize<List<Student>>(json);
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
