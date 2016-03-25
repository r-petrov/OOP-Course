using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleForum.Contracts;

namespace ConsoleForum
{
    public class BestAnswer : Answer
    {
        private const int DelimetersNumber = 20;
        public BestAnswer(int id, string body, IUser author) : base(id, body, author)
        {
          //  this.IsBestAnswer = true;
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(String.Format("{0}", new string('*', DelimetersNumber)));
            output.AppendLine(base.ToString());
            output.AppendLine(String.Format("{0}", new string('*', DelimetersNumber)));
            return output.ToString();
        }
    }
}
