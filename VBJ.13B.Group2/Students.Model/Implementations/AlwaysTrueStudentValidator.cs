namespace Students.Model.Implementations
{
    public class AlwaysTrueStudentValidator : IStudentValidator
    {
        public bool ValidateStudent(Student student)
        {
            return true;
        }
    }
}
