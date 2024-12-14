using System.Security.Cryptography;
using System.Text;

namespace Students.Model
{
    public class TeacherLoginService : ILogin
    {
        private ITeacherManager teacherManager;
        private IPasswordService passwordService; 
        private readonly IHttpContextAccessor httpContextAccessor;

        public TeacherLoginService(ITeacherManager teacherManager, IPasswordService passwordService, IHttpContextAccessor httpContextAccessor)
        {
            this.teacherManager = teacherManager;
            this.passwordService = passwordService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public bool IsAuthenticated => httpContextAccessor.HttpContext.Session.GetString("email") != null;

        public bool TryLogIn(string email, string password)
        {
            var teacher = teacherManager.GetAll().FirstOrDefault(x => x.EmailAddress == email);
            if (teacher is null)
            {
                return false;
            }

            if (passwordService.VerifyPassword(password, teacher.Password))
            {
                httpContextAccessor.HttpContext.Session.SetString("email", teacher.EmailAddress);
                return true;
            }
            return false;
        }

        public void LogOut()
        {
            httpContextAccessor.HttpContext.Session.Clear();
        }
    }
}
