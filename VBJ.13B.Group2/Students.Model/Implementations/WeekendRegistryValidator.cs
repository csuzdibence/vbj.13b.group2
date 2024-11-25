namespace Students.Model.Implementations
{
    public class WeekendRegistryValidator : IStudentValidator
    {
        public bool ValidateStudent(Student student)
        {
            return student.DateOfRegistry.DayOfWeek == DayOfWeek.Saturday ||
                student.DateOfRegistry.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}
