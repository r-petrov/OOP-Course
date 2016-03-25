using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleForum.Contracts;

namespace ConsoleForum
{
    public class Question : Post, IQuestion
    {
        private const int DelimetersNumber = 20;

        private string title;

        public Question(int id, string body, IUser author, string title)
            : base(id, body, author)
        {
            this.Title = title;
            this.Answers = new List<IAnswer>();
        }

        public string Title
        {
            get { return this.title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value", "The question must have a title.");
                }
                if (value.Contains(" "))
                {
                    throw new ArgumentException("value", "No whitespace is allowed in the title.");
                }
                this.title = value;
            }
        }

        public IList<IAnswer> Answers { get; private set; }

        //public bool IsOpened { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(String.Format("[ Question ID: {0} ]", this.Id));
            output.AppendLine(String.Format("Posted by: {0}", this.Author.Username));
            output.AppendLine(String.Format("Question Title: {0}", this.Title));
            output.AppendLine(String.Format("Question Body: {0}", this.Body));
            output.AppendLine(String.Format("{0}", new string('=', DelimetersNumber)));

            if(this.Answers.Count > 0)
            {
                output.Append(String.Format("Anwers:\n{0}{1}",
                    this.Answers.Any(a => a is BestAnswer) ? this.Answers.FirstOrDefault(a => a is BestAnswer) + "\n" : null,
                    string.Join("\n", this.Answers)));
            }
            else
            {
                output.Append("No answers");
            }

            return output.ToString();
        }
    }
}
