using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;

namespace ConsoleForum.Commands
{
    class OpenQuestionCommand : AbstractCommand
    {
        public OpenQuestionCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            int questionId = int.Parse(this.Data[1]);

            if (this.Forum.Questions.All(q => q.Id != questionId))
            {
                throw new CommandException(Messages.NoQuestion);
            }

            var question = this.Forum.Questions.FirstOrDefault(q => q.Id == questionId);
            this.Forum.CurrentQuestion = question;
            this.Forum.Output.AppendLine(String.Format(this.Forum.CurrentQuestion.ToString()));
        }
    }
}
