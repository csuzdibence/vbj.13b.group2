using System.Security.Cryptography;
using System.Text;

namespace Students.Model
{
    public class SHA256EncryptionService : IEncryptionService
    {
        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordInBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashedBytes = sha256.ComputeHash(passwordInBytes);
                string hashedPassword = Convert.ToBase64String(hashedBytes);
                return hashedPassword;
            }
        }
    }
}
