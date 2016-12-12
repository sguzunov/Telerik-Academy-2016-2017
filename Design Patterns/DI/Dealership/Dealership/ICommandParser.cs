using Dealership.Core.Contracts;

namespace Dealership
{
    public interface ICommandParser
    {
        ICommand ParseCommand(string commandAsString);
    }
}
