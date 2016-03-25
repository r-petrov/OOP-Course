namespace CommonTypeSystem
{
    using System;

    public class Payment
    {
        private string name;
        private decimal price;

        public Payment(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
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
                    throw new ArgumentNullException("Product's name can not be null, empty or white space!");
                }

                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Product's price can not have a negative number!");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            string output = string.Format("\tName of payment: {0}\n\tPrice: {1}", this.Name, this.Price);

            return output;
        }
    }
}
