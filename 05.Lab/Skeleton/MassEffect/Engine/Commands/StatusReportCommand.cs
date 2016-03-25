﻿using System;
using System.Linq;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class StatusReportCommand : Command
    {
        public StatusReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string shipName = commandArgs[1];
            IStarship ship = null;

            ship = this.GameEngine.Starships.FirstOrDefault(s => s.Name == shipName);

            Console.WriteLine(ship.ToString());
        }
    }
}
