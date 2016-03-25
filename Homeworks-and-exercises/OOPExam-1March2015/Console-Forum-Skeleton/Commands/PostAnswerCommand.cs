using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;

namespace ConsoleForum.Commands
{
    class PostAnswerCommand : AbstractCommand
    {
        public PostAnswerCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            if (this.Forum.IsLogged == false)
            {
                throw new CommandException(Messages.NotLogged);
            }

            if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            string body = this.Data[1];

            var answer = new Answer(this.Forum.CurrentQuestion.Answers.Count + 1, body, this.Forum.CurrentUser);
            this.Forum.CurrentQuestion.Answers.Add(answer);

            this.Forum.Output.AppendLine(String.Format(Messages.PostAnswerSuccess, answer.Id));
        }
    }
}
