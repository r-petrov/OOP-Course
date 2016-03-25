using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Projectiles
{
    public class Laser : Projectile
    {
        public Laser(int damage) : base(damage)
        {
        }

        public override void Hit(IStarship ship)
        {
            int difference = ship.Shields - this.Damage;
            ship.Shields = difference;
            if (difference < 0)
            {
                ship.Health -= Math.Abs(difference);
            }
        }
    }
}
