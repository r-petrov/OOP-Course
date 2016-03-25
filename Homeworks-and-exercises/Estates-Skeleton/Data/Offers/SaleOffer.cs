using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estates.Interfaces;

namespace Estates
{
    public class SaleOffer : Offer, ISaleOffer
    {
        public SaleOffer()
        {
            this.Type = OfferType.Sale;
        }

        public decimal Price { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat("{0}, Price = {1}", base.ToString(), this.Price);

            return output.ToString();
        }
    }
}
