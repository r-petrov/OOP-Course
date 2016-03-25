using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Users;

namespace ConsoleForum.Commands
{
    class MakeBestAnswerCommand : AbstractCommand
    {
        public MakeBestAnswerCommand(IForum forum) : base(forum)
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

            int answerId = int.Parse(this.Data[1]);

            if (this.Forum.Answers.Any(a => a.Id != answerId))
            {
                throw new CommandException(Messages.NoAnswer);
            }

            if (this.Forum.CurrentUser.Id != this.Forum.CurrentQuestion.Author.Id &&
                !(this.Forum.CurrentUser is Administrator))
            {
                throw new CommandException(Messages.NoPermission);
            }

            if (this.Forum.Answers.Any(a => a is BestAnswer))
            {
                throw new CommandException("A question can have only one best answer.");
            }

            var answer = this.Forum.Answers.FirstOrDefault(a => a.Id == answerId);
            BestAnswer bestAnswer = answer as BestAnswer;
            this.Forum.CurrentQuestion.Answers.Add(bestAnswer);
            this.Forum.Output.AppendLine(String.Format(Messages.BestAnswerSuccess, answerId));
        }
    }
}
