namespace ConsoleForum.Entities.Users
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    public class User : IUser
    {
        private int id;
        private string username;
        private string password;
        private string email;
        public User(int id, string name, string password, string email)
        {
            this.Id = id;
            this.Username = name;
            this.Password = password;
            this.Email = email;
            this.Questions = new List<IQuestion>();
        }

        public int Id
        {
            get { return this.id; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("value", "The id of new registered users should be bigger than 0");
                }
                this.id = value;
            }
        }

        public string Username
        {
            get { return this.username; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value", "You should enter an username.");
                }
                if (value.Contains(" "))
                {
                    throw new ArgumentException("value", "No whitespace is allowed in the username.");
                }
                this.username = value;
            }
        }

        public string Password
        {
            get { return this.password; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value", "You should enter a password.");
                }
                if (value.Contains(" "))
                {
                    throw new ArgumentException("value", "No whitespace is allowed in the password.");
                }
                this.password = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value", "You should enter an email adress.");
                }
                if (value.Contains(" "))
                {
                    throw new ArgumentException("value", "No whitespace is allowed in the email.");
                }
                this.email = value;
            }
        }

        public IList<IQuestion> Questions { get; private set; }
    }
}
