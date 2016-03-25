using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Delegates_and_Events_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> collection = new List<int>() {1, 2, 3, 4, 6, 11, 3};
            Console.WriteLine(collection.FirstOrDef(el => el > 7));
            Console.WriteLine(collection.FirstOrDef(el => el < 0));
            Console.WriteLine(String.Join(", ", collection.TakeWhile(x => x < 10)));
            collection.ForEach(Console.WriteLine);
        }
    }
}
