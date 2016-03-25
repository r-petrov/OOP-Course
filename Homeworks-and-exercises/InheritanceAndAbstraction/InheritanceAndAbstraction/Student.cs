using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace InheritanceAndAbstraction
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "Faculty number cannot be null or empty!");
                }

                string facultyNumberPattern = @"[0-9A-Za-z]{5,10}";
                if (!Regex.IsMatch(value, facultyNumberPattern) || value.Length > 10)
                {
                    throw new ArgumentException("value", "Faculty number may only consist of 5-10 digits / letters");
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            string result = String.Format("Student's first name: {0}\nStudent's last name: {1}\nStudent's faculty number: {2}\n",
                this.FirstName, this.LastName, this.FacultyNumber);
            return result;
        }

    }
}
