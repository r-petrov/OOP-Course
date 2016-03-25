using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinterIsComing.Contracts;
using WinterIsComing.Core;
using WinterIsComing.Core.Exceptions;

namespace WinterIsComing
{
    public class IceGiantCombatHandler : CombatHandler
    {
        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            if (this.Unit.HealthPoints <= 150)
            {
                var targets = new List<IUnit>();
                var target = candidateTargets.FirstOrDefault();
                targets.Add(target);
                return targets;
            }

            return candidateTargets;
        }

        public override ISpell GenerateAttack()
        {
            Stomp stomp = new Stomp();

            if (this.Unit.EnergyPoints < stomp.EnergyCost)
            {
                throw new NotEnoughEnergyException(String.Format(GlobalMessages.NotEnoughEnergy, this.Unit.Name, stomp.GetType().Name));
            }

            this.Unit.EnergyPoints -= stomp.EnergyCost;
            this.Unit.AttackPoints += 5;

            return stomp;
        }
    }
}
