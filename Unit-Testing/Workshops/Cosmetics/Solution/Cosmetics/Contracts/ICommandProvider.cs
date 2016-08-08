namespace Cosmetics.Contracts
{
    using System.Collections.Generic;

    internal interface ICommandProvider
    {
        IList<ICommand> ReadCommands();
    }
}
