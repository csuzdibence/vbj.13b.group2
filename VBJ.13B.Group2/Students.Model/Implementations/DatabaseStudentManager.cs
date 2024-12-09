
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
            student.Id = 0;
            dbContext.Students.Add(student);
            dbContext.SaveChanges();
        }

        public List<Student> ReadStudents()
        {

            // var query = dbContext.Students.AsQueryable();
            // SELECT * FROM Students WHERE EmailAddress == "kissbela@gmail.com" -> 1
            // query.Where(x => x.EmailAddress == "kissbela@gmail.com").ToList();

            // SELECT * FROM Students -> 1.000.000
            return dbContext.Students.ToList();
        }

        public void RemoveStudent(Student student)
        {
            dbContext.Students.Remove(student);
            dbContext.SaveChanges();
        }
    }
}
