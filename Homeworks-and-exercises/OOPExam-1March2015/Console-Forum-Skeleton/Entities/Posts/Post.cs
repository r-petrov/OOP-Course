using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleForum.Contracts;

namespace ConsoleForum
{
    public abstract class Post : IPost
    {
        private int id;
        private string body;
        private IUser author;

        protected Post(int id, string body, IUser author)
        {
            this.Id = id;
            this.Body = body;
            this.Author = author;
        }

        public int Id
        {
            get { return this.id; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("value",
                        "The id of questions should be a positive integer number starting from 1");
                }
                this.id = value;
            }
        }

        public string Body
        {
            get { return this.body; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value", "The question must have a body.");
                }
                if (value.Contains(' '))
                {
                    throw new ArgumentException("value", "No whitespace is allowed in the question body.");
                }
                this.body = value;
            }
        }

        public IUser Author { get; set; }
    }
}
