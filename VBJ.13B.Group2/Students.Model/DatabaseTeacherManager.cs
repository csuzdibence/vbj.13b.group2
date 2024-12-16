
namespace Students.Model
{
    public class DatabaseTeacherManager : ITeacherManager
    {
        private StudentDbContext dbContext;

        public DatabaseTeacherManager(StudentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Teacher teacher)
        {
            dbContext.Teachers.Add(teacher);
            dbContext.SaveChanges();
        }

        public IQueryable<Teacher> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
