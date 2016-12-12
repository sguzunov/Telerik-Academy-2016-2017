using System.Collections.Generic;

namespace Dealership.Core.Contracts
{
    public interface IEngine
    {
        void Start(IEnumerable<ICommand> commands);
    }
}
