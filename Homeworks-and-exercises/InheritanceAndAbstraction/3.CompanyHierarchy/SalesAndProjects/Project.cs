using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.CompanyHierarchy
{
    public class Project : IProject
    {
        private string projectName;
        private DateTime projectStartDate;
        private string details;
        private ProjectStates state;

        public Project(string projectName, DateTime projectStartDate, string details, ProjectStates state)
        {
            this.ProjectName = projectName;
            this.ProjectStartDate = projectStartDate;
            this.Details = details;
            this.State = state;
        }
    
        public string ProjectName
        {
            get { return this.projectName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "Project name cannot be null or empty");
                }
                this.projectName = value;
            }
        }

        public DateTime ProjectStartDate
        {
            get { return this.projectStartDate; }
            set
            {
                DateTime date;
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Date cannot be null or empty");
                }
                if ((Convert.ToInt32(value.Day) < 0 || Convert.ToInt32(value.Month) < 0 || Convert.ToInt32(value.Year) < 0) || value > DateTime.Today)
                {
                    throw new ArgumentOutOfRangeException("value", "Invalid date of sales");
                }
                this.projectStartDate = value;
            }
        }

        public string Details
        {
            get { return this.details; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "Project details cannot be null or empty");
                }
                this.details = value;
            }
        }

        public ProjectStates State
        {
            get { return this.state; }
            set
            {
                this.state = ProjectStates.open;
            }
        }

        public void CloseProject()
        {
            this.State = ProjectStates.closed;
        }

        public override string ToString()
        {
            string result = String.Format("Project name: {0}\nProject start date: {1}\nDetails: {2}\nProject state: {3}\n",
                                          this.ProjectName, this.ProjectStartDate.ToString(), this.Details, this.State);
            return result;
        }
    }
}
