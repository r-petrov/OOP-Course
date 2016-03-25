using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndAbstraction_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Pod Igoto", "Ivan Vazov", 15.90m);
            Console.WriteLine(book);
            GoldenEditionBook book2 = new GoldenEditionBook("Tutun", "Dimitar Dimov", 22.9m);
            Console.WriteLine(book2);
        }
    }
}
