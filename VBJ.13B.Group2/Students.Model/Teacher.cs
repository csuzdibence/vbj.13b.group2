namespace Students.Model
{
    public class Teacher
    {
        // Elsődleges kulcs
        public int Id { get; set; }

        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        // Egy tanárhoz több diák tartozhat
        // Navigációs tulajdonság
        public ICollection<Student> Students { get; }
    }
}
