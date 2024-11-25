namespace Students.Model.Implementations
{
    internal class RecentRegistryValidator : IStudentValidator
    {
        public bool ValidateStudent(Student student)
        {
            return student.DateOfRegistry.AddYears(1) >= DateTime.Now;
            //return DateTime.Now.Subtract(TimeSpan.FromDays(365)) >= student.DateOfRegistry;
        }
    }
}
