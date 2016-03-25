using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics
{
    public class Toothpaste : Product, IToothpaste
    {
        private const int IngredientsMinLength = 4;
        private const int IngredientsMaxLength = 12;
        private string ingredients;
        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            if (ingredients.Any(i => i.Length < 4 || i.Length > 12))
            {
                throw new ArgumentOutOfRangeException(
                    String.Format(GlobalErrorMessages.InvalidStringLength, "Each ingredient", IngredientsMinLength, IngredientsMaxLength));
            }
            this.Ingredients=String.Join(", ", ingredients);
        }

        public string Ingredients
        {
            get { return this.ingredients; }
            private set
            {
                if (value == null || value.Length == 0)
                {
                    throw new ArgumentNullException("value", String.Format(GlobalErrorMessages.ObjectCannotBeNull, "Product ingredients"));
                }

                //this.ingredients = String.Join(", ", value);
                this.ingredients = value;
            }
        }

        public override string Print()
        {
            var result = new StringBuilder();
            result.Append(base.Print());
            result.AppendLine(String.Format("  * Ingredients: {0}", this.Ingredients));

            return result.ToString();
        }
    }
}
