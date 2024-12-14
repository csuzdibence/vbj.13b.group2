using System.Security.Cryptography;
using System.Text;

namespace Students.Model
{
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            string hashToCompare = HashPassword(password);
            return hashToCompare == hashedPassword;
        }
    }
}
