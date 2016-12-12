using System.Collections.Generic;

using Dealership.Core.Contracts;

namespace Dealership.Factories.Contracts
{
    public interface ICommandsFactory
    {
        ICommand CreateCommand(string name, IList<string> parameters);
    }
}
