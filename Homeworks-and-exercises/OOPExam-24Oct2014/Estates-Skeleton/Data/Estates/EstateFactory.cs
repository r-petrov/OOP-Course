﻿using Estates.Engine;
using Estates.Interfaces;
using System;

namespace Estates.Data
{
    public class EstateFactory
    {
        public static IEstateEngine CreateEstateEngine()
        {
            return new EstateEngine();
        }

        public static IEstate CreateEstate(EstateType type)
        {
            switch (type)
            {
                 case EstateType.Apartment:
                        return new Apartament();
                 case EstateType.Office:
                        return new Office();
                 case EstateType.House:
                        return new House();
                 case EstateType.Garage:
                        return new Garage();
                default:
                        throw new NotImplementedException("Unknown type: " + type);
            }
        }

        public static IOffer CreateOffer(OfferType type)
        {
            switch (type)
            {
                case OfferType.Rent:
                    return new RentOffer();
                case OfferType.Sale:
                    return new SaleOffer();
                default:
                    throw new NotImplementedException("Unknown offer: " + type);

            }
        }
    }
}
