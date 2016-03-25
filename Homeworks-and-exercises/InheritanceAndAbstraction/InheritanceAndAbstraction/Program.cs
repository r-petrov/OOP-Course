using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InheritanceAndAbstraction;

namespace HumanStudentAndWorker
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Student> students = new List<Student>();
            //for (int i = 0; i < 10; i++)
            //{
            //    bool isStudentIncorrect = true;
            //    while (isStudentIncorrect)
            //    {
            //        try
            //        {
            //            Student student = new Student(Console.ReadLine(), Console.ReadLine(), Console.ReadLine());
            //            students.Add(student);
            //            isStudentIncorrect = false;
            //        }
            //        catch (ArgumentNullException)
            //        {
            //            Console.Error.WriteLine("Student's first name, last name and faculty number are mandatory");
            //        }
            //        catch (ArgumentException aex)
            //        {
            //            Console.Error.WriteLine("{0}", aex.Message);
            //        }
            //    }
            //}

           
            //List<Worker> workers = new List<Worker>();
            //for (int i = 0; i < 10; i++)
            //{
            //    bool isWorkerIncorrect = true;
            //    while (isWorkerIncorrect)
            //    {
            //        try
            //        {
            //            Worker worker = new Worker(Console.ReadLine(), Console.ReadLine(), 
            //                decimal.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            //            workers.Add(worker);
            //            isWorkerIncorrect = false;
            //        }
            //        catch (ArgumentNullException)
            //        {
            //            Console.Error.WriteLine("Worker's first name and last name are mandatory");
            //        }
            //        catch (ArgumentOutOfRangeException)
            //        {
            //            Console.Error.WriteLine("Week salary and work hours per day cannot have negative values");
            //        }
            //    }
            //}

            //create and sort the students
            try
            {
                List<Student> students = new List<Student>()
                {
                   new Student( "Pesho", "Peshev", "123456asdf"),
                   new Student( "Ivaila", "Ivanova", "546786asdf"),
                   new Student( "Emilia", "Todorova", "088546asdf"),
                   new Student( "Angelina", "Ivanova", "456987asdv"),
                   new Student( "Teodor", "Timonov", "456789ascb"),
                   new Student( "Virgil", "Malushev", "455468asfc"),
                   new Student( "Angel", "Tomov", "321564zxcv"),
                   new Student( "Krum", "Asparuhov", "123456asdf"),
                   new Student( "Boyan", "Simeonov", "123456zxas"),
                   new Student( "Ognyan", "Iskrov", "123456lore"),
                };

                var sortedStudents = students.OrderBy(student => student.FacultyNumber);
                foreach (var student in sortedStudents)
                {
                    Console.WriteLine(student.ToString());
                }
            }
            catch (ArgumentNullException)
            {
                Console.Error.WriteLine("Student's first name, last name and faculty number are mandatory");
            }
            catch (ArgumentException aex)
            {
                Console.Error.WriteLine("{0}", aex.Message);
            }

            //create and sort the workers
            try
            {
                List<Worker> workers = new List<Worker>()
                {
                    new Worker("Raya", "Petrova", 250m, 8),
                    new Worker("Beloslava", "Licheva", 225.8m, 8),
                    new Worker("Petar", "Ivanov", 321m, 9),
                    new Worker("Belin", "Trifonov", 225m, 8),
                    new Worker("Rosica", "Belova", 221.25m, 8),
                    new Worker("Elmir", "Nenkov", 215m, 7),
                    new Worker("Raya", "Dimitrova", 255m, 9),
                    new Worker("Polina", "Filova", 250m, 9),
                    new Worker("Apostol", "Krumov", 250m, 7),
                    new Worker("Boyan", "Simeonov", 250m, 6),
                };

                var sortedWorkers =
                    from worker in workers
                    orderby worker.MoneyPerHour() descending
                    select worker;

                Console.WriteLine();
                foreach (var worker in sortedWorkers)
                {
                    Console.WriteLine(worker.ToString());
                }
            }
            catch (ArgumentNullException)
            {
                Console.Error.WriteLine("Worker's first name and last name are mandatory");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.Error.WriteLine("Week salary and work hours per day cannot have negative values");
            }

            List<Human> people = new List<Human>()
            {
                new Student( "Pesho", "Peshev", "123456asdf"),
                   new Student( "Ivaila", "Ivanova", "546786asdf"),
                   new Student( "Emilia", "Todorova", "088546asdf"),
                   new Student( "Angelina", "Ivanova", "456987asdv"),
                   new Student( "Teodor", "Timonov", "456789ascb"),
                   new Student( "Virgil", "Malushev", "455468asfc"),
                   new Student( "Angel", "Tomov", "321564zxcv"),
                   new Student( "Krum", "Asparuhov", "123456asdf"),
                   new Student( "Boyan", "Simeonov", "123456zxas"),
                   new Student( "Ognyan", "Iskrov", "123456lore"),
                   new Worker("Raya", "Petrova", 250m, 8),
                    new Worker("Beloslava", "Licheva", 225.8m, 8),
                    new Worker("Petar", "Ivanov", 321m, 9),
                    new Worker("Belin", "Trifonov", 225m, 8),
                    new Worker("Rosica", "Belova", 221.25m, 8),
                    new Worker("Elmir", "Nenkov", 215m, 7),
                    new Worker("Raya", "Dimitrova", 255m, 9),
                    new Worker("Polina", "Filova", 250m, 9),
                    new Worker("Apostol", "Krumov", 250m, 7),
                    new Worker("Boyan", "Simeonov", 250m, 6),
            };

            var sortedPeople = people.OrderBy(human => human.FirstName).ThenBy(human => human.LastName);
            foreach (var human in sortedPeople)
            {
                Console.WriteLine(human.ToString());
            }
        }
    }
}
