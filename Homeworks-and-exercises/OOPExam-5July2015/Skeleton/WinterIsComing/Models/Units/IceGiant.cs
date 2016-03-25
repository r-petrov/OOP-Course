using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinterIsComing.Contracts;
using WinterIsComing.Models;

namespace WinterIsComing
{
    public class IceGiant : Unit
    {
        public IceGiant(int x, int y, string name, int range, int attackPoints, int healthPoints, int defensePoints, int energyPoints)
            : base(x, y, name, range, attackPoints, healthPoints, defensePoints, energyPoints)
        {
            this.Type=UnitType.IceGiant;
            this.combatHandler = new IceGiantCombatHandler();
        }

        public override ICombatHandler CombatHandler
        {
            get { return this.combatHandler; }
        }

        public override UnitType Type { get; protected set; }
    }
}
