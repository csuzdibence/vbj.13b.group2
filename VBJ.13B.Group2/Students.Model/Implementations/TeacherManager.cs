using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Model.Implementations
{
    public class TeacherManager : ITeacherManager
    {
        private StudentDbContext dbContext;
        private IPasswordService passwordService;

        public TeacherManager(StudentDbContext dbContext, IPasswordService passwordService)
        {
            this.dbContext = dbContext;
            this.passwordService = passwordService;
        }

        public void Add(Teacher teacher)
        {
            teacher.Password = passwordService.HashPassword(teacher.Password);
            dbContext.Teachers.Add(teacher);
            dbContext.SaveChanges();
        }

        public IQueryable<Teacher> GetAll()
        {
            return dbContext.Teachers.AsQueryable();
        }
    }
}
