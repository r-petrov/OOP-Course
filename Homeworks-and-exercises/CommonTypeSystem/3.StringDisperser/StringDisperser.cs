using System;
using System.Collections;
using System.Linq;

namespace _3.StringDisperser
{
    using System.Collections.Generic;

    class StringDisperser : ICloneable, IComparable<StringDisperser>, IEnumerable<char>
    {
        private readonly IList<string> strings;
        private int index;

        public StringDisperser(params string[] strings)
        {
            this.strings = new List<string>(strings);
            this.index += this.strings.Count;
        }

        public void AddString(string newString)
        {
            this.strings.Add(newString);
            this.index++;
        }

        public static bool operator ==(StringDisperser stringDisperser, StringDisperser otherStringDisperser)
        {
            if (object.Equals(stringDisperser, null) || object.Equals(otherStringDisperser, null))
            {
                return false;
            }

            var areEqual = StringDisperser.Equals(stringDisperser, otherStringDisperser);

            return areEqual;
        }

        public static bool operator !=(StringDisperser stringDisperser, StringDisperser otherStringDisperser)
        {
            return !(stringDisperser == otherStringDisperser);
        }

        public override bool Equals(object other)
        {
            var otherStringDisperser = other as StringDisperser;
            if (object.Equals(otherStringDisperser, null))
            {
                return false;
            }

            // check wether two lists of strings have the same elements ordered in the same sequence
            //var areEqual = Enumerable.SequenceEqual(this.strings.OrderBy(s => s), otherStringDisperser.strings.OrderBy(s => s));
            //var areEqual = this.strings.OrderBy(s => s).SequenceEqual(otherStringDisperser.strings.OrderBy(s => s));
            var areEqual = this.strings.SequenceEqual(otherStringDisperser.strings);

            return areEqual;
        }

        public int CompareTo(StringDisperser other)
        {
            if (object.Equals(other, null))
            {
                throw new ArgumentNullException("The passed string disperser is empty!");
            }

            var strings = string.Join(string.Empty, this.strings);
            var otherStrings = string.Join(string.Empty, other.strings);
            var result = String.CompareOrdinal(strings, otherStrings);

            return result;
        }

        public IEnumerator<char> GetEnumerator()
        {
            for (int i = 0; i < this.index; i++)
            {
                var chars = this.strings[i].ToCharArray();
                foreach (var character in chars)
                {
                    yield return character;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            var output = string.Join(", ", this.strings);
            return output;
        }

        public override int GetHashCode()
        {
            var hashCode = this.strings.GetHashCode();
            return hashCode;
        }
        
        public object Clone()
        {
            var clone = new StringDisperser(this.strings.ToArray());

            return clone;
        }
    }
}
