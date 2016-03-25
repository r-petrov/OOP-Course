using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> list = new CustomList<int>();
            list.Add(15);
            list.Add(26);
            list.Add(13);
            list.Add(33);
            list.Add(8);
            list.Add(7);
            list.Add(41);
            list.Add(35);
            list.Add(9);

            Console.WriteLine(list);
            Console.WriteLine(list.IndexOf(13));
            Console.WriteLine(list.IndexOf(35));
            Console.WriteLine(list.IndexOf(66));

            list.Remove(26);

            Console.WriteLine(list);
            Console.WriteLine(list.Min());
            Console.WriteLine(list.Max());
            Console.WriteLine(list[3]);
        }
    }
}
