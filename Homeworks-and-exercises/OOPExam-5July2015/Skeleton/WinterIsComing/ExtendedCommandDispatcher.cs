using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinterIsComing.Core;
using WinterIsComing.Core.Commands;

namespace WinterIsComing
{
    public class ExtendedCommandDispatcher : CommandDispatcher
    {
        public override void DispatchCommand(string[] commandArgs)
        {
            base.DispatchCommand(commandArgs);
            string commandName = commandArgs[0];
            if (!this.commandsByName.ContainsKey(commandName))
            {
                throw new NotSupportedException(
                    "Command is not supported by engine");
            }

            var command = this.commandsByName[commandName];
            command.Execute(commandArgs);
        }

        public override void SeedCommands()
        {
            base.SeedCommands();
            this.commandsByName["toggle-effector"] = new ToggleEffectorCommand(this.Engine);
        }
    }
}
