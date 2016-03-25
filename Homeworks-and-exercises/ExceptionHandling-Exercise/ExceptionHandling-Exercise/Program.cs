using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Person firstPerson = new Person("Petar", "Petrov", 29);

            try
            {
                //Person secondPerson = new Person(String.Empty, "Ivanov", 30);
                Person thirdPerson = new Person("Teodora", null, 30);
            }
            catch (ArgumentNullException ex)
            {
                Console.Error.WriteLine("Exception thrown: {0}", ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.Error.WriteLine("Exception thrown: {0}", ex.Message);
            }

            try
            {
                //Person fourthPerson = new Person("Stela", "Petrova", -30);
                Person fifthPerson = new Person("Gergana", "Ivanova", 130);
            }
            catch (ArgumentNullException ex)
            {
                Console.Error.WriteLine("Exception thrown: {0}", ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.Error.WriteLine("Exception thrown: {0}", ex.Message);
            }
        }
    }
}
