using System;

namespace Dealership.IOProviders.Contracts
{
    public interface IOutputProvider
    {
        Action<string> Write { get; }
    }
}
