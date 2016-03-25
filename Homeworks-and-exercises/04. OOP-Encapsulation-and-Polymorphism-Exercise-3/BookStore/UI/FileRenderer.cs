using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Interfaces;

namespace BookStore.UI
{
    public class FileRenderer : IRenderer
    {
        public void WriteLine(string message, params object[] parameters)
        {
            using (var writer = File.AppendText(@"../../output.txt"))
            {
                writer.Write(message, parameters);
            }
        }
    }
}
