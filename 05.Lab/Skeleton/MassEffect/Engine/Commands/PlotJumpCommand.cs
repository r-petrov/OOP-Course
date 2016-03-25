using System;
using System.Linq;
using MassEffect.Exceptions;
using MassEffect.GameObjects;
using MassEffect.GameObjects.Locations;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class PlotJumpCommand : Command
    {
        public PlotJumpCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string shipName = commandArgs[1];
            string destinationName = commandArgs[2];

            IStarship ship = null;
            ship = GameEngine.Starships.FirstOrDefault(s => s.Name == shipName);
            this.ValidateAlive(ship);

            var previousLocation = ship.Location;
            StarSystem destination = null;
            var galaxy = this.GameEngine.Galaxy;
            //Galaxy galaxy = new Galaxy();
            //MassEffectMain.SeedStarSystems(galaxy);
            destination = galaxy.GetStarSystemByName(destinationName);

            if (previousLocation.Name == destinationName)
            {
                throw new ShipException(String.Format(Messages.ShipAlreadyInStarSystem, destinationName));
            }

            galaxy.TravelTo(ship, destination);

            Console.WriteLine(Messages.ShipTraveled, ship.Name, previousLocation.Name, destination.Name);
        }
    }
}
