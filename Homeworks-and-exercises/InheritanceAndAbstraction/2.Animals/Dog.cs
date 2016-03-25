using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.Animals
{
    public class Dog : Animal
    {
        private Gender gender;
        public Dog(string name, double age, Gender gender) : base(name, age)
        {
            this.Gender = gender;
        }

        public override Gender Gender
        {
            get { return this.gender; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Gender", "Gender cannot be null or empty");
                }
                this.gender = value;
            }
        }

        public override String ProduceSound()
        {
            string sound = "Bau-bau!";
            return sound;
        }
    }
}
