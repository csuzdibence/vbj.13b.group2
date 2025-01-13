
using Microsoft.EntityFrameworkCore;

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
            return dbContext.Teachers.Include(x => x.Students).AsQueryable();
        }
    }
}
