using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3.PCCatalog
{
    class Computer
    {
        private string name;
        private Component[] components;
        private decimal price;

        public Computer(string name, Component[] components, decimal price)
        {
            this.Name = name;
            this.Components = components;
            this.Price = price;
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

        public Component[] Components
        {
            get { return this.components; }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Invalid components!");
                }

                this.components = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid value of price!");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            //return String.Format("{0,-15}{1}{2,75}", this.Name, 
            //    string.IsNullOrEmpty(this.Components.ToString()) ? null : string.Join(", ", this.Components.ToString()), this.Price);
            string pattern = @"\d+";
            Regex regex = new Regex(pattern);

            StringBuilder comps = new StringBuilder();
            decimal totalSum = 0m;

            foreach (var component in this.Components)
            {
                Match match = regex.Match(component.Price.ToString());

                comps.Append(component.Name.PadRight(15) + (match.ToString().Length < 3 ? " " + component.Price + " лв.\n" : component.Price + " лв.\n"));
                totalSum += component.Price;
            }

            return String.Format("{0}\n{1}{2}{3:c2}", this.Name, comps, 
                totalSum.ToString().Length == 7 ? "Total price:".PadRight(13) : "Total price:".PadRight(15), totalSum);
        }
    }
}
