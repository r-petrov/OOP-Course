﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estates.Interfaces;

namespace Estates
{
    public class Office : BuildingEstate, IOffice
    {
        public Office()
        {
            this.Type = EstateType.Office;
        }
    }
}
