namespace MinesweeperGame
{
    public interface IScore
    {
        string PlayerName { get; }

        int Points { get; set; }
    }
}
