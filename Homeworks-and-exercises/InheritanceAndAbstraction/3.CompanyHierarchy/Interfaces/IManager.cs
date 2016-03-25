using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.CompanyHierarchy
{
    public interface IManager
    {
        IDictionary<string, SalesEmployee> SalesEmployees
        {
            get;
            set;
        }

        IDictionary<string, Developer> Developers
        {
            get;
            set;
        }
    }
}
