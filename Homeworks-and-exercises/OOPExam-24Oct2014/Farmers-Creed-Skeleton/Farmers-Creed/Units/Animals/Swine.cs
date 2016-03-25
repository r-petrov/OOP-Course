using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarmersCreed.Interfaces;
using FarmersCreed.Units;

namespace FarmersCreed
{
    public class Swine : Animal
    {
        public const int StarvingSpeed = 3;
        public Swine(string id, int health, int productionQuantity)
            : base(id, health, productionQuantity)
        {
            this.ProductionHealthEffect = 5;
        }

        public override void Starve()
        {
            for (int i = 0; i < StarvingSpeed; i++)
            {
                base.Starve();
            }
        }

        public override void Eat(IEdible food, int quantity)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("The swine is already dead and cannot eat.");
            }

            this.Health += 2*food.HealthEffect*quantity;
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("The swine is already dead and cannot give product anymore.");
            }

            var product = new Food(String.Format("{0}Product", this.Id), 
                ProductType.PorkMeat, FoodType.Meat, this.ProductionQuantity, this.ProductionHealthEffect);

            this.Health = 0;
            this.IsAlive = false;

            return product;
        }
    }
}
