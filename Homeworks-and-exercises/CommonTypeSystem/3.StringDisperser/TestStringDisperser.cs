using System.Linq;

namespace _3.StringDisperser
{
    using System;

    public class TestStringDisperser
    {
        public static void Main(string[] args)
        {
            StringDisperser stringDisperser = new StringDisperser("gosho", "pesho", "tanio");
            StringDisperser anotherStringDisperser = new StringDisperser("pesho", "gosho", "tanio");

            Console.WriteLine(stringDisperser == anotherStringDisperser);
            Console.WriteLine(stringDisperser.Equals(anotherStringDisperser));
            foreach (var ch in stringDisperser)
            {
                Console.Write(ch + " ");
            }

            ChangeStringDisperser(stringDisperser);
            Console.WriteLine();
            Console.WriteLine(stringDisperser);
        }

        private static void ChangeStringDisperser(StringDisperser stringDisperser)
        {
            stringDisperser.AddString("kurti");
        }
    }
}
