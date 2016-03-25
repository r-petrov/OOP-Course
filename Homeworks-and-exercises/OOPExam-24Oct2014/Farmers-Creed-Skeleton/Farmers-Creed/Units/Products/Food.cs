using System.Text;

namespace FarmersCreed.Units
{
    using System;
    using Interfaces;

    public class Food : Product, IEdible
    {
        public Food(string id, ProductType productType, FoodType foodType, int quantity, int healthEffect)
            : base(id, productType, quantity)
        {
            this.HealthEffect = healthEffect;
            this.FoodType = foodType;
        }

        public FoodType FoodType { get; set; }

        public int HealthEffect { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat("{0}, Food Type: {1}, Health Effect: {2}", base.ToString(), this.FoodType,
                this.HealthEffect);
            return output.ToString();
        }
    }
}
