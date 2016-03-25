using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinterIsComing
{
    public class FireBreath : MagSpells
    {
        public FireBreath()
        {
            this.Damage = this.Mage.AttackPoints;
            this.EnergyCost = 30;
        }

        public override int Damage { get; protected set; }

        public override int EnergyCost { get; protected set; }
    }
}
