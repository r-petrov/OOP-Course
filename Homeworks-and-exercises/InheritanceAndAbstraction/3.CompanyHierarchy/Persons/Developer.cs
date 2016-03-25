using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.CompanyHierarchy
{
    public class Developer : Employee, IDeveloper
    {
        private IDictionary<string, Project> projects;

        public Developer(string firstName, string lastName, string id, decimal salary, Departaments departament, IDictionary<string, Project> projects)
            : base(firstName, lastName, id, salary, departament)
        {
            this.Projects = projects;
        }

        public IDictionary<string, Project> Projects
        {
            get { return this.projects; }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("{0} {1}, ID: {2}, still doesn't have any projects", this.FirstName, this.LastName, this.ID);
                }
                this.projects = value;
            }
        }


        public override string ToString()
        {
            string result = base.ToString() + String.Format("Projects:\n{0}\n", string.Join("\n", this.Projects.Values));
            return result;
        }
    }
}
