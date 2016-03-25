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
    class Dreadnought : Starship
    {
        public Dreadnought(string name, int heath, int shields, int damage, double fuel, StarSystem location) : base(name, heath, shields, damage, fuel, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            return new Laser((this.Shields / 2) + this.Damage);
        }

        public override void RespondToAttack(IProjectile attack)
        {
            this.Shields += 50;

            base.RespondToAttack(attack);

            this.Shields -= 50;
        }
    }
}
