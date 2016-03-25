using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.Interfaces;

namespace MassEffect.Engine.Commands
{
    class SystemReportCommand : Command
    {
        public SystemReportCommand(IGameEngine gameEngine) : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string starSystemName = commandArgs[1];

            IEnumerable<IStarship> aliveStarships = new List<IStarship>();

            aliveStarships =
                 from starship in GameEngine.Starships
                 where starship.Location.Name == starSystemName && starship.Health > 0
                 orderby starship.Health descending, starship.Shields descending
                 select starship;

            StringBuilder output = new StringBuilder();
            output.AppendLine("Intact ships:");
            output.AppendLine(aliveStarships.Any() ? String.Join("\n", aliveStarships) : "N/A");

            IEnumerable<IStarship> destroyedStarships = new List<IStarship>();

            destroyedStarships =
                 from starship in GameEngine.Starships
                 where starship.Location.Name == starSystemName && starship.Health <= 0
                 select starship;

            output.AppendLine("Destroyed ships:");
            output.Append(destroyedStarships.Any() ? String.Join("\n", destroyedStarships) : "N/A");

            Console.WriteLine(output.ToString());
        }
    }
}
