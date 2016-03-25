using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonTypeSystem_Exercises
{
    public class Country : IComparable<Country>, ICloneable
    {
        private string name;
        private double area;

        public Country(string name, ulong population, double area, params string[] cicties)
        {
            this.Name = name;
            this.Population = population;
            this.Area = area;
            this.Cities = new HashSet<string>(cicties);
        }

        public string Name
        {
            get
            {
                return this.name;
                
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("name", "Country name should not be null, empty or whitespace!");
                }

                this.name = value;
            }
        }

        public ulong Population { get; set; }

        public double Area
        {
            get
            {
                return this.area;
                
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("area", "The area of country should be a positive number!");
                }

                this.area = value;
            }
        }

        public HashSet<string> Cities { get; private set; }

        public int CompareTo(Country other)
        {
            if (object.Equals(other, null))
            {
                throw new ArgumentNullException("The passed comparable country should not be empty!");
            }

            if (this.Area.CompareTo(other.Area) < 0)
            {
                return 1;
            }
            else if (this.Area.CompareTo(other.Area) > 0)
            {
                return -1;
            }

            if (this.Population.CompareTo(other.Population) < 0)
            {
                return 1;
            } 
            else if (this.Population.CompareTo(other.Population) > 0)
            {
                return -1;
            }

            if (this.Name.CompareTo(other.Name) < 0)
            {
                return -1;
            }
            else if (this.Name.CompareTo(other.Name) > 0)
            {
                return 1;
            }

            return 0;
        }

        public override bool Equals(object paramCountry)
        {
            var otherCountry = paramCountry as Country;
            if (object.Equals(otherCountry, null))
            {
                return false;
            }

            bool areCountriesEqual = this.Name.Equals(otherCountry.Name);
            
            return areCountriesEqual;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public object Clone()
        {
            var countryCopy = new Country(this.Name, this.Population, this.Area, this.Cities.ToArray());

            return countryCopy;
        }

        public static bool operator ==(Country country1, Country country2)
        {
            if (object.Equals(country1, null))
            {
                return false;
            }

            bool areCountriesEqual = country1.Equals(country2);

            return areCountriesEqual;
        }

        public static bool operator !=(Country country1, Country country2)
        {
            return !(country1 == country2);
        }
    }
}
