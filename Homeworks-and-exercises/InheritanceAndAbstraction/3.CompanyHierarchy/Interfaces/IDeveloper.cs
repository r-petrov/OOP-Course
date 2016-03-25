using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.CompanyHierarchy
{
    public interface IDeveloper
    {
        IDictionary<string, Project> Projects
        {
            get;
            set;
        }
    }
}
