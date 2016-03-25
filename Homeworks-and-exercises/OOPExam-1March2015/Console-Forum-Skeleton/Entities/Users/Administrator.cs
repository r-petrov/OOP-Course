using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Users;

namespace ConsoleForum
{
    public class Administrator : User, IAdministrator
    {
        public Administrator(int id, string name, string password, string email)
            : base(id, name, password, email)
        {
        }
    }
}
