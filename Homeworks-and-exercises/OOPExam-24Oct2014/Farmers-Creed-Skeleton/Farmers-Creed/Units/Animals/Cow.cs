using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarmersCreed.Interfaces;
using FarmersCreed.Units;

namespace FarmersCreed
{
    public class Cow : Animal
    {
        const int HealthLoss = 2;

        public Cow(string id, int health, int productionQuantity)
            : base(id, health, productionQuantity)
        {
            this.ProductionHealthEffect = 4;
        }

        public override void Eat(IEdible food, int quantity)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("The cow is already dead and cannot eat.");
            }

            if (food.FoodType == FoodType.Organic)
            {
                this.Health += food.HealthEffect*quantity;
            }
            else
            {
                this.Health -= food.HealthEffect*quantity;
            }

            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("The cow is already dead and cannot give any production.");
            }

            var product=new Food(String.Format("{0}Product", this.Id), ProductType.Milk, FoodType.Organic, this.ProductionQuantity, this.ProductionHealthEffect);

            this.Health -= HealthLoss;

            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }

            return product;
        }
    }
}
