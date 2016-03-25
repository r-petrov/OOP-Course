using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncapsulationAndPolymorphism
{
    public class Rectangle : BasicShape
    {
        public Rectangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateArea()
        {
            double result = this.Width * this.Height;
            return result;
        }

        public override double CalculatePerimeter()
        {
            double result = (2 *this.Width) + (2 * this.Height);
            return result;
        }
    }
}
