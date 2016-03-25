using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Persons
{
    class PersonProgram
    {
        static void Main(string[] args)
        {
            Person peter = new Person("Peter", 26, "peter@yahoo.com");
            Console.WriteLine(peter);

            Person ivan = new Person("Ivan", 25);
            Console.WriteLine(ivan);

            Person yordan = new Person("Yordan", 25, "afadf");
            Console.WriteLine(yordan);
        }
    }
}
