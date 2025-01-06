namespace Students.Model
{
    public interface IEncryptionService
    {
        string HashPassword(string password);
    }
}
