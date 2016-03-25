using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estates.Interfaces;

namespace Estates
{
    public abstract class Estate :IEstate
    {
        private double area;

        //protected Estate()
        //{
        //}
    
        public string Name { get; set; }

        public EstateType Type { get; set; }

        public double Area
        {
            get { return this.area; }
            set
            {
                if (value < 0 || value > 10000)
                {
                    throw new ArgumentOutOfRangeException("value", "Estate area should be in range [0...10000].");
                }

                this.area = value;
            }
        }

        public string Location { get; set; }

        public bool IsFurnished { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat(" {0}: Name = {1}, Area = {2}, Location = {3}, Furnitured = {4}",
                this.Type.ToString(), this.Name, this.Area, this.Location, this.IsFurnished ? "Yes" : "No");

            return output.ToString();
        }
    }
}
