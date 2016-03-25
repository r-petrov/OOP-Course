using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.CompanyHierarchy
{
    public interface IProject
    {
        string ProjectName
        {
            get;
            set;
        }

        DateTime ProjectStartDate
        {
            get;
            set;
        }

        string Details
        {
            get;
            set;
        }

        ProjectStates State
        {
            get;
            set;
        }

        void CloseProject();
    }
}
