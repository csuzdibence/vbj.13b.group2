namespace Students.Model
{
    public interface IAuthenticationService
    {
        // Kijelentkezés
        void LogOut();

        // Bejelentkezés
        bool TryLogIn(string email, string password);

        bool IsAuthenticated { get; }

        string EmailAddress { get; }
    }
}
