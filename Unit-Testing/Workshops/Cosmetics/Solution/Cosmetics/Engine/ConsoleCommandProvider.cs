namespace Cosmetics.Engine
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    internal class ConsoleCommandProvider : ICommandProvider
    {
        public IList<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();

            var currentLine = Console.ReadLine();

            while (!string.IsNullOrEmpty(currentLine))
            {
                var currentCommand = Command.Parse(currentLine);
                commands.Add(currentCommand);

                currentLine = Console.ReadLine();
            }

            return commands;
        }
    }
}
