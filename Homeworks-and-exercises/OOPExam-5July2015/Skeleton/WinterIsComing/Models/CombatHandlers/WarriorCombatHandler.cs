using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinterIsComing.Contracts;
using WinterIsComing.Core;
using WinterIsComing.Core.Exceptions;

namespace WinterIsComing
{
    public class WarriorCombatHandler : CombatHandler
    {
        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var targets = new List<IUnit>();

            candidateTargets.OrderBy(t => t.HealthPoints).OrderBy(t => t.Name);
            var target = candidateTargets.FirstOrDefault();

            targets.Add(target);

            return targets;
        }

        public override ISpell GenerateAttack()
        {
            Cleave cleave = new Cleave();

            if (this.Unit.HealthPoints > 50)
            {
                if (this.Unit.EnergyPoints < cleave.EnergyCost)
                {
                    throw new NotEnoughEnergyException(String.Format(GlobalMessages.NotEnoughEnergy, this.Unit.Name, cleave.GetType().Name));
                }

                this.Unit.EnergyPoints -= cleave.EnergyCost;
            }

            return cleave;
        }
    }
}
