using System;
using System.Linq;
using MassEffect.Exceptions;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string attacker = commandArgs[1];
            string target = commandArgs[2];
            IStarship attackingShip = null;
            IStarship targetShip = null;
            attackingShip = GameEngine.Starships.FirstOrDefault(s => s.Name == attacker);
            targetShip = GameEngine.Starships.FirstOrDefault(s => s.Name == target);
            
            this.ProcessStarshipBattle(attackingShip, targetShip);
        }

        private void ProcessStarshipBattle(IStarship attackingStarship, IStarship targetStarship)
        {
            base.ValidateAlive(attackingStarship);
            base.ValidateAlive(targetStarship);

            if (attackingStarship.Location.Name != targetStarship.Location.Name)
            {
                throw new LocationOutOfRangeException(Messages.NoSuchShipInStarSystem);
            }

            IProjectile attack = attackingStarship.ProduceAttack();
            targetStarship.RespondToAttack(attack);

            Console.WriteLine(Messages.ShipAttacked, attackingStarship.Name, targetStarship.Name);

            if (targetStarship.Shields < 0)
            {
                targetStarship.Shields = 0;
            }

            if (targetStarship.Health < 0)
            {
                targetStarship.Health = 0;

                Console.WriteLine(Messages.ShipDestroyed, targetStarship.Name);
            }
        }
    }
}
