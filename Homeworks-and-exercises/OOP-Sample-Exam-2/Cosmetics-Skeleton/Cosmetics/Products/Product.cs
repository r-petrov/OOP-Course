using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics
{
    public abstract class Product : IProduct
    {
        private const int ProductNameMinLength = 3;
        private const int ProductNameMaxLength = 10;
        private const int ProductBrandMinLength = 2;
        private const int ProductBrandMaxLength = 10;

        private string name;
        private string brand;
        private decimal price;
        private GenderType gender;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }
    
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", String.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Product name"));
                }

                if (value.Length < 3 || value.Length > 10)
                {
                    throw new ArgumentOutOfRangeException("value", 
                        String.Format(GlobalErrorMessages.InvalidStringLength, "Product name", ProductNameMinLength, ProductNameMaxLength));
                }

                this.name = value;
            }
        }

        public string Brand
        {
            get { return this.brand; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", String.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Product brand"));
                }
                if (value.Length < 2 || value.Length > 10)
                {
                    throw new ArgumentOutOfRangeException("value",
                        String.Format(GlobalErrorMessages.InvalidStringLength, "Product brand", ProductBrandMinLength, ProductBrandMaxLength));
                }

                this.brand = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Price should be a positive number.");
                }

                this.price = value;
            }
        }

        public GenderType Gender
        {
            get { return this.gender; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", String.Format(GlobalErrorMessages.ObjectCannotBeNull, "Product gender type"));
                }

                this.gender = value;
            }
        }

        public virtual string Print()
        {
            var result = new StringBuilder();
            result.AppendLine(String.Format("- {0} - {1}:", this.Brand, this.Name));
            result.AppendLine(String.Format("  * Price: ${0}", this.Price));
            result.AppendLine(String.Format("  * For gender: {0}", this.Gender));

            return result.ToString();
        }
    }
}
