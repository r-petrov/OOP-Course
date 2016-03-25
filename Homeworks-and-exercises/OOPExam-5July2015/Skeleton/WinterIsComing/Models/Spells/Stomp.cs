using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinterIsComing
{
    public class Stomp : Spell
    {
        public Stomp()
        {
            this.Damage = this.IceGiant.AttackPoints;
            this.EnergyCost = 10;
        }
        public override int Damage { get; protected set; }

        public override int EnergyCost { get; protected set; }

        public IceGiant IceGiant { get; set; }
    }
}
