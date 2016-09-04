namespace MinesweeperGame
{
    using System.Collections.Generic;

    public class PlayerCommand : IPlayerCommand
    {
        public PlayerCommand(string name)
        {
            this.Name = name;
            this.Arguments = new List<string>();
        }

        public IList<string> Arguments { get; private set; }

        public string Name { get; private set; }
    }
}
