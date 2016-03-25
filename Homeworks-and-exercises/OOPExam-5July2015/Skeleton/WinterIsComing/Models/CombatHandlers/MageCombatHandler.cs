using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinterIsComing.Contracts;
using WinterIsComing.Core;
using WinterIsComing.Core.Exceptions;

namespace WinterIsComing
{
    public class MageCombatHandler : CombatHandler
    {
        private const int NumberOfTargets = 3;

        public MageCombatHandler()
        {
            this.Counter = 1;
        }

        public int Counter { get; set; }
        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var targets = new List<IUnit>();

            candidateTargets.OrderByDescending(t => t.HealthPoints).OrderBy(t => t.Name);

            for (int i = 0; i < Math.Min(NumberOfTargets, candidateTargets.Count()); i++)
            {
                targets.Add(candidateTargets.ElementAt(i));
            }

            return targets;
        }

        public override ISpell GenerateAttack()
        {
            if (this.Counter%2 != 0)
            {
                FireBreath fireBreath = new FireBreath();

                if (this.Unit.EnergyPoints < fireBreath.EnergyCost)
                {
                    throw new NotEnoughEnergyException(String.Format(GlobalMessages.NotEnoughEnergy, this.Unit.Name, fireBreath.GetType().Name));
                }

                this.Unit.EnergyPoints -= fireBreath.EnergyCost;
                this.Counter++;

                return fireBreath;
            }

            Blizzard blizzard = new Blizzard();

            if (this.Unit.EnergyPoints < blizzard.EnergyCost)
            {
                throw new NotEnoughEnergyException(String.Format(GlobalMessages.NotEnoughEnergy, this.Unit.Name, blizzard.GetType().Name));
            }

            this.Unit.EnergyPoints -= blizzard.EnergyCost;
            this.Counter++;

            return blizzard;
        }
    }
}
