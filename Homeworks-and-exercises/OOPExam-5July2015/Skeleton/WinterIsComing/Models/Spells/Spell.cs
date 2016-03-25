using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinterIsComing.Contracts;

namespace WinterIsComing
{
    public abstract class Spell : ISpell
    {
        public abstract int Damage { get; protected set; }

        public abstract int EnergyCost { get; protected set; }
    }
}
