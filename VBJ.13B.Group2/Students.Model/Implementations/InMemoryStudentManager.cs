
namespace Students.Model
{
    public class InMemoryStudentManager : IStudentManager
    {
        // Szokásos statikus listánk
        private static List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public List<Student> ReadStudents()
        {
            return students;
        }

        public void RemoveStudent(Student student)
        {
            students.Remove(student);
        }
    }
}
