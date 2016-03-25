using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.CompanyHierarchy
{
    public interface ISale
    {
        string ProductName
        {
            get;
            set;
        }

        DateTime Date
        {
            get;
            set;
        }

        Decimal Price
        {
            get;
            set;
        }
    }
}
