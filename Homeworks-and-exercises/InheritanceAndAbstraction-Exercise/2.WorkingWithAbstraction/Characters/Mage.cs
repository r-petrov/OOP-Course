using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.WorkingWithAbstraction.Characters
{
    public class Mage : Character
    {
        public Mage() : base(100, 300, 75)
        {
        }

        public override void Attack(Character target)
        {
            if (base.Mana >= 100)
            {
                this.Mana -= 100;
                target.Health -= this.Damage * 2;
            }
            else
            {
                target.Health -= this.Damage;
            }
        }
    }
}
