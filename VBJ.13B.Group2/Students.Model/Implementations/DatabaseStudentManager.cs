
namespace Students.Model.Implementations
{
    public class DatabaseStudentManager : IStudentManager
    {
        private StudentDbContext dbContext;

        // Dependency / Konstruktor Injection
        public DatabaseStudentManager(StudentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public List<Student> ReadStudents()
        {
            throw new NotImplementedException();
        }

        public void RemoveStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
