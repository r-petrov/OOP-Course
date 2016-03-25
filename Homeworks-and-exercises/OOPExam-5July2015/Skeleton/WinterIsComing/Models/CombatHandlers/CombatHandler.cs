using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinterIsComing.Contracts;
using WinterIsComing.Core;

namespace WinterIsComing
{
    public abstract class CombatHandler : ICombatHandler
    {
        public IUnit Unit { get; set; }

        public abstract IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets);

        public abstract ISpell GenerateAttack();
    }
}
