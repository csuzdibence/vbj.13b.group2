using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Model
{
    public interface ILogin
    {
        public bool IsAuthenticated { get; }

        void LogOut();
        public bool TryLogIn(string email, string password);
    }
}
