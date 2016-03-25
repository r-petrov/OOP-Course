using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Locations;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    public abstract class Starship : IStarship
    {
        private IList<Enhancement> enhancements; 
        protected Starship(string name, int heath, int shields, int damage, double fuel, StarSystem location)
        {
            this.Name = name;
            this.Health = heath;
            this.Shields = shields;
            this.Damage = damage;
            this.Fuel = fuel;
            this.Location = location;
            this.enhancements = new List<Enhancement>();
        }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Shields { get; set; }
        public int Damage { get; set; }
        public double Fuel { get; set; }
        public StarSystem Location { get; set; }

        public IEnumerable<Enhancement> Enhancements
        {
            get { return this.enhancements; }
        }
        public void AddEnhancement(Enhancement enhancement)
        {
            if (enhancement == null)
            {
                throw new ArgumentNullException("Enhancements cannot be null");
            }
            this.enhancements.Add(enhancement);
        }

        public abstract IProjectile ProduceAttack();

        public virtual void RespondToAttack(IProjectile attack)
        {
            attack.Hit(this);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(String.Format("--{0} - {1}", this.Name, this.GetType().Name));

            if (this.Health <= 0)
            {
                output.Append("(Destroyed)");
            }
            else
            {
                output.AppendLine(String.Format("-Location: {0}", this.Location.Name));
                output.AppendLine(String.Format("-Health: {0}", this.Health));
                output.AppendLine(String.Format("-Shields: {0}", this.Shields));
                output.AppendLine(String.Format("-Damage: {0}", this.Damage));
                output.AppendLine(String.Format("-Fuel: {0:F1}", this.Fuel));
                output.Append(String.Format("-Enhancements: {0}", this.enhancements.Any() ? string.Join(", ", this.enhancements.Select(en=>en.Name)) : "N/A"));
            }

            return output.ToString();
        }
    }
}
