using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmetics.Contracts;

namespace Cosmetics
{
    public class ShoppingCart : IShoppingCart
    {
        public ShoppingCart()
        {
            this.Products = new List<IProduct>();
        }
        public IList<IProduct> Products { get; set; }

        public void AddProduct(IProduct product)
        {
            this.Products.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.Products.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            bool containsProduct = this.Products.Any(p => p.Name == product.Name);

            return containsProduct;
        }

        public decimal TotalPrice()
        {
            return this.Products.Sum(product => product.Price);
        }
    }
}
