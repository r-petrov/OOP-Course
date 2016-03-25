using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinterIsComing.Contracts;

namespace WinterIsComing
{
    public abstract class MagSpells : Spell
    {
        public Mage Mage { get; set; }
    }
}
