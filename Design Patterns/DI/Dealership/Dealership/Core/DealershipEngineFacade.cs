using System.Collections.Generic;

using Dealership.Core.Contracts;
using Dealership.IOProviders.Contracts;

namespace Dealership.Core
{
    public class DealershipEngineFacade : IDealershipEngineFacade
    {
        private readonly IInputProvider inputProvider;
        private readonly ICommandParser commandParser;

        public DealershipEngineFacade(IInputProvider inputProvider, ICommandParser commandParser)
        {
            this.inputProvider = inputProvider;
            this.commandParser = commandParser;
        }

        public void Start(IEngine engine)
        {
            var commands = this.ReadCommands();

            engine.Start(commands);
        }

        private IList<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();
            var currentLine = this.inputProvider.Read();
            while (!string.IsNullOrEmpty(currentLine))
            {
                ICommand command = this.commandParser.ParseCommand(currentLine);
                commands.Add(command);

                currentLine = this.inputProvider.Read();
            }

            return commands;
        }
    }
}
