using System.Text;

namespace FarmersCreed.Units
{
    using System;
    using System.Collections.Generic;

    public class Product : GameObject, IProduct
    {
        private int quantity;
        private ProductType productType;

        public Product(string id, ProductType productType, int quantity)
            : base(id)
        {
            this.Quantity = quantity;
            this.ProductType = productType;
        }

        public int Quantity
        {
            get { return this.quantity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Product quantity cannot be negative!");
                }
                this.quantity = value;
            }
        }

        public ProductType ProductType { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat("{0}, Quantity: {1}, Product Type: {2}", 
                base.ToString(), this.Quantity, this.ProductType);

            return output.ToString();
        }
    }
}
