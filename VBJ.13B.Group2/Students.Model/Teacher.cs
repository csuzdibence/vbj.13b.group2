using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Model
{
    public class Teacher
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Navigation property
        /// </summary>
        public ICollection<Student> Students { get; } = new List<Student>();
    }
}
