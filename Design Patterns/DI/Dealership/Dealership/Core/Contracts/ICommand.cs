using System.Collections.Generic;

namespace Dealership.Core.Contracts
{
    public interface ICommand
    {
        string Name { get; }

        IList<string> Parameters { get; }
    }
}
