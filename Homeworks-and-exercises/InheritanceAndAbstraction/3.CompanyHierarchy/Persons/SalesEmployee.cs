using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.CompanyHierarchy
{
    public class SalesEmployee : Employee, ISalesEmployee
    {
        private List<Sale> sales;

        public SalesEmployee(string firstName, string lastName, string id, decimal salary, Departaments departament, List<Sale> sales)
            : base(firstName, lastName, id, salary, departament)
        {
            this.Sales = sales;
        }

        public List<Sale> Sales
        {
            get { return this.sales; }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("{0} {1}, {2}, still doesn't have any sales!", this.FirstName, this.LastName, this.ID);
                }
                this.sales = value;
            }
        }

        public override string ToString()
        {
            string result = base.ToString() + String.Format("Sales:\n{0}\n", String.Join("\n", this.Sales));
            return result;
        }
    }
}
