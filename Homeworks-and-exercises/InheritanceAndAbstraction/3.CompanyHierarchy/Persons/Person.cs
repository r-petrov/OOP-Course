using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.CompanyHierarchy
{
    public abstract class Person : IPerson
    {
        private string firstName;
        private string lastName;
        private string id;

        protected Person(string firstName, string lastName, string id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ID = id;
        }
    
        public string ID
        {
            get { return this.id; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "ID cannot be null or empty");
                }
                this.id = value;
            }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "First name cannot be null or empty");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "Last name cannot be null or empty");
                }
                this.lastName = value;
            }
        }

        public abstract string ToString();

        //public override string ToString()
        //{
        //    string result = String.Format("First name: {0}\nLast name: {1}\nID: {2}\n", this.FirstName, this.LastName, this.ID);
        //    return result;
        //}
    }
}
