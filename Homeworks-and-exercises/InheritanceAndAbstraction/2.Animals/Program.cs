using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Animal[] animals =
                {
                    new Dog("Ben", 4, Gender.Male),
                    new Dog("Lara", 3.5, Gender.Female),
                    new Frog("Bojko", 1, Gender.Male),
                    new Frog("Ivanichka", 1, Gender.Female),
                    new Kitten("Mara", 7, Gender.Female),
                    new Kitten("Poly", 2.8, Gender.Female),
                    new Tomcat("Chonko", 4.5, Gender.Male),
                };

                foreach (var animal in animals)
                {
                    Console.WriteLine(animal.ToString());
                }

                var averageAge = animals.Average(animal => animal.Age);
                Console.WriteLine("Average age of all animals is: {0} years", averageAge);
            }
            catch (ArgumentNullException ne)
            {
                Console.Error.WriteLine(ne.ParamName, ne.Message);
            }
            catch (ArgumentOutOfRangeException aorex)
            {
                Console.WriteLine(aorex.ParamName, aorex.Message);
            }
        }
    }
}
