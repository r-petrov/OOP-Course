using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;

namespace ConsoleForum.Commands
{
    class ShowQuestionsCommand : AbstractCommand
    {
        public ShowQuestionsCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            if (this.Forum.Questions.Count == 0)
            {
                throw new CommandException(Messages.NoQuestions);
            }

            if (this.Forum.CurrentQuestion != null)
            {
                this.Forum.CurrentQuestion = null;
            }

            this.Forum.Output.AppendLine(String.Join("\n", this.Forum.Questions.OrderBy(q => q.Id)));
        }
    }
}
