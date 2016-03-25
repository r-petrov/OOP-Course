using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarmersCreed
{
    public abstract class FoodPlant : FarmersCreed.Units.Plant
    {
        protected FoodPlant(string id, int health, int productionQuantity, int growTime) : base(id, health, productionQuantity, growTime)
        {
            this.HealthIncrease = 1;
            this.HealthLoss = base.HealthLoss*2;
        }
    }
}
