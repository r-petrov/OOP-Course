using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Users;
using ConsoleForum.Utility;

namespace ConsoleForum.Commands
{
    class LoginCommand : AbstractCommand
    {
        public LoginCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            var users = this.Forum.Users;
            var username = this.Data[1];
            var password = PasswordUtility.Hash(this.Data[2]);

            if (this.Forum.IsLogged == true)
            {
                throw new CommandException(Messages.AlreadyLoggedIn);
            }

            bool isValidUser = users.Any(u => u.Username == username && u.Password == password);

            if (!isValidUser)
            {
                throw new CommandException(Messages.InvalidLoginDetails);
            }

            IUser user = users.FirstOrDefault(u => u.Username == username);
            this.Forum.CurrentUser = user;
            Forum.Output.AppendLine(String.Format(Messages.LoginSuccess, username));
        }
    }
}
