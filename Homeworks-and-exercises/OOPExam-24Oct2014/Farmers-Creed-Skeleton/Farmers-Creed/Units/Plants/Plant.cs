using System.Text;

namespace FarmersCreed.Units
{
    using System;

    public abstract class Plant : FarmUnit
    {
        private int growTime;
        
        protected Plant(string id, int health, int productionQuantity, int growTime)
            : base(id, health, productionQuantity)
        {
            this.GrowTime = growTime;
            this.HasGrown = false;
            this.HealthIncrease = 2;
            this.HealthLoss = 1;
            this.GrowSpeed = 1;
        }

        public bool HasGrown { get; set; }

        public int HealthIncrease { get; protected set; }

        public int HealthLoss { get; protected set; }

        public int GrowSpeed { get; protected set; }

        public int GrowTime
        {
            get { return this.growTime; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Grow time cannot be a negative number.");
                }
                this.growTime = value;
            }
        }

        public virtual void Water()
        {
            if (this.IsAlive)
            {
                this.Health += this.HealthIncrease;
            }
        }

        public virtual void Wither()
        {
            if (this.IsAlive)
            {
                this.Health -= this.HealthLoss;

                if (this.Health <= 0)
                {
                    this.IsAlive = false;
                }
            }
        }

        public virtual void Grow()
        {
            if (this.IsAlive && !this.HasGrown)
            {
                this.GrowTime -= this.GrowSpeed;

                if (this.GrowTime <= 0)
                {
                    this.HasGrown = true;
                }
            }
        }

        public override string ToString()
        {
            bool isGrown = this.GrowTime <= 0;
            var output = new StringBuilder();
            output.AppendFormat("{0}, {1}",
                base.ToString(), this.Health > 0 ? string.Format("Health: {0}, ", this.Health) +
                (string.Format("Grown: {0}", isGrown ? "Yes" : "No")) : "DEAD");

            return output.ToString();
        }

    }
}
