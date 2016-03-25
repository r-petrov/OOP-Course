using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleForum.Contracts;

namespace ConsoleForum
{
    public class Answer : Post, IAnswer
    {
        private const int DelimetersNumber = 20;
        public Answer(int id, string body, IUser author)
            : base(id, body, author)
        {
       //     this.IsBestAnswer = false;
        }

        //public bool IsBestAnswer { get; protected set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(String.Format("[ Answer ID: {0} ]", this.Id));
            output.AppendLine(String.Format("Posted by: {0}", this.Author.Username));
            output.AppendLine(String.Format("Answer Body: {0}", this.Body));
            output.Append(String.Format("{0}", new string('-', DelimetersNumber)));
            return output.ToString();
        }
    }
}
