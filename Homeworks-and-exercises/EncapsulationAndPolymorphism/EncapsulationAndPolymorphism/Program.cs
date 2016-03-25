using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncapsulationAndPolymorphism.Interfaces;

namespace EncapsulationAndPolymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IShape[] shapes =
                {
                    new Rectangle(5.2, 9),
                    new Rectangle(6, 8),
                    new Triangle(7, 8), 
                    new Circle(7), 
                    new Circle(7.8), 
                };

                foreach (var shape in shapes)
                {
                    //Console.WriteLine("The area of {0} is: {1:N2}", shape.GetType().Name, shape.CalculateArea());
                    if (!(shape is Triangle))
                    {
                        Console.WriteLine("The perimeter of {0} is: {1:N2}", shape.GetType().Name, shape.CalculatePerimeter());
                    }
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}
