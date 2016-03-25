using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinterIsComing.Core;

namespace WinterIsComing
{
    public class Blizzard : MagSpells
    {
        public Engine engine { get; set; }
        public Blizzard()
        {
            this.Damage = this.engine.Units.FirstOrDefault(u=>u is Mage).AttackPoints*2;
            this.EnergyCost = 40;
        }
        public override int Damage { get; protected set; }

        public override int EnergyCost { get; protected set; }
    }
}
