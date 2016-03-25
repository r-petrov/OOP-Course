using System.Text;
using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    using System;

    public abstract class FarmUnit : GameObject, IProductProduceable 
    {
        private int health;
        private int productionQuantity;

        protected FarmUnit(string id, int health, int productionQuantity)
            : base(id)
        {
            this.Health = health;
            this.ProductionQuantity = productionQuantity;
            this.IsAlive = true;
        }

        public int Health { get; set; }

        public bool IsAlive { get; set; }

        public int ProductionQuantity
        {
            get { return this.productionQuantity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Production quantity cannot be a negative number.");
                }
                this.productionQuantity = value;
            }
        }

        public abstract Product GetProduct();
    }
}
