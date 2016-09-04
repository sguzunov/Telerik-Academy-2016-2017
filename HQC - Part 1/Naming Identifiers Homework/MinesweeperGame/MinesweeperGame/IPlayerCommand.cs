namespace MinesweeperGame
{
    using System.Collections.Generic;

    public interface IPlayerCommand
    {
        string Name { get; }

        IList<string> Arguments { get; }
    }
}
