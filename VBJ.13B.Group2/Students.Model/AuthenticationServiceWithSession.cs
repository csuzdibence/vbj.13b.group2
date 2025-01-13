using Microsoft.AspNetCore.Http;
using System.Text;

namespace Students.Model
{
    public class AuthenticationServiceWithSession : IAuthenticationService
    {
        private IHttpContextAccessor httpContextAccessor;
        private ITeacherManager teacherManager;
        private IEncryptionService encryptionService;

        public AuthenticationServiceWithSession(IHttpContextAccessor httpContextAccessor, ITeacherManager teacherManager, IEncryptionService encryptionService)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.teacherManager = teacherManager;
            this.encryptionService = encryptionService;
        }

        // Van-e a sessionben bejegyzés az emailre
        public bool IsAuthenticated => 
            httpContextAccessor.HttpContext.Session.TryGetValue("email", out byte[] values);

        public string EmailAddress
        {
            get 
            {
                httpContextAccessor.HttpContext.Session.TryGetValue("email", out byte[] values);

                if (values is null)
                {
                    return string.Empty;
                }

                return Encoding.UTF8.GetString(values);
            }
        }

        public void LogOut()
        {
            // Töröljük a session tartalmát
            httpContextAccessor.HttpContext.Session.Clear();
        }

        public bool TryLogIn(string email, string password)
        {
            Teacher? foundTeacher = teacherManager.GetAll()
                .FirstOrDefault(teacher => teacher.EmailAddress == email);

            if (foundTeacher is null) // Ha nincs az email az adatbázisban
            {
                return false;
            }

            string hashedPassword = encryptionService.HashPassword(password);
            if (foundTeacher.Password != hashedPassword) // Nem jó jelszót adott meg
            {
                return false;
            }

            // Sikerült, letároljuk a sessionbe
            httpContextAccessor.HttpContext.Session.Set("email", Encoding.UTF8.GetBytes(email));

            return true;
        }
    }
}
