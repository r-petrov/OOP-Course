using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;

namespace ConsoleForum.Commands
{
    class PostQuestionCommand : AbstractCommand
    {
        public PostQuestionCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            if (this.Forum.IsLogged == false)
            {
                throw new CommandException(Messages.NotLogged);
            }

            string title = this.Data[1];
            string body = this.Data[2];

            var question = new Question(this.Forum.Questions.Count + 1, body, this.Forum.CurrentUser, title);
            this.Forum.Questions.Add(question);

            this.Forum.Output.AppendLine(String.Format(Messages.PostQuestionSuccess, question.Id));
        }
    }
}
