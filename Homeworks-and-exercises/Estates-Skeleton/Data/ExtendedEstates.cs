using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estates.Interfaces;

namespace Estates
{
    class ExtendedEstateEngine : Engine.EstateEngine
    {
        public ExtendedEstateEngine()
        {
            this.OffersForRent = new List<IRentOffer>();
        }
        public List<IRentOffer> OffersForRent { get; set; }

        public override string ExecuteCommand(string cmdName, string[] cmdArgs)
        {
            switch (cmdName)
            {
                case "find-rents-by-location location":
                    return this.ExecuteFindRentsByLocationCommand(cmdArgs[0]);
                case "find-rents-by-price":
                    return this.ExecuteFindRentsByPriceCommand(decimal.Parse(cmdArgs[0]), decimal.Parse(cmdArgs[1]));
                default:
                    throw new NotImplementedException("Unknown command: " + cmdName);
            }
        }

        private string ExecuteFindRentsByLocationCommand(string location)
        {
            var offers = this.Offers
                .Where(o => o.Estate.Location == location && o.Type == OfferType.Rent)
                .OrderBy(o => o.Estate.Name);
            return FormatQueryResults(offers);
        }

        private string ExecuteFindRentsByPriceCommand(decimal minPrice, decimal maxPrice)
        {
            var offers = this.OffersForRent
                .Where(o => o.Type == OfferType.Rent && (o.PricePerMonth >= minPrice && o.PricePerMonth <= maxPrice))
                .OrderBy(o => o.PricePerMonth).ThenBy(o => o.Estate.Name);
            return FormatQueryResults(offers);
        }
    }
}
