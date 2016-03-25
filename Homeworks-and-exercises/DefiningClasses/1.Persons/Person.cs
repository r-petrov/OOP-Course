using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1.Persons
{
    class Person
    {
        private string name;
        private int age;
        private string email;

        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        public Person(string name, int age) : this(name, age, null)
        {
        }

        public string Name
        {
            get { return this.name; }

            set
            {
                //if (value == null)
                //{
                //    throw new ArgumentNullException("Name is a mandatory attribute!");
                //}

                //value = value.Trim();
                //if (value == "")
                //{
                //    throw new ArgumentException("Name cannot be empty!");
                //}

                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Invalid name!");

                this.name = value;
            } 
        }

        public int Age
        {
            get { return this.age; }

            set
            {
                if(value < 1 || value > 100)
                {
                    throw new ArgumentException("Age of person must be in range [1 - 100] years!");
                }

                this.age = value;
            }
        }

        public string Email
        {
            get { return this.email; }

            set
            {
                string pattern = @"[^\s@]+@[^\s@]+";
                Regex regex = new Regex(pattern);

                if (value == null || regex.IsMatch(value))
                {
                    this.email = value;
                }
                else
                {
                    throw new ArgumentException("Invalid email!");
                }
            }
        }

        public override string ToString()
        {
            return String.Format("My name is {0}. I am {1} years old. {2}", 
                this.Name, this.Age, string.IsNullOrWhiteSpace(this.Email) ? "I don't have an email adress." : "My email is: " + this.Email);
        }
    }
}
