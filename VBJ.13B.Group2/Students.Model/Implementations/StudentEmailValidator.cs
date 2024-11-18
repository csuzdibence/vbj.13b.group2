namespace Students.Model.Implementations
{
    public class StudentEmailValidator : IStudentValidator
    {
        public bool ValidateStudent(Student student)
        {
            // Count metódus megmondja mennyi darab van valamiből

            if (student.EmailAddress.Count(x => x == '@') == 1)
            {
                return true;
            }
            
            return false;
        }
    }
}
