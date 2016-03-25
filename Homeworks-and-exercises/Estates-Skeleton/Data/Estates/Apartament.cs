using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estates.Interfaces;

namespace Estates
{
    public class Apartament : BuildingEstate, IApartment
    {
        public Apartament()
        {
            this.Type = EstateType.Apartment;
        }
    }
}
