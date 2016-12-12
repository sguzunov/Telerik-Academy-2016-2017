using System;

using Dealership.Core.Contracts;

namespace Dealership.CommandExecutors
{
    public abstract class GenericCommandExecutor : ICommandExecutor
    {
        private const string InvalidCommand = "Invalid command!";

        private GenericCommandExecutor successor;

        public GenericCommandExecutor Successor
        {
            get
            {
                return this.successor;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(successor));
                }

                this.successor = value;
            }
        }

        public string ExecuteCommand(ICommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (this.CanExecuteCommand(command))
            {
                return this.Execute(command);
            }

            if (this.Successor != null)
            {
                this.Successor.ExecuteCommand(command);
            }

            return string.Format(InvalidCommand, command.Name);
        }

        protected abstract bool CanExecuteCommand(ICommand command);

        protected abstract string Execute(ICommand command);
    }
}
