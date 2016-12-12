using System;

using Dealership.IOProviders.Contracts;

namespace Dealership.IOProviders
{
    public class ConsoleInputProvider : IInputProvider
    {
        public Func<string> Read => Console.ReadLine;
    }
}
