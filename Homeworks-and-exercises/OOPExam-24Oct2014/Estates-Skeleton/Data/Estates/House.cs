using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estates.Interfaces;

namespace Estates
{
    public class House : Estate, IHouse
    {
        private int floors;
        public House()
        {
            this.Type=EstateType.House;
        }
        public int Floors
        {
            get { return this.floors; }
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("value", "House floors should be in range [0…10].");
                }

                this.floors = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat("{0}, Floors: {1}", base.ToString(), this.Floors);

            return output.ToString();
        }
    }
}
