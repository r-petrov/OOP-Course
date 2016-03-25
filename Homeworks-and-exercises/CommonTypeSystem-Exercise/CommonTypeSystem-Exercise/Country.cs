using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypeSystem_Exercise
{
    class Country : IComparable<Country>, ICloneable
    {
        private string name;
        private double area;

        public Country(string name, ulong population, double area, params string[] cities)
        {
            this.Name = name;
            this.Population = population;
            this.Area = area;
            this.Cities = new HashSet<string>(cities);
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Country name cannot be null, empty or whitespace.");
                }

                this.name = value;
            }
        }

        public ulong Population { get; set; }

        public double Area
        {
            get { return this.area; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("area", "The country area should have a positive value.");
                }

                this.area = value;
            }
        }

        public HashSet<string> Cities { get; private set; }

        public int CompareTo(Country other)
        {
            if (Math.Abs(this.Area - other.Area) < 0.0001)
            {
                if (this.Population == other.Population)
                {
                    return string.Compare(this.Name, other.Name, StringComparison.InvariantCulture);
                }

                return this.Population.CompareTo(other.Population)*-1;
            }

            return this.Area.CompareTo(other.Area)*-1;
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(String.Format("Country's name: {0}; population: {1}; area: {2}; {3}",
                this.Name, this.Population, this.Area, this.Cities.Count > 0 ? "major cities: " + string.Join(", ", this.Cities) : null));
            return output.ToString();
        }

        public override bool Equals(object obj)
        {
            var otherCountry = obj as Country;

            if (object.Equals(otherCountry, null))
            {
                return false;
            }

            return this.Name == otherCountry.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public object Clone()
        {
            return new Country(this.Name, this.Population, this.Area, this.Cities.ToArray());
        }

        public static bool operator == (Country country1, Country country2)
        {
            if (object.Equals(country1, null))
            {
                return false;
            }

            return country1.Equals(country2);
        }

        public static bool operator !=(Country country1, Country country2)
        {
            return !(country1 == country2);
        }
    }
}
