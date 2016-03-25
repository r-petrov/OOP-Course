using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefiningClasses_Exercise;

namespace _1.OOP
{
    class DefiningClasses_Exercise
    {
        static void Main(string[] args)
        {
            Dog unnamedDog = new Dog();

            Dog sharo=new Dog("Sharo", "Karakachan");

            unnamedDog.Breed = "Irish Setter";

            unnamedDog.Bark();
            sharo.Bark();
        }
    }
}
