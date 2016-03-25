using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.Animals
{
    public class Frog : Animal
    {
        private Gender gender;
        public Frog(string name, double age, Gender gender)
            : base(name, age)
        {
            this.Gender = gender;
        }
        public override  Gender Gender
        {
            get { return this.gender; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Gender",  "Gender cannot be null or empty");
                }
                this.gender = value;
            }
        }

        public override string ProduceSound()
        {
            string sound = "Kvak-kvak!";
            return sound;
        }
    }
}
