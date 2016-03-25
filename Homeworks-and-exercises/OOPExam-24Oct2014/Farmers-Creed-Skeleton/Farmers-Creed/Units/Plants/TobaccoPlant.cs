using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarmersCreed.Units;

namespace FarmersCreed
{
    public class TobaccoPlant : Plant
    {
        public TobaccoPlant(string id, int health, int productionQuantity, int growTime) : base(id, health, productionQuantity, growTime)
        {
            this.GrowSpeed = base.GrowSpeed*2;
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive || this.GrowTime > 0)
            {
                throw new InvalidOperationException("Tobacco plant cannot produce while growing or if dead.");
            }

            var product = new Product(String.Format("{0}Product", this.Id), ProductType.Tobacco, this.ProductionQuantity);
            return product;
        }
    }
}
