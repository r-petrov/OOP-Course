using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.Animals
{
    public class Kitten : Cat
    {
        private Gender gender;
        public Kitten(string name, double age, Gender gender)
            : base(name, age)
        {
            this.Gender = gender;
        }

        public override Gender Gender
        {
            get { return this.gender; }
            set { this.gender = Gender.Female; }
        }

        public override string ProduceSound()
        {
            string sound = "Miaow!";
            return sound;
        }
    }
}
