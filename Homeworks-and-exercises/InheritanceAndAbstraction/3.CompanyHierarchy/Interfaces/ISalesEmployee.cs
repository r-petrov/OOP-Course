using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.CompanyHierarchy
{
    public interface ISalesEmployee
    {
        List<Sale> Sales
        {
            get;
            set;
        }
    }
}
