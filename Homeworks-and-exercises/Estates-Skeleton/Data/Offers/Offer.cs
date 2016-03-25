using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estates.Interfaces;

namespace Estates
{
    public class Offer : IOffer
    {
        public OfferType Type { get; set; }

        public IEstate Estate { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat("{0}: Estate = {1}, Location = {2}", this.Type.ToString(), this.Estate.Name,
                this.Estate.Location);

            return output.ToString();
        }
    }
}
