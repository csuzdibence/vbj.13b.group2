using System.Reflection.Metadata;

namespace Students.Model
{
    /// <summary>
    /// Ez az osztály egy tanulót reprezentál.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Ez a property a tanuló azonosítóját állítja
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ez a property a tanuló keresztnevét állítja
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Ez a property a tanuló vezetéknevét állítja
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Ez a property a regisztráció dátumát adja meg.
        /// </summary>
        public DateTime DateOfRegistry { get; set; }

        /// <summary>
        /// Ez a property az email címet adja meg
        /// </summary>
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public bool IsValid { get; set; }

        /// <summary>
        /// FK Id
        /// </summary>
        public int TeacherId { get; set; }

        /// <summary>
        /// Navigation property
        /// </summary>
        public Teacher Teacher { get; set; } = null!;
    }
}
