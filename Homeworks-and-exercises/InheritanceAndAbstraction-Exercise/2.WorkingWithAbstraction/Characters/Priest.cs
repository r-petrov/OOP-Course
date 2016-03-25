using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2.WorkingWithAbstraction.Interfaces;

namespace _2.WorkingWithAbstraction.Characters
{
    class Priest : Character, IHeal
    {
        public Priest() : base(125, 200, 100)
        {
        }

        public override void Attack(Character target)
        {
            if (this.Mana >= 100)
            {
                this.Mana -= 100;
                target.Health -= this.Damage;
                this.Health += (this.Damage*10)/100;
            }
        }

        public void Heal(Character target)
        {
            if (this.Mana >= 100)
            {
                this.Mana -= 100;
                target.Health += 150;
            }
        }
    }
}
