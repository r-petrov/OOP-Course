using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarmersCreed.Units;

namespace FarmersCreed
{
    public class CherryTree : FoodPlant
    {
        public CherryTree(string id, int health, int productionQuantity, int growTime)
            : base(id, health, productionQuantity, growTime)
        {
            this.ProductionQuantity = 4;
        }

        public override Units.Product GetProduct()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Cherry tree cannot produce if dead.");
            }

            var product = new Food(String.Format("{0}Product", this.Id), ProductType.Cherry, FoodType.Organic, this.ProductionQuantity, 2);
            return product;
        }
    }
}
