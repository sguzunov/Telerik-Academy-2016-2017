using System;

using Dealership.IOProviders.Contracts;

namespace Dealership.IOProviders
{
    public class ConsoleOutputProviders : IOutputProvider
    {
        public Action<string> Write
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
