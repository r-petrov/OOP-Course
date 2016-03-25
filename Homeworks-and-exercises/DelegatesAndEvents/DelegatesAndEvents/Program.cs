﻿using System;
using System.Collections.Generic;

namespace DelegatesAndEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var filteredCollection = nums.WhereNot(n => n%2 == 0);

            Console.WriteLine(string.Join(", ", filteredCollection));

            var students = new List<Student>()
            {
                new Student("Pesho", 3),
                new Student("Gosho", 2),
                new Student("Mariika", 7),
                new Student("Stamat", 10),
            };

            Console.WriteLine(students.Max(student => student.Grade));
        }
    }
}
