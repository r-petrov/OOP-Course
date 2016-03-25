using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncapsulationAndPolymorphism
{
    public class Circle : EncapsulationAndPolymorphism.Interfaces.IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get { return this.radius; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Radius must have a positive value!");
                }
                this.radius = value;
            }
        }
    
        public double CalculateArea()
        {
            double result = Math.PI * this.Radius * this.Radius;
            return result;
        }

        public double CalculatePerimeter()
        {
            double result = 2*Math.PI*this.Radius;
            return result;
        }
    }
}
