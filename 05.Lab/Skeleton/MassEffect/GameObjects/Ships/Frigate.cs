using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    class Frigate : Starship
    {
        private int projectilesFired;
        public Frigate(string name, int heath, int shields, int damage, double fuel, StarSystem location) : base(name, heath, shields, damage, fuel, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            this.projectilesFired++;
            return new ShieldReaver(this.Damage);
        }

        public override string ToString()
        {
            string output = base.ToString();

            if (this.Health > 0)
            {
                output += String.Format("\n-Projectiles fired: {0}", this.projectilesFired);
            }

            return output;
        }
    }
}
