using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estates.Interfaces;

namespace Estates
{
    public class Garage : Estate, Estates.Interfaces.IGarage
    {
        private int width;

        private int height;

        public Garage()
        {
            this.Type=EstateType.Garage;
        }
    
        public int Width
        {
            get { return this.width; }
            set
            {
                if (value < 0 || value > 500)
                {
                    throw new ArgumentOutOfRangeException("value", "Garage widths should be in range [0…500].");
                }

                this.width = value;
            }
        }

        public int Height
        {
            get { return this.height; }
            set
            {
                if (value < 0 || value > 500)
                {
                    throw new ArgumentOutOfRangeException("value", "Garage heights should be in range [0…500].");
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat("{0}, Width: {1}, Height: {2}", base.ToString(), this.Width, this.Height);

            return output.ToString();
        }
    }
}
