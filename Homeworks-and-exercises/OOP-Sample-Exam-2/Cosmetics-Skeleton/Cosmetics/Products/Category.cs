using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics
{
    public class Category : ICategory
    {
        private const int CategoryNameMinLength = 2;
        private const int CategoryNameMaxLength = 15;
        private string name;
        public Category(string name)
        {
            this.Name = name;
            this.Products=new List<IProduct>();
        }
    
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", String.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Category name"));
                }
                if (value.Length < 2 || value.Length > 15)
                {
                    throw new ArgumentOutOfRangeException(
                        "value", String.Format(GlobalErrorMessages.InvalidStringLength, "Category name", CategoryNameMinLength, CategoryNameMaxLength));
                }

                this.name = value;
            }
        }

        public IList<IProduct> Products { get; set; }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.Products.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (this.Products.All(p => p.Name != cosmetics.Name))
            {
                throw new ArgumentNullException(String.Format("Product {0} does not exist in category {1}!", cosmetics.Name, this.Name));
            }

            this.Products.Remove(cosmetics);
        }

        public string Print()
        {
            this.SortProducts(this.Products);

            var result = new StringBuilder();
            result.AppendLine(String.Format("{0} category – {1} {2} in total",
                this.Name, this.Products.Count, this.Products.Count > 1 ? "products" : "product"));
            foreach (var product in this.Products)
            {
                result.Append(product.Print());
            }
            //result.AppendFormat(String.Join("\n", this.Products));

            return result.ToString();
        }

        private void SortProducts(IList<IProduct> products)
        {
            if (products == null)
            {
                throw new ArgumentNullException("Cannot sort an empty list of products.");
            }

            products.OrderBy(p => p.Brand).OrderByDescending(p => p.Price);
        }
    }
}
