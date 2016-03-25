using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAndAbstraction
{
    public class Worker : Human
    {
        private const int WorkDaysPerWeek = 5;
        private decimal weekSalary;
        private int workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Week salary cannot have a negative value");
                }
                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Work hours per day cannot be a negative number");
                }
                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            decimal result = this.WeekSalary / (this.WorkHoursPerDay * WorkDaysPerWeek);
            return result;
        }

        

        public override string ToString()
        {
            string result = String.Format("Worker's first name: {0}\nWorker's last name: {1}\nWorker's payment per hour: {2:C2}\n",
                this.FirstName, this.LastName, this.MoneyPerHour());
            return result;
        }
    }
}
