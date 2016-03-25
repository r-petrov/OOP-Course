using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.WorkingWithAbstraction.Characters
{
    public class Warior : Character
    {
        public Warior() : base(300, 0, 120)
        {
        }

        public override void Attack(Character target)
        {
            target.Health -= this.Damage;
        }
    }
}
