using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.CompanyHierarchy
{
    public class Sale : ISale
    {
        private string productName;
        private decimal price;
        private DateTime date;

        public Sale(string productName, DateTime date, decimal price)
        {
            this.ProductName = productName;
            this.Date = date;
            this.Price = price;
        }

        public string ProductName
        {
            get { return this.productName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "Product name cannot be null or empty");
                }
                this.productName = value;
            }
        }

        public DateTime Date
        {
            get { return this.date; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Date cannot be null or empty");
                }
                if ((Convert.ToInt32(value.Day) < 0 || Convert.ToInt32(value.Month) < 0 || Convert.ToInt32(value.Year) < 0) || value > DateTime.Today)
                {
                    throw new ArgumentOutOfRangeException("value", "Invalid date of sales");
                }
                this.date = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Price cannot be a negative number");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            string result = String.Format("Product name: {0}\nPrice: {1:C2}\nDate of sale: {2}\n", this.ProductName, this.Price, this.Date.ToString());
            return result;
        }
    }
}
