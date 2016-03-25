using System.Text;

namespace FarmersCreed.Units
{
    using System;
    using FarmersCreed.Interfaces;

    public abstract class Animal : FarmUnit
    {
        protected Animal(string id, int health, int productionQuantity)
            : base(id, health, productionQuantity)
        {
        }

        public int ProductionHealthEffect { get; protected set; }

        public virtual void Starve()
        {
            if (this.IsAlive)
            {
                this.Health--;

                if (this.Health <= 0)
                {
                    this.IsAlive = false;
                }
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat("{0}, {1}", base.ToString(),
                this.Health > 0 ? string.Format("Health: {0}", this.Health) : "DEAD");

            return output.ToString();
        }

        public abstract void Eat(IEdible food, int quantity);
    }
}
