using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncapsulationAndPolymorphism
{
    public class Triangle : BasicShape
    {
        public Triangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateArea()
        {
            double result = (this.Width * this.Height) / 2;
            return result;
        }

        public override double CalculatePerimeter()
        {
            throw new NotImplementedException();
        }
    }
}
