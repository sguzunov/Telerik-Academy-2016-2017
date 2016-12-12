using System;

namespace Dealership.IOProviders.Contracts
{
    public interface IInputProvider
    {
        Func<string> Read { get; }
    }
}
