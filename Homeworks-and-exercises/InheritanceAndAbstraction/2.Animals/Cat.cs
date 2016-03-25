using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.Animals
{
    
    public abstract class Cat : Animal
    {
        protected Cat(string name, double age)
            : base(name, age)
        {
        }
    }
}
