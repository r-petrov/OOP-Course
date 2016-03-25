using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.CompanyHierarchy
{
    public class Customer : Person, ICustomer
    {
        private decimal netPurchaseAmount;

        public Customer(string firstName, string lastName, string id, decimal netPurchaseAmount)
            : base(firstName, lastName, id)
        {
            this.NetPurchaseAmount = netPurchaseAmount;
        }
        public decimal NetPurchaseAmount
        {
            get { return this.netPurchaseAmount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Net purchase amount cannot be a negative number");
                }
                this.netPurchaseAmount = value;
            }
        }

        public override string ToString()
        {
            string result = String.Format("First name: {0}\nLast name: {1}\nNet purchase amount: {2}", 
                this.FirstName, this.LastName, this.NetPurchaseAmount);
            return result;
        }
    }
}
