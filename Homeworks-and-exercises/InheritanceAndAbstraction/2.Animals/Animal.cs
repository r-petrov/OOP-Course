using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.Animals
{
    public enum Gender
    {
        Male,
        Female
    }
    public abstract class Animal : ISoundProducible
    {
        private string name;
        private double age;
        //private string gender;
        
        protected Animal(string name, double age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name", "Name cannot be null or empty");
                }
                this.name = value;
            }
        }

        public double Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Age", "Age cannot take negative values");
                }
                this.age = value;
            }
        }

        public abstract Gender Gender { get; set; }
       
        public abstract string ProduceSound();

        public virtual string ToString()
        {
            string result = String.Format("{0} year old {1} dog {2} said: {3}", this.Age, this.Gender, this.Name, this.ProduceSound());
            return result;
        }
    }
}
