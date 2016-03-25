using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinterIsComing.Core;

namespace WinterIsComing
{
    public class Cleave : Spell
    {
        public Cleave()
        {
            this.Damage = this.Warrior.AttackPoints;
            if (this.Warrior.HealthPoints <= 80)
            {
                this.Damage += (2*this.Warrior.HealthPoints);
            }
            this.EnergyCost = 15;
        }

        public override int Damage { get; protected set; }

        public override int EnergyCost { get; protected set; }

        public Warrior Warrior { get; set; }
    }
}
