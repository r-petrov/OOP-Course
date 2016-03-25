using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.CompanyHierarchy
{
    public abstract class Employee : Person, IEmployee
    {
        private decimal salary;

        protected Employee(string firstName, string lastName, string id, decimal salary, Departaments departament)
            : base(firstName, lastName, id)
        {
            this.Salary = salary;
            this.Departament = departament;
        }
    
        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Salary cannot be a negative number");
                }
                this.salary = value;
            }
        }

        public Departaments Departament { get; set; }

        public override string ToString()
        {
            string result = String.Format("First name: {0}\nLast name: {1}\nID: {2}\nSalary: {3}\nDepartament: {4}\n", this.FirstName, this.LastName, this.ID, this.Salary, this.Departament);
            return result;
        }
    }
}
