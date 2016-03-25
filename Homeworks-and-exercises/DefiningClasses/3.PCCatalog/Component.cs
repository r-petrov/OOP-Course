using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.PCCatalog
{
    class Component
    {
        private string name;
        //private string details;
        private decimal price;
        
        public Component(string name, string details, decimal price)
        {
            this.Name = name;
            this.Details = details;
            this.Price = price;
        }

        public Component(string name, decimal price) : this(name, null, price)
        {
        }

        public string Name
        {
            get { return this.name; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid name!");
                }

                this.name = value;
            }
        }

        public string Details { get; set; }

        public decimal Price
        {
            get { return this.price; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid price value!");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            return String.Format("{0,-15}{1}{2,100}", this.Name, this.Details ?? null, this.Price);
        }
    }
}
