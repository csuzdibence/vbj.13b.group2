namespace Students.Model.Implementations
{
    public class NameLengthValidator : IStudentValidator
    {
        public bool ValidateStudent(Student student)
        {
            //if (student.FirstName.Length >= 3 && student.LastName.Length >= 3)
            //{
            //    return true;
            //}
            //else 
            //{
            //    return false;
            //}

            return student.FirstName.Length >= 3 && student.LastName.Length >= 3;
        }
    }
}
