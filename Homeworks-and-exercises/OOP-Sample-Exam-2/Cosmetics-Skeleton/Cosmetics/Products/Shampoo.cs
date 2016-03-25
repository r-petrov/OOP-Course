using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics
{
    public class Shampoo : Product, IShampoo
    {
        private UsageType usage;
        public Shampoo(string name, string brand, decimal price, GenderType gender, uint mililiters, UsageType usage)
            : base(name, brand, price, gender)
        {
            this.Price = price*mililiters;
            this.Milliliters = mililiters;
            this.Usage = usage;
           // this.ShampooValue = price*mililiters;
        }
        public uint Milliliters { get; private set; }

        public UsageType Usage
        {
            get { return usage; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", String.Format(GlobalErrorMessages.ObjectCannotBeNull, "Usage type"));
                }

                this.usage = value;
            }
        }

        //public decimal ShampooValue { get; set; }

        public override string Print()
        {
            var result = new StringBuilder();
            result.Append(base.Print());
            result.AppendLine(String.Format("  * Quantity: {0} ml", this.Milliliters));
            result.AppendLine(String.Format("  * Usage: {0}", this.Usage));
            return result.ToString();
        }
    }
}
