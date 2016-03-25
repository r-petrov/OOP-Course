using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.CompanyHierarchy
{
    public interface IEmployee
    {
        decimal Salary
        {
            get;
            set;
        }

        Departaments Departament
        {
            get;
            set;
        }
    }
}
