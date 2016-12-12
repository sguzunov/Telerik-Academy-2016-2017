using Dealership.Core.Contracts;

namespace Dealership.CommandExecutors
{
    public interface ICommandExecutor
    {
        GenericCommandExecutor Successor { get; set; }

        string ExecuteCommand(ICommand command);
    }
}
