using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.CompanyHierarchy
{
    public class Manager : Employee, IManager
    {
        private IDictionary<string, Developer> developers;
        private IDictionary<string, SalesEmployee> salesEmployees;

        public Manager(string firstName, string lastName, string id, decimal salary, Departaments departament, IDictionary<string, SalesEmployee> salesEmployees = null, IDictionary<string, Developer> developers = null)
            : base(firstName, lastName, id, salary, departament)
        {
            this.SalesEmployees = salesEmployees;
            this.Developers = developers;
        }

        public IDictionary<string, SalesEmployee> SalesEmployees
        {
            get { return this.salesEmployees; }
            set
            {
                this.salesEmployees = value;
            }
        }

        public IDictionary<string, Developer> Developers
        {
            get { return this.developers; }
            set
            {
                this.developers = value;
            }
        }

        public override string ToString()
        {
            string result = base.ToString() + String.Format("Sales employees:\n{0}\nDevelopers:\n{1}\n", string.Join("\n", this.SalesEmployees.Values), string.Join("\n", this.Developers.Values));
            return result;
        }
    }
}
