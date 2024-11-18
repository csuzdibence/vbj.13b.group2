using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Model
{
    public interface IStudentValidator
    {
        bool ValidateStudent(Student student);
    }
}
